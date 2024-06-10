using di.proyecto.clase._2023.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    public class TipoArticuloServicio : ServicioGenerico<Tipoarticulo>
    {
        public TipoArticuloServicio(DiInventario context) : base(context)
        {
        }
    }
}
