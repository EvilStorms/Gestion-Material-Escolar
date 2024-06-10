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
    public class MVUsuario : MVBaseCRUD<Usuario>
    {
        private DiInventario diEntities;
        private UsuarioServicio usuServ;
        private ListCollectionView listaAux;
        private ServicioGenerico<Tipousuario> tipoServ;
        private GrupoServicio grupoServ;
        private RolServicio rolServ;
        private SalidaServicio salidaServ;
        private DptoServicio dptoServ;

        public MVUsuario(DiInventario ent)
        {
            this.diEntities = ent;
            inicializa();
        }

        private void inicializa()
        {
            servicio = new UsuarioServicio(diEntities);
            usuServ = (UsuarioServicio) servicio;
            tipoServ = new ServicioGenerico<Tipousuario>(diEntities);
            grupoServ = new GrupoServicio(diEntities);
            rolServ = new RolServicio(diEntities);
            listaAux = new ListCollectionView(usuServ.GetAll);
            salidaServ = new SalidaServicio(diEntities);
            dptoServ = new DptoServicio(diEntities);
        }

        public ListCollectionView listaUsuarios { get { return listaAux; } }

        public List<Tipousuario> listaTipoUsuarios { get { return tipoServ.GetAll; } }

        public List<Grupo> listaGrupo { get { return grupoServ.GetAll; }}

        public List<Rol> listaRol { get { return rolServ.GetAll; }}

        public List<Salida> listaSalida { get {  return salidaServ.GetAll; }}

        public List<Departamento> listaDepartamento { get { return dptoServ.GetAll; }}

    }
}
