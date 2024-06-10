using di.proyecto.clase._2023.Backend.Modelo;
using di.proyecto.clase._2023.Backend.Servicios;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for DialogoModeloArticulo.xaml
    /// </summary>
    public partial class DialogoModeloArticulo : MetroWindow
    {
        private DiInventario diEntities;
        private TipoArticuloServicio tipoServ;
        private ModeloArticuloServicio modeloServ;
        public DialogoModeloArticulo()
        {
            InitializeComponent();
        }

        public DialogoModeloArticulo(DiInventario inv)
        {
            InitializeComponent();
            this.diEntities = inv;
            inicializa();
        }
        private void inicializa()
        {
            tipoServ = new TipoArticuloServicio(diEntities);
            modeloServ = new ModeloArticuloServicio(diEntities);
            comboTipoArticulo.ItemsSource = tipoServ.GetAll;
        }

        private async void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                await this.ShowMessageAsync("GESTION MODELO ARTICULO",
                    "TODO CORRECTO!!! Se guardo el objeto en la base de datos");
                this.Close();

            }
            catch (DbUpdateException dbex) 
            { 
                System.Console.WriteLine(dbex.Message);
                System.Console.WriteLine(dbex.StackTrace);
                await this.ShowMessageAsync("GESTION MODELO ARTICULO", "ERROR!!! No se puede guardar el objeto" +
                    " en la base de datos");
            }
            
        }

        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private Modeloarticulo recogeDatos()
        {
            Modeloarticulo modelo = new Modeloarticulo();
            modelo.Nombre = txtNombre.Text;
            modelo.Marca = txtMarca.Text;
            modelo.Modelo = txtModelo.Text;
            modelo.Descripcion = txtDescripcion.Text;
            modelo.TipoNavigation = (Tipoarticulo)comboTipoArticulo.SelectedItem;
            return modelo;
        }
    }
}
