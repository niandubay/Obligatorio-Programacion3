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
	public class Persona : IEntity
	{
		#region Properties
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int Ci { get; set; }
		public string Email { get; set; }
		public List<Rol> Roles { get; set; }
		#endregion

		#region Cadenas de comando para ACTIVE RECORD
		private string cadenaInsert = "INSERT INTO Persona VALUES (@nombre,@apellido,@ci,@email); SELECT CAST(SCOPE_IDENTIY() AS INT);";
		private string cadenaUpdate = "UPDATE Persona SET nombre = @nombre, apellido = apellido, ci = @ci, email = @email WHERE id = @id";
		private string cadenaDelete = "DELETE Persona WHERE id = @id; DELETE RolesPersona WHERE id_persona = @id";
        #endregion

        #region Métodos ACTIVE RECORD
        public bool Add()
		{
			if (this.Validar())
			{
				//BdSQL retorna una SQLConnection con el string de conexion en el ConnectionString del WEbconfig 
				SqlConnection cn = BdSQL.Conectar();
                SqlTransaction trn = null;
                try
				{
					SqlCommand cmd = new SqlCommand(cadenaInsert, cn);
					//Asigna el valor a los parametros usados en la consulta
					cmd.Parameters.AddWithValue("@nombre", this.Nombre);
					cmd.Parameters.AddWithValue("@apellido", this.Apellido);
					cmd.Parameters.AddWithValue("@ci", this.Ci);
					cmd.Parameters.AddWithValue("@email", this.Email);
					//Abro la conexion
					cn.Open();
                    //iniciamos la transaccion
                    trn = cn.BeginTransaction();
                    cmd.Transaction = trn;
                    // me quedo con el id de la persona guardada...
                    int idPersona = Convert.ToInt32(cmd.ExecuteScalar());
                    // nuevo comando para guardar su lista de roles...
                    cmd.CommandText = "INSERT INTO RolesPersona VALUES (@id_persona,@id_rol)";
                    // para cada rol hago su insert en la tabla de roles por persona
                    foreach (Rol unR in this.Roles)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id_persona", idPersona);
                        cmd.Parameters.AddWithValue("@id_rol", unR.Id);
                        cmd.ExecuteNonQuery();
                    }
                    // hago el commit de la transacción...
                    trn.Commit();
                    // limpio parámetros y retorno true
                    cmd.Parameters.Clear();
                    return true;
				}
				catch (Exception ex)
				{
					// logueo la excepción...
					BdSQL.LoguearError(ex.Message + "No se pudo agregar la Persona");
                    // hago un rollback y retorno false
					trn.Rollback();
					return false;

				}//fin del catch
				finally
				{
                    // libero los recursos...
					trn.Dispose();
					trn = null;
					cn.Close();
					cn.Dispose();
				}
			}
			else
			{
                // si no pasa la validación retorno false...
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
						cmd.Parameters.AddWithValue("@nombre", this.Nombre);
						cmd.Parameters.AddWithValue("@apellido", this.Apellido);
						cmd.Parameters.AddWithValue("@ci", this.Ci);
						cmd.Parameters.AddWithValue("@email", this.Email);
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
            SqlConnection cn = BdSQL.Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand(cadenaDelete, cn);
                cmd.Parameters.AddWithValue("@id", this.Id);
                //Abro la conexion
                cn.Open();
                //borro la persona
                cmd.ExecuteNonQuery();
                // limpio parámetros y retorno true
                cmd.Parameters.Clear();
                return true;
            }
            catch (Exception ex)
            {
                // logueo la excepción...
                BdSQL.LoguearError(ex.Message + "No se pudo borrar la Persona");
                return false;

            }//fin del catch
            finally
            {
                // libero los recursos...
                cn.Close();
                cn.Dispose();
            }
        }
		public void Load(IDataRecord dr)
		{
			if (dr != null)
			{
				//@nombre,@apellido,@ci,@email
				this.Nombre = dr["nombre"].ToString();
				this.Apellido = dr["apellido"].ToString();
				this.Ci = Convert.ToInt32(dr["ci"].ToString());
				this.Email = dr["email"].ToString();
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
			return this.Id + " - Nombre: " + this.Nombre + " - Apellido: " + this.Apellido;
		}
		#endregion
	}
}
