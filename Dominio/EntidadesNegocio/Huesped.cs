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
    public class Huesped:Rol
    {
        #region Properties
        public List<Reserva> ListaReservas { get; set; }
        #endregion

        #region Cadenas de comando para ACTIVE RECORD
        #endregion

        #region Métodos ACTIVE RECORD
        public override bool Add()
        {
            if (this.Validar())
            {
                SqlConnection cn = BdSQL.Conectar();
                SqlTransaction trn = null;
                try
                {
                    SqlCommand cmd = new SqlCommand(cadenaInsert, cn);
                    cmd.Parameters.AddWithValue("@tipo", this.Tipo);
                    //abrimos la coneccion
                    cn.Open();

                    //iniciamos la transaccion
                    trn = cn.BeginTransaction();
                    cmd.Transaction = trn;
                    int idRol = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.CommandText = "INSERT INTO ReservasHuesped VALUES (@idReserva,@idRol)";
                    foreach (Reserva unaR in this.ListaReservas)
                    {
                        cmd.Parameters.AddWithValue("@idRol", idRol);
                        cmd.Parameters.AddWithValue("@idAnuncio", unaR.Id);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.ExecuteNonQuery();
                    trn.Commit();
                    cmd.Parameters.Clear();
                    return true;
                }
                catch (Exception ex)
                {
                    //falta hacer algo con la excepcion
                    BdSQL.LoguearError(ex.Message + "No se pudo agregar el Huesped");
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

        //public override bool Delete()
        //{
        //    using (SqlConnection cn = BdSQL.Conectar())
        //    {
        //        using (SqlCommand cmd = new SqlCommand(cadenaDelete, cn))
        //        {

        //            cmd.Parameters.AddWithValue("@id", this.Id);
        //            cn.Open();
        //            int afectadas = cmd.ExecuteNonQuery();
        //            return afectadas == 1;
        //        }
        //    }
        //}
        #endregion

        #region Validaciones
        public override bool Validar()
        {
            if (this.ListaReservas.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Redefiniciones de object
        #endregion
    }
}
