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
    public class Habitacion : IEntity
    {
        #region Properties
        public int Id { get; set; }
        public List<Servicio> Servicios { get; set; }
        public bool Baño_Privado { get; set; }
        public int Camas { get; set; }
        public int Cupo_max { get; set; }
        public decimal Precio_base { get; set; }
        public Alojamiento Alojamiento { get; set; }
        #endregion

        #region Cadenas de comando para ACTIVE RECORD
        private string cadenaInsert = "INSERT INTO Habitacion (banio_privado,camas,cupo_max,precio_base,id_alojamiento) VALUES (@baño_privado,@camas,@cupo_max,@precio_base,@id_alojamiento);SELECT CAST(SCOPE_IDENTIY() AS INT);";
        private string cadenaUpdate = "UPDATE  Habitacion SET baño_privado = @baño_privado, camas = @camas, cupo_max = @cupo_max, precio_base = @precio_base WHERE id = @id";
        private string cadenaDelete = "DELETE  Habitacion WHERE id = @id";
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
                    cmd.Parameters.AddWithValue("@baño_privado", this.Baño_Privado);
                    cmd.Parameters.AddWithValue("@camas", this.Camas);
                    cmd.Parameters.AddWithValue("@cupo_max", this.Cupo_max);
                    cmd.Parameters.AddWithValue("@precio_base", this.Precio_base);
                    cmd.Parameters.AddWithValue("@id_alojamiento", this.Alojamiento.Id);
                    cn.Open();
                    int idHabitacion = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.CommandText = "INSERT into ServiciosHabitacion (id_habitacion,id_servicio) VALUES (@id_habitacion,@id_servicio)";
                    foreach (Servicio unS in this.Servicios)
                    {
                        cmd.Parameters.AddWithValue("@id_habitacion", this.Id);
                        cmd.Parameters.AddWithValue("@id_servicio", unS.Id);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    //falta hacer algo con la excepcion
                    BdSQL.LoguearError(ex.Message + "No se pudo agregar la Habitación");
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
        public bool Update()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdate, cn))
                    {
                        cmd.Parameters.AddWithValue("@baño_privado", this.Baño_Privado);
                        cmd.Parameters.AddWithValue("@camas", this.Camas);
                        cmd.Parameters.AddWithValue("@cupo_max", this.Cupo_max);
                        cmd.Parameters.AddWithValue("@precio_base", this.Precio_base);
                        cmd.Parameters.AddWithValue("@id", this.Id);
                        cn.Open();
                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }
                }
            }
            return false;
        }
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
                if (dr["banio_privado"].ToString() == "si") {
                    this.Baño_Privado = true;
                } else {
                    this.Baño_Privado = false;
                }
                this.Camas = Convert.ToInt32(dr["camas"].ToString());
                this.Cupo_max = Convert.ToInt32(dr["cupo_max"].ToString());
                this.Precio_base = Convert.ToDecimal(dr["precio_base"].ToString());
                this.Servicios = null;
                this.Id = Convert.ToInt32(dr["id"]);
                this.Alojamiento = null;
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
            string servicios = "";
            if (this.Servicios != null)
            {
                foreach (Servicio unS in this.Servicios)
                {
                    servicios += unS.Nombre + " - ";
                }
            }
            return this.Id.ToString() + " - BañoPriv: " + this.Baño_Privado.ToString() + " - Camas: " + this.Camas.ToString() + " - Precio_base: " + this.Precio_base.ToString() + " - Servicios:" + servicios;
        }
        #endregion
    }
}