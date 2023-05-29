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
            if (!string.IsNullOrEmpty(userNumber) && !string.IsNullOrEmpty(password))
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

                    MessageBox.Show($"Hola!!!: {user.Name}");
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

        }
    }
}
