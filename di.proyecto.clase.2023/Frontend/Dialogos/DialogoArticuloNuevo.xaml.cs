using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;


namespace di.proyecto.clase._2023.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoArticuloNuevo.xaml
    /// </summary>
    public partial class DialogoArticuloNuevo : MetroWindow
    {
        private DiInventario diEntities;
        private ArticuloServicio artServ;
        private DptoServicio DptoServ;
        private EspacioServicio EspacioServ;
        private ModeloArticuloServicio modeloArticuloServ;
        private UsuarioServicio UsuarioServ;
        private Usuario Usuario;
        private List<string> estado = new List<string>() {"Mantenimiento","Operativo","Descatalogado"};

        public DialogoArticuloNuevo()
        {
            InitializeComponent();
        }
        public DialogoArticuloNuevo(DiInventario diInventario, Usuario usuario)
        {
            InitializeComponent();
            this.diEntities = diInventario;
            this.Usuario = usuario;
            inicializa();
        }
        private void inicializa()
        {
            artServ = new ArticuloServicio(diEntities);
            DptoServ = new DptoServicio(diEntities);
            EspacioServ = new EspacioServicio(diEntities);
            modeloArticuloServ = new ModeloArticuloServicio(diEntities);
            UsuarioServ = new UsuarioServicio(diEntities);
            ComboUsuario.SelectedItem = Usuario;
            ComboUsuario.ItemsSource = UsuarioServ.GetAll;
            ComboEspacio.ItemsSource = EspacioServ.GetAll;
            ComboEstado.SelectedItem = "Operativo";
            ComboEstado.ItemsSource = estado;
            ComboModelo.ItemsSource = modeloArticuloServ.GetAll;
            ComboDepartamento.ItemsSource = DptoServ.GetAll;

        }

        

        private async void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Articulo artAux = recogeDatos();
            try
            {
                if (artServ.numserieUnico(artAux.Numserie))
                {
                    artServ.Add(artAux);
                    popCorrecto.IsOpen = true;
                    await Task.Delay(TimeSpan.FromSeconds(3));
                    this.Close();
                }
                else
                {
                    await this.ShowMessageAsync("GESTION DE ARTICULOS",
                        "CUIDADO!!! El número de serie ya esta en la base de datos");
                }
            }
            catch(DbUpdateException dbex) {
                System.Console.WriteLine(dbex.Message);
                System.Console.WriteLine(dbex.StackTrace);
                await this.ShowMessageAsync("GESTION ARTICULO", "ERROR!!! No se puede guardar el objeto" +
                    " en la base de datos");
            }
        }

        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  Articulo recogeDatos()
        {
            Articulo art = new Articulo();
            art.Idarticulo = artServ.getLastId() + 1;
            art.Modelo = ((Modeloarticulo)ComboModelo.SelectedItem).Idmodeloarticulo;
            art.Fechaalta = (DateTime)FechaAlta.SelectedDate;
            art.Estado = ComboEstado.SelectedItem.ToString();
            art.EspacioNavigation = (Espacio)ComboEspacio.SelectedItem;
            art.Numserie = txtNumSerie.Text;
            art.UsuarioaltaNavigation = (Usuario)ComboUsuario.SelectedItem;
            art.DepartamentoNavigation = (Departamento)ComboDepartamento.SelectedItem;
            art.Observaciones = txtObservaciones.Text;
            return art;

        }
    }
}
