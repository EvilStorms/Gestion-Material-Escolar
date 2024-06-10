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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        private DiInventario? diEntities;
        public Login()
        {
            if (ConectaBD())
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("ERROR!!! No hay comunicacion con la base de datos\n" + 
                    "Ponte en contacto con tu administrador de sistemas",
                    "ACCESO A LA BASE DE DATOS",MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            
        }
        private bool ConectaBD()
        {
            bool conecta = true;
            diEntities = new DiInventario();
            try
            {
                diEntities.Database.OpenConnection();
            }catch(Exception ex)
            {
                conecta = false;
            }
            return conecta;
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UsuarioServicio usuServ = new UsuarioServicio(diEntities);
            if (usuServ.login(txtNombreUsuario.Text,passClaveAcceso.Password))
            {

                MainWindow ventanaPrincipal = new MainWindow(diEntities,usuServ.usuLogin);
                ventanaPrincipal.Show();
                this.Close();
            }
            else if (txtNombreUsuario.Text == "" && passClaveAcceso.Password == "")
            {
                await this.ShowMessageAsync("LOGIN DEL USUARIO",
                    "No puede dejar los campos vacios\n" +
                    "Por favor revisalo");
            }
            else
            {
                await this.ShowMessageAsync("LOGIN DEL USUARIO", 
                    "Hay un problema con el usuario o la contraseña\n" + 
                    "Por favor revisalo");
            }
            
        }

        

        

        
    }
}
