using Accessibility;
using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;

namespace di.proyecto.clase._2023.MVVM
{
    public class MVModeloArticulo : MVBaseCRUD<Modeloarticulo>
    {
        private DiInventario diEntities;
        private ModeloArticuloServicio modServ;
        private TipoArticuloServicio tipoServ;
        private Modeloarticulo _modeloArticulo;
        private Tipoarticulo _tipoSeleccionado;
        private ListCollectionView listaAux;
        private string _nombreBuscado;
        //Lista que guarda los criterios que ha activado el usuario
        private List<Predicate<Modeloarticulo>> criterios;
        //Ahora definimos los criterios aspciados a los que se muestran en la interfaz
        //Criterio por tipo de articulo
        private Predicate<Modeloarticulo> criterioTipo;
        private Predicate<Modeloarticulo> criterioNombre;
        public MVModeloArticulo() { }

        public MVModeloArticulo(DiInventario ent) { 
            this.diEntities = ent;
            inicializa();
        }

        private void inicializa()
        {
            servicio= new ModeloArticuloServicio(diEntities);
            modServ = (ModeloArticuloServicio)servicio;
            tipoServ = new TipoArticuloServicio(diEntities);
            _modeloArticulo = new Modeloarticulo();
            listaAux = new ListCollectionView(modServ.GetAll);
            criterios = new List<Predicate<Modeloarticulo>>();
            inicializaCriterios();
        }

        private void inicializaCriterios()
        {
            criterioTipo = new Predicate<Modeloarticulo>(m => m.TipoNavigation != null && m.TipoNavigation.Equals(_tipoSeleccionado));
            criterioNombre = new Predicate<Modeloarticulo>(m => !string.IsNullOrEmpty(m.Nombre)
                && m.Nombre.ToUpper().StartsWith(nombreBuscado.ToUpper()));
        }

       public string nombreBuscado
       {
         get { return _nombreBuscado; }
         set { _nombreBuscado = value; NotifyPropertyChanged(nameof(nombreBuscado)); }
       }

        public Modeloarticulo modeloarticulo { get { return _modeloArticulo; } 
            set { _modeloArticulo = value; NotifyPropertyChanged(nameof(modeloarticulo)); }
        }

        public Tipoarticulo tipoSeleccionado { get { return _tipoSeleccionado; } 
            set { _tipoSeleccionado = value; NotifyPropertyChanged(nameof(tipoSeleccionado)); }
        }

        public List<Tipoarticulo> listaTipoArticulo { get{ return tipoServ.GetAll; } }

        public ListCollectionView listaModelos { get { return listaAux; } }


        public bool FiltroCombinadoCriterios(object item)
        {
            bool correcto = true;
            Modeloarticulo modelo = (Modeloarticulo)item;

            if (criterios.Count != 0)
            {
                correcto = criterios.TrueForAll(x => x(modelo));
            }

            return correcto;
        }

        private void addFiltros()
        {
            criterios.Clear();

            if (tipoSeleccionado != null)
            {
                criterios.Add(criterioTipo);
            }

            if(!string.IsNullOrEmpty(nombreBuscado)) { criterios.Add(criterioNombre); }
        }

        public void Filtrar()
        {
            addFiltros();
            listaAux.Filter = new Predicate<object>(FiltroCombinadoCriterios);
        }

        public void quitarFiltros()
        {
            listaAux.Filter = null;
        }

        public void Agrupar(string propiedad)
        {
            Agrupar(propiedad, listaModelos);
        }

        public void QuitarAgrupar()
        {
            QuitarAgrupar(listaModelos);
        }

        public Modeloarticulo modeloArticulo { get { return _modeloArticulo ; }
            set { _modeloArticulo = value; NotifyPropertyChanged(nameof(modeloArticulo));
            }
        }
        public bool Guardar()
        {
            return add(modeloArticulo);
        }
    }
}
