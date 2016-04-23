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
    public class RangoFechas
    {
        #region Properties
        public DateTime Fecha_ini { get; set; }
        public DateTime Fecha_fin { get; set; }
        #endregion

        //public void Load(IDataRecord dr)
        //{
        //    if (dr != null)
        //    {
        //        //@fecha_ini,@fecha_fin,@variacion_precio
        //        this.Fecha_ini = Convert.ToDateTime(dr["fecha_ini"].ToString());
        //        this.Fecha_fin = Convert.ToDateTime(dr["fecha_fin"].ToString());
        //        //this.Id = Convert.ToInt32(dr["id"]);
        //    }
        //}

        #region Validaciones
        public bool Validar()
        {
            return true;
        }
        #endregion

        #region Redefiniciones de object
        public override string ToString()
        {
            return this.Fecha_fin + "-" + this.Fecha_fin;
        }
        #endregion
    }
}
