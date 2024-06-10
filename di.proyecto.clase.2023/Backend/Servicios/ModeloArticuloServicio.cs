using di.proyecto.clase._2023.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    public class ModeloArticuloServicio : ServicioGenerico<Modeloarticulo>
    {
        private DiInventario contexto;

        public ModeloArticuloServicio(DiInventario context) : base(context)
        {
            contexto = context;
        }

        public List<Modeloarticulo> getModelosPorTipo (int tipo)
        {
            return contexto.Set<Modeloarticulo>().Where(m => m.Tipo == tipo).ToList();
        }
    }
}
