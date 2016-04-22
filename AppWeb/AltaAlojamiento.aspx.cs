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
    public partial class AltaAlojamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtCiudad.Text = "montevideo";
                txtBarrio.Text = "prado";
                txtDirL1.Text = "hermanos gil";
                txtDirL2.Text = "1019/27";
                txtPrecio.Text = "2500";



                if (Session["alojamientos"] != null)
                {
                    this.lbxListado.DataSource = Session["alojamientos"];
                    this.lbxListado.DataBind();

                }
            }
        }

        protected void btnAltaAlojamiento_Click(object sender, EventArgs e)
        {
            string tipo = drpTipo.SelectedItem.Text;
            string ciudad = txtCiudad.Text;
            string barrio = txtBarrio.Text;
            string dirL1 = txtDirL1.Text;
            string dirL2 = txtDirL2.Text;
            DateTime fechaIni = calFechaIni.SelectedDate;
            DateTime fechaFin = calFechaFin.SelectedDate;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            RangoPrecio unR = new RangoPrecio { Id = 1, Fecha_inicio = fechaIni, Fecha_fin = fechaFin, Variacion_precio = precio };
            Alojamiento unA = new Alojamiento
            {
                Id = 0,
                Tipo = tipo,
                Ubicacion = new Ubicacion { Id = 1, Barrio = barrio, Ciudad = ciudad, DireccionLinea1 = dirL1, DireccionLinea2 = dirL2 },
                Precios_temporada = new List<RangoPrecio>()
            };
            unA.Precios_temporada.Add(unR);
            if (unA.Add())
                lblMensaje.Text = "EXITO";
            else
                lblMensaje.Text = "ERROR";
            //IRepositorioAlojamientos unRepo = FabricaReposBienvenidosUY.CrearRepositorioAlojamiento();


        }
    }
}