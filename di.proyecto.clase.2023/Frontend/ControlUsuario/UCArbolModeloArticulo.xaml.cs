using di.proyecto.clase._2023.Backend.Modelo;
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
    /// Interaction logic for UCArbolModeloArticulo.xaml
    /// </summary>
    public partial class UCArbolModeloArticulo : UserControl
    {
        private DiInventario diEntities;
        private MVModeloArticulo mvModelo;
        public UCArbolModeloArticulo(DiInventario ent)
        {
            this.diEntities = ent;
            InitializeComponent();
            mvModelo = new MVModeloArticulo(ent);
            DataContext = mvModelo;
        }

        private void treeTipoArticulo_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(treeTipoArticulo.SelectedItem is Articulo) 
            { 
                dgPrestamos.ItemsSource = ((Articulo)treeTipoArticulo.SelectedItem).Salida;
            }
        }
    }
}
