using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
using di.proyecto.clase._2023.Frontend.Dialogos;
using di.proyecto.clase._2023.MVVM;
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

namespace di.proyecto.clase._2023.Frontend.ControlUsuario
{
    /// <summary>
    /// Interaction logic for UCModeloArticulo.xaml
    /// </summary>
    public partial class UCModeloArticulo : UserControl
    {
        private DiInventario diEntities;
        private MVModeloArticulo mvModelo;
        
        public UCModeloArticulo(DiInventario ent)
        {
            InitializeComponent();
            diEntities = ent;
            Initialize();
        }
        private void Initialize()
        {


            mvModelo = new MVModeloArticulo(diEntities);
            DataContext = mvModelo;
        }

        private void chkAgrupaMarca_Checked(object sender, RoutedEventArgs e)
        {
            mvModelo.Agrupar("Marca");
        }

        private void chkAgrupaMarca_Unchecked(object sender, RoutedEventArgs e)
        {
            if(chkAgrupaTipo.IsChecked == false) {
                mvModelo.QuitarAgrupar();
            }
            else
            {
                mvModelo.QuitarAgrupar();
                mvModelo.Agrupar("Tipo");
            }
            
        }

        private void comboFiltroTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvModelo.Filtrar();
        }


        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            DialogoModeloArticuloMVVM diag = new DialogoModeloArticuloMVVM(diEntities, (Modeloarticulo)dgModeloArticulo.SelectedItem);
            diag.ShowDialog();
            if ((bool)diag.DialogResult)
            {
                dgModeloArticulo.Items.Refresh();
            }
           
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkAgrupaTipo_Checked(object sender, RoutedEventArgs e)
        {
            mvModelo.Agrupar("Tipo");
        }

        private void chkAgrupaTipo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chkAgrupaMarca.IsChecked==false)
            {
                mvModelo.QuitarAgrupar();
            }
            else
            {
                mvModelo.QuitarAgrupar();
                mvModelo.Agrupar("Marca");
            }
            
        }

        private void quitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            mvModelo.quitarFiltros();
            comboFiltroTipo.SelectedItem = null;
            txtBuscador.Text = "";
        }

        private void txtBuscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvModelo.Filtrar();
        }
    }
}
