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
    public class RepositorioAnunciosSQL
    {
        public bool Add(Anuncio obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            Anuncio a = this.FindById(id);
            return (a != null && a.Delete());

        }

        public List<Anuncio> FindAll()
        {
            string cadenaFindAll = "SELECT id,publicado,nombre,descripcion FROM Anuncio";
            List<Anuncio> listaAnuncios = new List<Anuncio>();
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
                            Anuncio a = new Anuncio();
                            a.Load(reader);
                            if (a.Validar())
                                listaAnuncios.Add(a);
                        }
                    }
                }
            }
            return listaAnuncios;
        }

        public Anuncio FindById(int id)
        {
            string cadenaFind = "SELECT id,publicado,nombre,descripcion FROM Anuncio WHERE id=@id";
            Anuncio a = null;
            List<Habitacion> lista_habitaciones = new List<Habitacion>();
            List<Foto> lista_fotos = new List<Foto>();
            List<RangoFechas> lista_rangos = new List<RangoFechas>();

            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaFind, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.Read())
                    {
                        a = new Anuncio();
                        a.Load(reader);

                        cmd.CommandText = "SELECT id_habitacion FROM HabitacionesAnuncio WHERE id_anuncio = @id";
                        SqlDataReader readerHabitaciones = cmd.ExecuteReader();                     
                        while (readerHabitaciones.Read())
                        {
                            Habitacion unaH = new RepositorioHabitacionesSQL().FindById(Convert.ToInt32(readerHabitaciones["id_habitacion"].ToString()));
                            lista_habitaciones.Add(unaH);
                        }
                        cmd.CommandText = "SELECT ruta FROM Foto WHERE id_anuncio = @id";
                        SqlDataReader readerFotos = cmd.ExecuteReader();
                        while (readerFotos.Read())
                        {
                            Foto unaF = new Foto
                            {
                                Ruta = readerFotos["ruta"].ToString()
                            };
                            lista_fotos.Add(unaF);  
                        }
                        cmd.CommandText = "SELECT fecha_ini,fecha_fin FROM RangoFechaAnuncio WHERE id_anuncio = @id";
                        SqlDataReader readerFechas = cmd.ExecuteReader();
                        while (readerFechas.Read())
                        {
                            RangoFechas unR = new RangoFechas
                            {
                                Fecha_ini = Convert.ToDateTime(readerFechas["fecha_ini"].ToString()),
                                Fecha_fin = Convert.ToDateTime(readerFechas["fecha_fin"].ToString())
                            };
                            lista_rangos.Add(unR);
                        }
                        a.Habitaciones = lista_habitaciones;
                        a.ListaRangos = lista_rangos;
                        a.Fotos = lista_fotos;
                    }
                }
            }
            return a;
        }

        //public bool Update(Anuncio obj)
        //{
        //    return obj != null && obj.Update();
        //}
    }
}
