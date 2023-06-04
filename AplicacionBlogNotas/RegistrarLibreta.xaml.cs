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
    /// Lógica de interacción para RegistrarLibreta.xaml
    /// </summary>
    public partial class RegistrarLibreta : Window
    {
        public Notebook Notebook { get; set; }
        public int IdLibreta { get; set; }
        public bool IsUpdate { get; set; }

        public RegistrarLibreta()
        {
            InitializeComponent();
            IsUpdate = false;
            lbIncorrectFormat.Visibility = Visibility.Hidden;
        }

        public RegistrarLibreta(Notebook notebook, bool isUpdate)
        {
            InitializeComponent();
            Notebook = notebook;
            IsUpdate = isUpdate;
            LoadNotebook();
        }

        private async void LoadNotebook()
        {
            lbNotebookWindowTitle.Content = this.Title;
            tbNotebookTitle.Text = this.Notebook.Name;
            tbNotebookColor.Text = this.Notebook.HexadecimalColor;
            if (IsUpdate)
            {
                lbIncorrectFormat.Visibility = Visibility.Visible;
            }else
            {
                lbIncorrectFormat.Visibility = Visibility.Hidden;
            }
        }

        private async Task<Response> SaveChanges()
        {
            Response response;


            if (IsUpdate)
            {
                Notebook notebook = new Notebook()
                {
                    HexadecimalColor = this.Notebook.HexadecimalColor,
                    Name = this.Notebook.Name,
                    IdUser = this.Notebook.IdUser,
                    IdNotebook = this.Notebook.IdNotebook,
                };
                response = await NotebookService.Actualizar(notebook);
            }
            else
            {
                Notebook notebook = new Notebook()
                {
                    HexadecimalColor = this.Notebook.HexadecimalColor,
                    Name = this.Notebook.Name,
                    IdUser = this.Notebook.IdUser,
                    IdNotebook = this.Notebook.IdNotebook,
                };
                response = await NotebookService.Registrar(notebook);
            }

            return response;
        }


        private void ValidatarColor(object sender, TextCompositionEventArgs e)
        {
            
        }

        private async void BtnGuardar(object sender, RoutedEventArgs e)
        {
            string notebookTitle = tbNotebookTitle.Text;
            string notebookColor = tbNotebookColor.Text;

            if (!String.IsNullOrWhiteSpace(notebookTitle) && !String.IsNullOrWhiteSpace(notebookColor))
            {
                Response response = await SaveChanges();
                if (!response.Error)
                {
                    MessageBox.Show(response.Message, "Información", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Campos Vacios");
            }
        }

        private void BtnCancelar(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            pantallaPrincipal.Show();
            this.Close();
        }
    }
}
