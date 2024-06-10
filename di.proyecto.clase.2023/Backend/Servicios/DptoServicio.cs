
using di.proyecto.clase._2023.Backend.Modelo;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    public class DptoServicio : ServicioGenerico<Departamento>
    {

        public DptoServicio(DiInventario context) : base(context)
        {
        }
    }
}
