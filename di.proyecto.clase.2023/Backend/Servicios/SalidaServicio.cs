using di.proyecto.clase._2023.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    public class SalidaServicio : ServicioGenerico<Salida>
    {
        private DiInventario contexto;

        public SalidaServicio(DiInventario context) : base(context)
        {
            contexto = context;
        }

        public List<Salida> getSalidasUsuario(int usu)
        {
            return contexto.Set<Salida>().Where(s => s.Usuario == usu).ToList();
        }

        public void GetPrestamosPorCurso()
        {
            /*List<Tupla> lista = contexto.Database.SqlQuery<Tupla>("select year(fechasalida) as temporada, count(fechasalida) as prestamos " +
                "from salida group by year(fechasalida); ").ToList();*/
           

            //return query2.ToList();
        }

        public DateTime FechaFinal()
        {
            return contexto.Salida.OrderBy(f => f.Fechasalida).Reverse().FirstOrDefault().Fechasalida;
        }
        public DateTime FechaInicial()
        {
            return contexto.Salida.OrderBy(f => f.Fechasalida).FirstOrDefault().Fechasalida;
        }
    }
}
