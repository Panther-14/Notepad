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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicacionBlogNotas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnLogin(object sender, RoutedEventArgs e)
        {
            string userNumber = tbUser.Text;
            string password = pbPassword.Password;
            if (!String.IsNullOrWhiteSpace(userNumber) && !String.IsNullOrWhiteSpace(password))
            {
                User user = new User()
                {
                    Phone = userNumber,
                    Password = password
                };
                Response response = await AccessService.Login(user);
                if (!response.Error)
                {
                    user = response.User;
                    Properties.Settings.Default.Token = response.Token;
                    Properties.Settings.Default.Save();


                    CurrentUser.Instance.Token = response.Token;
                    CurrentUser.Instance.ActivationDate = user.ActivationDate;
                    CurrentUser.Instance.LastAccessDate = user.LastAccessDate;
                    CurrentUser.Instance.Status = user.Status;
                    CurrentUser.Instance.TempPassword = user.TempPassword;
                    CurrentUser.Instance.Password = user.Password;
                    CurrentUser.Instance.IdUser = user.IdUser;
                    CurrentUser.Instance.LastName = user.LastName;
                    CurrentUser.Instance.LstAccesToken = user.LstAccesToken;
                    CurrentUser.Instance.Name = user.Name;
                    CurrentUser.Instance.Phone = user.Phone;
                    CurrentUser.Instance.RegisterDate = user.RegisterDate;

                    PantallaPrincipal pantalla = new PantallaPrincipal()
                    {
                        WindowState = this.WindowState,
                        Left = this.Left
                    };
                    pantalla.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Campos Vacios");
            }

        }

        private void lbSignIn(object sender, MouseButtonEventArgs e)
        {
            Registro registro = new Registro()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            registro.Show();
            this.Close();
        }

        private void btnActivar(object sender, RoutedEventArgs e)
        {
            ActivarUsuario activarUsuario = new ActivarUsuario()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            activarUsuario.Show();
            this.Close();
        }
    }
}
