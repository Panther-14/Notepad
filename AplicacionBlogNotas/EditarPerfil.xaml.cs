using AplicacionBlogNotas.API.Model;
using AplicacionBlogNotas.API.Services;
using AplicacionBlogNotas.Singleton;
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

namespace AplicacionBlogNotas
{
    /// <summary>
    /// Lógica de interacción para EditarPerfil.xaml
    /// </summary>
    public partial class EditarPerfil : Window
    {
        public EditarPerfil()
        {
            InitializeComponent();
            tbName.Text = CurrentUser.Instance.Name;
            tbApellidos.Text = CurrentUser.Instance.LastName;
        }

        private async void BtnAceptar(object sender, RoutedEventArgs e)
        {
            string nombre = tbName.Text;
            string apellidos = tbApellidos.Text;
            string contrasena = pbPassword.Password;
            if (!String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellidos) && !String.IsNullOrWhiteSpace(contrasena)) {
                if(!CurrentUser.Instance.Name.Equals(nombre) || !CurrentUser.Instance.LastName.Equals(apellidos) || !CurrentUser.Instance.Password.Equals(contrasena)) { }
                User user = new User()
                {
                    Name = nombre,
                    LastName = apellidos,
                    Password = contrasena
                };
                Response response = await UserService.Actualizar(user);
                if (!response.Error)
                {
                    MessageBox.Show(response.Message, "Información", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButton.OK);
                }
            }
        }

        private void BtnCancelar(object sender, RoutedEventArgs e)
        {

        }
    }
}
