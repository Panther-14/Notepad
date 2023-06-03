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
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal : Window
    {
        private List <Notebook > notebooks = new List<Notebook>();
        private List<Note> notes = new List<Note>();

        public PantallaPrincipal()
        {
            InitializeComponent();
            LoadWindow();
        }

        private async void LoadWindow()
        {
            Response responseNotebooks = await NotebookService.Consultar(CurrentUser.Instance.IdUser);

            notebooks = responseNotebooks.Notebooks;

            lbCarpetas.Items.Clear();
            lbNotas.Items.Clear();

            lbCarpetas.ItemsSource = notebooks;

        }

        private void ActualizarPerfilUsuario(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrarLibreta(object sender, RoutedEventArgs e)
        {

        }

        private void ActualizarLibreta(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarLibreta(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrarNota(object sender, RoutedEventArgs e)
        {

        }

        private void ActualizarNota(object sender, RoutedEventArgs e)
        {

        }

        private async void EliminarNota(object sender, RoutedEventArgs e)
        {
            if(lbNotas.SelectedItem != null)
            {
                Note selectedNote = (Note)lbNotas.SelectedItem;

                Response response = await NoteService.Eliminar(selectedNote.IdNote, CurrentUser.Instance.IdUser);

                if (!response.Error)
                {
                    MessageBox.Show(response.Message, "Información", MessageBoxButton.OK);

                    notes.Remove(selectedNote);
                    lbNotas.ItemsSource = notes;
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButton.OK);
                }
            }
        }

        private void CerrarSesion(object sender, RoutedEventArgs e)
        {
            CurrentUser.Instance.KillInstance();

            MainWindow mainWindow = new MainWindow()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            mainWindow.Show();
            this.Close();
        }

        private async void ObjetoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            if(lbCarpetas.SelectedItem != null)
            {
                Notebook selectedNotebook = (Notebook)lbCarpetas.SelectedItem;

                Response responseNotes = await NoteService.Consultar(CurrentUser.Instance.IdUser, selectedNotebook.IdNotebook);
                notes = responseNotes.Notes;
                lbNotas.ItemsSource = notes;
            }
        }
    }
}
