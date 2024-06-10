using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
using di.proyecto.clase._2023.Frontend.ControlUsuario;
using di.proyecto.clase._2023.Frontend.Dialogos;
using di.proyecto.clase._2023.MVVM;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.proyecto.clase._2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private DiInventario diEntities;
        private Usuario usuario;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(DiInventario inv, Usuario usuLogin)
        {
            InitializeComponent();
            this.diEntities = inv;
            usuario = usuLogin;

        }
        private void cerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        private void ModeloArticuloNuevo_Click(object sender, RoutedEventArgs e)
        {
            DialogoModeloArticulo dialogo = new DialogoModeloArticulo(diEntities);
            dialogo.Show();
            
        }

        private void ArticuloNuevo_Click(object sender, RoutedEventArgs e)
        {
            DialogoArticuloNuevo dialogo = new DialogoArticuloNuevo(diEntities, usuario);
            dialogo.Show();
        }

        private void ModeloArticuloNuevoMVM_Click(object sender, RoutedEventArgs e)
        {
            DialogoModeloArticuloMVVM dialogo = new DialogoModeloArticuloMVVM(diEntities);
            dialogo.Show();
        }

        private void ArticuloNuevoMVVM_Click(object sender, RoutedEventArgs e)
        {
            DialogoArticuloNuevoMVVM dialogo = new DialogoArticuloNuevoMVVM(diEntities, usuario);
            dialogo.ShowDialog();
        }

        private void ListaModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            UCModeloArticulo uc = new UCModeloArticulo(diEntities);
            if(gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(uc);
        }

        private void ListaArticulo_Click(object sender, RoutedEventArgs e)
        {
            UCArticulo uc = new UCArticulo(diEntities);
            if(gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(uc);
        }

        private void TipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            UCArbolModeloArticulo uc = new UCArbolModeloArticulo(diEntities);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(uc);
        }

        private void ListaGrupos_Click(object sender, RoutedEventArgs e)
        {
            UCArbolUsuario uc = new UCArbolUsuario(diEntities);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(uc);
        }

        private void ListaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UCUsuario uc = new UCUsuario(diEntities);
            if (!gridCentral.Children.Contains(uc)) gridCentral.Children.Clear();
            gridCentral.Children.Add(uc);
        }
    }
}
