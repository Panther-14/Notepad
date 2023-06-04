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

namespace AplicacionBlogNotas
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        private async void btnAceptar(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string paternalSurname = tbPaternalSurname.Text;
            string maternalSurname = tbMaternalSurname.Text;
            string cellphoneNumber = tbCellphoneNumber.Text;
            string password = pbPassword.Password;
            if (!String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(paternalSurname) && !String.IsNullOrWhiteSpace(maternalSurname) 
                && !String.IsNullOrWhiteSpace(cellphoneNumber) && !String.IsNullOrWhiteSpace(password)) {
                var user = new User()
                {
                    Name = name,
                    LastName = $"{paternalSurname} {maternalSurname}",
                    Phone = cellphoneNumber,
                    Password = password
                };
                Response response = await AccessService.Registrar(user);
                if (!response.Error)
                {
                    MessageBox.Show("Registro exitoso","Información",MessageBoxButton.OK);
                    
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
            }
            else
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
