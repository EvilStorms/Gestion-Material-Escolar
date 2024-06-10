using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
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
    /// Interaction logic for UCArticulo.xaml
    /// </summary>
    public partial class UCArticulo : UserControl
    {
        private DiInventario diEntities;
        private MVMArticuloNuevo mvArticulo;
        public UCArticulo(DiInventario ent)
        {
            InitializeComponent();
            diEntities = ent;
            Initialize();
        }
        private void Initialize()
        {
            mvArticulo = new MVMArticuloNuevo(diEntities);
            DataContext = mvArticulo;
        }

        private void chkAgrupaEspacio_Checked(object sender, RoutedEventArgs e)
        {
            mvArticulo.Agrupar("Espacio");
            
        }

        private void chkAgrupaEspacio_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chkAgrupaModeloArt.IsChecked == false)
            {
                mvArticulo.QuitarAgrupar();
            }
            else
            {
                mvArticulo.QuitarAgrupar();
                mvArticulo.Agrupar("Modelo");
            }
        }

        private void chkAgrupaModeloArt_Checked(object sender, RoutedEventArgs e)
        {
            mvArticulo.Agrupar("Modelo");
        }

        private void chkAgrupaModeloArt_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chkAgrupaEspacio.IsChecked == false)
            {
                mvArticulo.QuitarAgrupar();
            }
            else
            {
                mvArticulo.QuitarAgrupar();
                mvArticulo.Agrupar("Espacio");
            }
        }
    }
}
