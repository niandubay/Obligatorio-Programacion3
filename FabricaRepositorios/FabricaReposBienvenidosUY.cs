using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FabricaRepositorios
{
    public class FabricaReposBienvenidosUY
    {
        private static string LeerTipoDesdeConfiguracion()
        {
            return System.Configuration.ConfigurationManager.AppSettings["repositorio"];
        }
        public static Dominio.InterfacesRepositorio.IRepositorioAlojamientos
            CrearRepositorioAlojamiento()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepositorioAlojamientosSQL();
            else
                return null;
        }
        public static Dominio.InterfacesRepositorio.IRepositorioAnfitriones
            CrearRepositorioAnfitrion()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepositorioAnfitrionesSQL();
            else
                return null;
        }
        public static Dominio.InterfacesRepositorio.IRepositorioAnuncios
            CrearRepositorioAnuncio()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepositorioAnunciosSQL();
            else
                return null;
        }
        public static Dominio.InterfacesRepositorio.IRepositorioHabitaciones
            CrearRepositorioHabitacion()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepositorioHabitacionesSQL();
            else
                return null;
        }
        public static Dominio.InterfacesRepositorio.IRepositorioHuespedes
            CrearRepositorioHuesped()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepositorioHuespedesSQL();
            else
                return null;
        }

        //FALTA EL RESTO DE LOS METODOS PARA INICIALIZAR LOS REPOS 



        public static Dominio.InterfacesRepositorio.IRepositorioRangoPrecios
            CrearRepositorioRangoPrecio()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepositorioRangoPreciosSQL();
            else
                return null;
        }




        public static Dominio.InterfacesRepositorio.IRepositorioUbicaciones
            CrearRepositorioUbicacion()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepositorioUbicacionesSQL();
            else
                return null;
        }


    }
}
