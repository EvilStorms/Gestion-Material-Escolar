using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.MVVM;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using System.Windows.Shapes;

namespace di.proyecto.clase._2023.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoModeloArticuloMVVM.xaml
    /// </summary>
    public partial class DialogoModeloArticuloMVVM : MetroWindow
    {
        private DiInventario diEntities;
        private MVModeloArticulo mvModeloArticulo;
        public DialogoModeloArticuloMVVM(DiInventario diEntities)
        {
            InitializeComponent();
            this.diEntities = diEntities;
            mvModeloArticulo = new MVModeloArticulo(diEntities);
            this.DataContext = mvModeloArticulo;

        }
        public DialogoModeloArticuloMVVM(DiInventario diEntities, Modeloarticulo modeloarticulo)
        {
            InitializeComponent();
            this.diEntities = diEntities;
            mvModeloArticulo = new MVModeloArticulo(diEntities);
            this.DataContext = mvModeloArticulo;
            mvModeloArticulo.modeloarticulo = modeloarticulo;

        }

        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (mvModeloArticulo.update(mvModeloArticulo.modeloarticulo))
            {
                await this.ShowMessageAsync("GESTION MODELO ARTICULO",
                   "TODO CORRECTO!!! Se guardo el objeto en la base de datos");
                DialogResult = true;
            }
            else
            {
                await this.ShowMessageAsync("GESTION MODELO ARTICULO", "ERROR!!! No se puede guardar el objeto" +
                    " en la base de datos");
            }
        }
    }
}
