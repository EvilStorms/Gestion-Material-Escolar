using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace di.proyecto.clase._2023.MVVM
{
    public class MVMArticuloNuevo : MVBaseCRUD<Articulo>
    {
        private DiInventario diEntities;
        private UsuarioServicio usuServ;
        private ModeloArticuloServicio modServ;
        private DptoServicio dptoServ;
        private ArticuloServicio artServ;
        private EspacioServicio espServ;
        private Articulo _articulo;
        private Usuario Usuario;
        private ListCollectionView listaAux;
        private List<string> estado = new List<string>() { "Mantenimiento", "Operativo", "Descatalogado" };

        public MVMArticuloNuevo() { }

        public MVMArticuloNuevo(DiInventario ent, Usuario usuario)
        {
            this.diEntities = ent;
            this.Usuario= usuario;
            inicializa();
        }
        public MVMArticuloNuevo(DiInventario ent)
        {
            this.diEntities = ent;
            inicializa();
        }

        private void inicializa()
        {
            modServ = new ModeloArticuloServicio(diEntities);
            servicio = new ArticuloServicio(diEntities);
            artServ = (ArticuloServicio)servicio;
            usuServ = new UsuarioServicio(diEntities);
            dptoServ = new DptoServicio(diEntities);
            espServ = new EspacioServicio(diEntities);
            listaAux = new ListCollectionView(artServ.GetAll);

            _articulo = new Articulo();
            _articulo.UsuarioaltaNavigation = Usuario;
            _articulo.Estado = "Operativo";

        }
        public ListCollectionView listaArticulos { get { return listaAux; } }

        public List<Usuario> listaUsuario { get { return usuServ.GetAll;  } }
        public List<Modeloarticulo> listaModeloArticulo { get { return modServ.GetAll; } }
        public List<Departamento> listaDepartamento { get { return dptoServ.GetAll; } }
        public List<Espacio> listaEspacio { get { return espServ.GetAll; } }

        public List<string> listaEstados { get { return estado; } }

        public Articulo articulo { get { return _articulo; }
            set { _articulo = value; NotifyPropertyChanged(nameof(articulo)); 
            }
        }
        public void Agrupar(string propiedad)
        {
            Agrupar(propiedad, listaArticulos);
        }

        public void QuitarAgrupar()
        {
            QuitarAgrupar(listaArticulos);
        }

        public bool numArtUnico { get { return artServ.numserieUnico(_articulo.Numserie); } }

        public bool Guardar()
        {
            articulo.Idarticulo = artServ.getLastId() + 1;

            return add(articulo);
        }
    }
}
