using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    /*
     * Clase que contiene las reglas de negocio de la clase Articulo
     */
    public class ArticuloServicio : ServicioGenerico<Articulo>
    {
        private DiInventario contexto;

        /*
         * Constructor
         */
        public ArticuloServicio(DiInventario context) : base(context)
        {
            contexto = context;
        }

        /*
         * Obtiene el último id de la tabla articulo
         * La clave primaria no es autoincrementable y debemos gestionarla nosotros
         */
        public int getLastId()
        {
            int id = 0;
            Articulo art = contexto.Set<Articulo>().OrderByDescending(a => a.Idarticulo).FirstOrDefault();
            if (art != null) { id = art.Idarticulo; }
            return id;
        }
        /*
         * Devuelve true en caso de que el número de serie no se encuentre en la base de datos
         * Devuelve false en caso de que el número de serie ya exista
         */
        public bool numserieUnico(string serie)
        {
            bool unico = true;
            if (contexto.Set<Articulo>().Where(a => a.Numserie == serie).Count() > 0)
            {
                unico = false;
            }
            return unico;
        }

        public DateTime getFechaInicial()
        {
            Articulo art = contexto.Set<Articulo>().OrderBy(a => a.Fechaalta).FirstOrDefault();
            return (DateTime)art.Fechaalta;
        }

        public DateTime getFechaFinal()
        {
            Articulo art = contexto.Set<Articulo>().OrderByDescending(a => a.Fechaalta).FirstOrDefault();
            return (DateTime)art.Fechaalta;
        }
    }
}
