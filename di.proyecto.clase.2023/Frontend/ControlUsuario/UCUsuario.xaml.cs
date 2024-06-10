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
    /// Interaction logic for UCUsuario.xaml
    /// </summary>
    public partial class UCUsuario : UserControl
    {
        private DiInventario diEntities;
        private MVUsuario mvUsuario;

        public UCUsuario(DiInventario ent)
        {
            InitializeComponent();
            diEntities = ent;
            Initialize();
        }

        private void Initialize()
        {
            mvUsuario = new MVUsuario(diEntities);
            DataContext = mvUsuario;
        }
    }
}
