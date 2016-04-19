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
    public abstract class Rol: IEntity
    {
        #region Properties
        public int Id { get; set; }
        public RolesSistema Tipo { get; set; }
        #endregion

        #region Cadenas de comando para ACTIVE RECORD
        protected string cadenaInsert = "INSERT INTO Rol VALUES (@tipo); SELECT CAST(SCOPE_IDENTIY() AS INT);";
        //private string cadenaUpdate = "UPDATE  Rol SET WHERE id = @id";
        protected string cadenaDelete = "DELETE  Rol WHERE id = @id";
        #endregion

        #region Métodos ACTIVE RECORD
        public abstract bool Add();

        //public bool Update()
        //{
        //    if (this.Validar())
        //    {
        //        using (SqlConnection cn = BdSQL.Conectar())
        //        {
        //            using (SqlCommand cmd = new SqlCommand(cadenaUpdate, cn))
        //            {
        //                cmd.Parameters.AddWithValue("@id", this.Id);
        //                cn.Open();
        //                int afectadas = cmd.ExecuteNonQuery();
        //                return afectadas == 1;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //public abstract bool Delete();
        
        public void Load(IDataRecord dr)
        {
            if (dr != null)
            {
                this.Id = Convert.ToInt32(dr["id"]);
            }
        }
        #endregion

        #region Validaciones
        public abstract bool Validar();      
        #endregion

        #region Redefiniciones de object
        public override string ToString()
        {
            return this.Id.ToString();
        }
        #endregion
    }
}
