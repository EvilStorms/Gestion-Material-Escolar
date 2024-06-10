using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace di.proyecto.clase._2023.MVVM
{
    public class MVBase : PropertyChangedDataError
    {
        /// <summary>
        /// Botón del formulario que queremos que se active/desactive en función
        /// de si hay errores en la validación de los campos
        /// </summary>
        public Button btnGuardar { get; set; }
        /// <summary>
        /// Variable que llev la cuenta de los errores que hay en el formulario
        /// </summary>
        private int errorCount;

        // Añade métodos que nos ayudan en la validación -------------------------------------------------------------------------------
        /// <summary>
        /// Método que nos permite saber si hay errores en algún formulario
        /// </summary>
        /// <param name="obj">Ventana o panel que contiene los controles del formulario que queremos comprobar</param>
        /// <returns>n caso de que haya errores devolverá el valor de falso y en caso de que no haya devolverá verdadero</returns>
        public bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }

        /// <summary>
        /// Deshabilita el botón de guardar si hay errores en el formulario
        /// Si no hay errores habilitará el botón.
        /// se trata de un manejador de eventos. El framework, cada vez que se produce un error de validación
        /// en el formulario lanza un evento que manejamos en este procedimiento
        /// </summary>
        /// <param name="sender">Control que produce el error de validación</param>
        /// <param name="e">Parámetros del error</param>
        public void OnErrorEvent(object sender, RoutedEventArgs e)
        {
            var validationEventArgs = e as ValidationErrorEventArgs;
            if (validationEventArgs == null)
                throw new Exception("Argumentos inesperados");
            switch (validationEventArgs.Action)
            {
                case ValidationErrorEventAction.Added:
                    {
                        errorCount++; break;
                    }
                case ValidationErrorEventAction.Removed:
                    {
                        errorCount--; break;
                    }
                default:
                    {
                        throw new Exception("Acción desconocida");
                    }
            }
            btnGuardar.IsEnabled = errorCount == 0;
        }

    }
}
