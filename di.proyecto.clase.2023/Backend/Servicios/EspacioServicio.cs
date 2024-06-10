using di.proyecto.clase._2023.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    public class EspacioServicio : ServicioGenerico<Espacio>
    {
        public EspacioServicio(DiInventario context) : base(context)
        {
        }
    }
}
