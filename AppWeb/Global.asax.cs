using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Dominio.EntidadesNegocio;

namespace AppWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["fotosAnuncio"] = new List<Foto>();
            Session["rangoFechasAnuncio"] = new List<RangoFechas>();
            Session["habitacionesAnuncio"] = new List<Habitacion>();
            Session["usuario"] = new Persona
            {
                //'Maria','Ruperto','2564857-1','','aaaa1111'
                Apellido = "Ruperto",
                Ci = "2564857-1",
                Email = "marialaloca@gmail.com",
                Nombre = "Maria",
                Id = 1,
                Roles = new List<Rol>()
            };

            }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}