using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;
using System.Data;
using System.Data.SqlClient;

namespace Dominio.EntidadesNegocio
{
    public class Anuncio : IEntity
    {
        #region Properties
        public int Id { get; set; }
        public bool Publicado { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Foto> Fotos { get; set; }
        public List<RangoFechas> ListaRangos { get; set; }
        #endregion

        #region Cadenas de comando para ACTIVE RECORD
        private string cadenaInsert = "INSERT INTO Anuncio VALUES (@publicado,@nombre,@descripcion); SELECT CAST(SCOPE_IDENTIY() AS INT);";
        //private string cadenaUpdate = "UPDATE  Anuncio SET publicado = @publicado, nombre = @nombre, descripcion = @descripcion WHERE id = @id";
        private string cadenaDelete = "DELETE  Anuncio WHERE id = @id;";
        #endregion

        #region Métodos ACTIVE RECORD
        public bool Add()
        {
            if (this.Validar())
            {
                SqlConnection cn = BdSQL.Conectar();
                SqlTransaction trn = null;
                try
                {
                    SqlCommand cmd = new SqlCommand(cadenaInsert, cn);
                    cmd.Parameters.AddWithValue("@publicado", this.Publicado);
                    cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                    cn.Open();
                    int idAnuncio = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.CommandText = "INSERT INTO HabitacionesAnuncio VALUES (@id_Anuncio,@id_Habitacion)";
                    foreach (Habitacion unaH in this.Habitaciones)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id_Anuncio", idAnuncio);
                        cmd.Parameters.AddWithValue("@id_Habitacion", unaH.Id);
                        cmd.ExecuteNonQuery();
                    }
                    // acá tenemos el Anuncio y su lista de habitaciones...
                    cmd.CommandText = "INSERT INTO Foto VALUES (@ruta,@id_Anuncio)";
                    foreach (Foto unaF in this.Fotos){
                        cmd.Parameters.AddWithValue("@ruta", unaF.Ruta);
                        cmd.ExecuteNonQuery();
                    }
                    // acá ya tenemos también guardadas las fotos...
                    cmd.CommandText = "INSERT INTO RangoFechaAnuncio VALUES (@fecha_ini,@fecha_fin,@id_Anuncio)";
                    foreach (RangoFechas unRF in this.ListaRangos)
                    {
                        cmd.Parameters.AddWithValue("@fecha_ini", unRF.Fecha_ini);
                        cmd.Parameters.AddWithValue("@fecha_fin", unRF.Fecha_fin);
                        cmd.ExecuteNonQuery();
                    }
                    trn.Commit();
                    cmd.Parameters.Clear();
                    return true;
                }//fin del try
                catch (Exception ex)
                {
                    //falta hacer algo con la excepcion
                    BdSQL.LoguearError(ex.Message + "No se pudo agregar el Anuncio");
                    trn.Rollback();
                    return false;

                }//fin del catch
                finally
                {
                    trn.Dispose();
                    trn = null;
                    cn.Close();
                    cn.Dispose();
                }
            }
            else
            {
                return false;
            }

        }
        //public bool Update()
        //{
        //    if (this.Validar())
        //    {
        //        using (SqlConnection cn = BdSQL.Conectar())
        //        {
        //            using (SqlCommand cmd = new SqlCommand(cadenaUpdate, cn))
        //            {
        //                cmd.Parameters.AddWithValue("@publicado", this.Publicado);
        //                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
        //                cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
        //                cmd.Parameters.AddWithValue("@id", this.Id);
        //                cn.Open();
        //                int afectadas = cmd.ExecuteNonQuery();
        //                return afectadas == 1;
        //            }
        //        }
        //    }
        //    return false;
        //}
        public bool Delete()
        {
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaDelete, cn))
                {

                    cmd.Parameters.AddWithValue("@id", this.Id);
                    cn.Open();
                    int afectadas = cmd.ExecuteNonQuery();
                    return afectadas == 1;
                }
            }
        }
        public void Load(IDataRecord dr)
        {
            if (dr != null)
            {
                //@fecha_ini,@fecha_fin,@variacion_precio
                this.Publicado = Convert.ToBoolean(dr["publicado"].ToString());
                this.Nombre = dr["nombre"].ToString();
                this.Descripcion = dr["descripcion"].ToString();
                this.Id = Convert.ToInt32(dr["id"]);
            }
        }
        #endregion

        #region Validaciones
        public bool Validar()
        {
            return true;
        }
        #endregion

        #region Redefiniciones de object
        public override string ToString()
        {
            return this.Id.ToString() + " - Publicado: " + this.Publicado.ToString() + " - Nombre: " + this.Nombre + " - Descripcion: " + this.Descripcion;
        }
        #endregion
    }
}
