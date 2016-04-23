using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using System.Data.SqlClient;
using Utilidades;

namespace Repositorios
{
    public class RepositorioHabitacionesSQL:IRepositorioHabitaciones
    {
        public bool Add(Habitacion obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            Habitacion h = this.FindById(id);
            return (h != null && h.Delete());

        }

        public List<Habitacion> FindAll()
        {
            // estaría faltando los servicios...
            string cadenaFindAll = "SELECT id,banio_privado,camas,cupo_max,precio_base FROM Habitacion";
            List<Habitacion> listaHabitaciones = new List<Habitacion>();
            List<Servicio> listaServicios = new List<Servicio>();
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaFindAll, cn))
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            Habitacion h = new Habitacion();
                            h.Load(reader);
                            if (h.Validar())
                                listaHabitaciones.Add(h);
                        }
                    } 
                }
            }
            return listaHabitaciones;
        }

        public Habitacion FindById(int id)
        {
            string cadenaFind = "SELECT id,banio_privado,camas,cupo_max,precio_base FROM Habitacion WHERE id=@id";
            Habitacion h = null;
            Alojamiento a = null;
            Servicio s = null;
            List <Servicio> listaServicios = new List<Servicio>();
            List<RangoPrecio> precios_temporada = new List<RangoPrecio>();
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaFind, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.Read())
                    {
                        // cargo la habitacion
                        h = new Habitacion();
                        h.Load(reader);
                        reader.Close();

                        //cargo los  servicios 
                        //cmd.CommandText = "SELECT id_servicio FROM ServiciosHabitacion WHERE id_habitacion=@id";

                        cmd.CommandText = "SELECT Servicio.* FROM ServiciosHabitacion, Servicio WHERE ServiciosHabitacion.id_habitacion = @id AND Servicio.id = ServiciosHabitacion.id_servicio";
                        reader = cmd.ExecuteReader();
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                s = new Servicio();
                                s.Load(reader);
                                listaServicios.Add(s);
                            }
                            
                        }
                        h.Servicios = listaServicios;
                        reader.Close();

                        //cargo el id del alojamiento para esa habitacion
                        cmd.CommandText = "SELECT Habitacion.id_alojamiento FROM Habitacion WHERE Habitacion.id=@id";
                        reader = cmd.ExecuteReader();
                        int idAlo = 0;
                        if (reader != null && reader.Read())
                        {
                            idAlo = Convert.ToInt32(reader["id_alojamiento"].ToString());
                        }
                        reader.Close();

                        //cargo todos los datos simples del alojamiento sin el rango precio
                        cmd.CommandText = "SELECT Alojamiento.*, Ubicacion.ciudad, Ubicacion.id as idubi, Ubicacion.barrio, Ubicacion.dirLinea1, Ubicacion.dirLinea2 FROM Alojamiento, Ubicacion WHERE Alojamiento.idUbicacion = Ubicacion.id AND Alojamiento.id = @id";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", idAlo);
                        reader = cmd.ExecuteReader();
                        if (reader != null && reader.Read())
                        {
                            a = new Alojamiento();
                            a.Load(reader);
                            a.Id = idAlo;
                            a.Ubicacion = new Ubicacion
                            {
                                Id = Convert.ToInt32(reader["idubi"].ToString()),
                                Ciudad = reader["ciudad"].ToString(),
                                Barrio = reader["barrio"].ToString(),
                                DireccionLinea1 = reader["dirLinea1"].ToString(),
                                DireccionLinea2 = reader["dirLinea2"].ToString()
                            };
                        }
                        reader.Close();
                        //Cargo los elementos de la lista de rango precios al alojamiento
                        cmd.CommandText = "SELECT * FROM RangoPrecio WHERE id_alojamiento = @id";
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            RangoPrecio unR = new RangoPrecio();
                            a.loadRangoPrecio(unR, reader);
                            precios_temporada.Add(unR);
                        }
                        a.Precios_temporada = precios_temporada;
                        h.Alojamiento = a;
                        reader.Close();
                    }
                }
            }
            return h;
        }

        public bool Update(Habitacion obj)
        {
            return obj != null && obj.Update();
        }
    }
}