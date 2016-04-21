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
    public class RepositorioHabitacionesSQL
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
            List<Servicio> listaServicios = new List<Servicio>();
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaFind, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.Read())
                    {
                        h = new Habitacion();
                        h.Load(reader);
                        cmd.CommandText = "SELECT id_alojamiento FROM Habitacion WHERE id=@id";
                        SqlDataReader readerAlojamiento = cmd.ExecuteReader();
                        if (readerAlojamiento != null && readerAlojamiento.Read())
                        {
                            Alojamiento unA = new RepositorioAlojamientosSQL().FindById(Convert.ToInt32(readerAlojamiento["id_alojamiento"].ToString()));
                            h.Alojamiento = unA;
                        }
                        cmd.CommandText = "SELECT id_servicio FROM ServiciosHabitacion WHERE id_habitacion=@id";
                        SqlDataReader readerServicios = cmd.ExecuteReader();
                        while (readerServicios.Read())
                        {
                            Servicio unS = new RepositorioServiciosSQL().FindById(Convert.ToInt32(readerServicios["id_servicio"].ToString()));
                            listaServicios.Add(unS);
                        }
                        h.Servicios = listaServicios;
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