using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using FabricaRepositorios;

namespace AppWeb
{
    public partial class Prueba_Habitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnServicios_Click(object sender, EventArgs e)
        {
            IRepositorioServicios repoSer = FabricaReposBienvenidosUY.CrearRepositorioServicio();
            List<Servicio> servicios = new List<Servicio>();
            servicios = repoSer.FindAll();
            if (servicios != null)
            {
                this.lstServicios.DataSource = servicios;
                this.lstServicios.DataBind();
            }
            else
                lblServicios.Text = "No hay servicios para mostrar.";
        }

        protected void btnHabitaciones_Click(object sender, EventArgs e)
        {
            IRepositorioHabitaciones repoHab = FabricaReposBienvenidosUY.CrearRepositorioHabitacion();
            List<Habitacion> habitaciones = new List<Habitacion>();
            habitaciones = repoHab.FindAll();
            if (habitaciones != null)
            {
                this.lstHabitaciones.DataSource = habitaciones;
                this.lstHabitaciones.DataBind();
            }
            else {
                lblHabitaciones.Text = "No hay habitaciones para mostrar.";
            }
        }

        protected void btnMostrarHabitacion_Click(object sender, EventArgs e)
        {
            int idHabitacion = Convert.ToInt32(txtMostrarHabitacion.Text);
            IRepositorioHabitaciones repoHab = FabricaReposBienvenidosUY.CrearRepositorioHabitacion();
            Habitacion h = repoHab.FindById(idHabitacion);
            
            if (h != null)
            {
                lblMostrarHabitacion.Text = h.ToString();
            }
            else {
                lblMostrarHabitacion.Text = "No hay habitaciones para mostrar.";
            }
        }
    }
}