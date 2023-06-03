using AplicacionBlogNotas.API.Model;
using AplicacionBlogNotas.API.Services;
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
using System.Xml.Linq;

namespace AplicacionBlogNotas
{
    /// <summary>
    /// Lógica de interacción para ActivarUsuario.xaml
    /// </summary>
    public partial class ActivarUsuario : Window
    {
        public ActivarUsuario()
        {
            InitializeComponent();
        }

        private async void btnAceptar(object sender, RoutedEventArgs e)
        {
            string phone = tbCellphoneNumber.Text;
            string password = tbOneTimePassword.Text;

            if(!String.IsNullOrWhiteSpace(phone) || !String.IsNullOrWhiteSpace(password))
            {
                Response response = await AccessService.Activar(phone, password);

                if (!response.Error)
                {
                    MessageBox.Show("Registro exitoso", "Información", MessageBoxButton.OK);

                    MainWindow mainWindow = new MainWindow()
                    {
                        WindowState = this.WindowState,
                        Left = this.Left
                    };
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButton.OK);
                }
            }else
            {
                MessageBox.Show("Error: Campos Vacios");
            }
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            mainWindow.Show();
            this.Close();
        }
    }
}
