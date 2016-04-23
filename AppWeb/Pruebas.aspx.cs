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
    public partial class Pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            IRepositorioUbicaciones repoUbi = FabricaReposBienvenidosUY.CrearRepositorioUbicacion();
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            ubicaciones = repoUbi.FindAll();
            if (ubicaciones != null)
            {
                this.lstUbi.DataSource = ubicaciones;
                this.lstUbi.DataBind();
            }
            else
                Label1.Text = "No hay organizaciones para mostrar.";

            IRepositorioRangoPrecios repoRango = FabricaReposBienvenidosUY.CrearRepositorioRangoPrecio();
            List<RangoPrecio> precios = new List<RangoPrecio>();
            precios = repoRango.FindAll();
            if (precios != null)
            {
                this.lbxRangos.DataSource = precios;
                this.lbxRangos.DataBind();
            }
            else
                Label1.Text = "No hay organizaciones para mostrar.";

            IRepositorioAlojamientos repoAlos = FabricaReposBienvenidosUY.CrearRepositorioAlojamiento();
            List<Alojamiento> alojamientos = new List<Alojamiento>();
            alojamientos = repoAlos.FindAll();
            Alojamiento unA = repoAlos.FindById(Convert.ToInt32(txtIdAlojamiento.Text));
            Session["alojamientos"] = alojamientos;

            if (alojamientos != null)
            {
                this.lbxAlojamientos.DataSource = alojamientos;
                this.lbxAlojamientos.DataBind();
                Label1.Text = unA.Mostrar;
            }
            else
                Label1.Text = "No hay organizaciones para mostrar.";

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AltaAlojamiento.aspx");
        }

        protected void btnBuscarRP_Click(object sender, EventArgs e)
        {
            IRepositorioRangoPrecios repoRango = FabricaReposBienvenidosUY.CrearRepositorioRangoPrecio();
            int id = Convert.ToInt32(txtRP.Text);
            RangoPrecio rp = repoRango.FindById(id);
            if (rp != null)
            {
                this.lblRangoPrecio.Text = rp.ToString();
            }
            else
                this.lblRangoPrecio.Text = "No hay organizaciones para mostrar.";

        }

        protected void btnUBI_Click(object sender, EventArgs e)
        {
            IRepositorioUbicaciones repoUbi = FabricaReposBienvenidosUY.CrearRepositorioUbicacion();
            Ubicacion ubi = repoUbi.FindById(Convert.ToInt32(txtUBI.Text));
            if (ubi != null)
            {
                lblUBI.Text = ubi.ToString();
            }
            else
                lblUBI.Text = "No hay ubicaciones para mostrar.";
        }

        protected void btnALOID_Click(object sender, EventArgs e)
        {
            IRepositorioAlojamientos repoAlos = FabricaReposBienvenidosUY.CrearRepositorioAlojamiento();
            Alojamiento unA = repoAlos.FindById(Convert.ToInt32(txtIdAlojamiento.Text));

            if (unA != null)
            {
                lblALOXID.Text = unA.Mostrar;

            }
            else
                lblALOXID.Text = "No hay organizaciones para mostrar.";
        }
    }
}