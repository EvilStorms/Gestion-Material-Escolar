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
    /// Interaction logic for NuevoArticuloMVVM.xaml
    /// </summary>
    public partial class DialogoArticuloNuevoMVVM : MetroWindow
    {
        private DiInventario diEntities;
        private MVMArticuloNuevo mvmArticuloNuevo;
        private Usuario _usuario;
        public DialogoArticuloNuevoMVVM(DiInventario diEntities, Usuario usuario)
        {
            InitializeComponent();
            this.diEntities = diEntities;
            mvmArticuloNuevo = new MVMArticuloNuevo(diEntities, usuario);
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvmArticuloNuevo.OnErrorEvent));
            this.DataContext = mvmArticuloNuevo;
            mvmArticuloNuevo.btnGuardar = BotonGuardar;
           
        }

        private async void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (mvmArticuloNuevo.IsValid(this))
            {
                if (mvmArticuloNuevo.numArtUnico)
                {
                    if (mvmArticuloNuevo.Guardar())
                    {
                        await this.ShowMessageAsync("GESTION ARTICULO",
                           "TODO CORRECTO!!! Se guardo el objeto en la base de datos");
                       
                        DialogResult = true;
                    }
                    else
                    {
                        await this.ShowMessageAsync("GESTION ARTICULO", "ERROR!!! No se puede guardar el objeto" +
                            " en la base de datos");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("GESTION ARTICULO", "ERROR!!! No se puede guardar el objeto" +
                            " en la base de datos");
                }
            }
            else
            {
                await this.ShowMessageAsync("GESTION ARTICULO", "ERROR!!! No se puede guardar el objeto" +
                            " en la base de datos");
            }
        }

        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = false;
        }
    }
}
