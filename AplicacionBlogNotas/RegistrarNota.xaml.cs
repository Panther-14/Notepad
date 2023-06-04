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
    /// Lógica de interacción para RegistrarNota.xaml
    /// </summary>
    public partial class RegistrarNota : Window
    {
        public int IdLibreta { get; set; }
        public Note Note { get; set; }
        public bool IsUpdate { get; set; }

        public RegistrarNota()
        {
            InitializeComponent();
        }
        public RegistrarNota(int idLibreta, bool isUpdate)
        {
            InitializeComponent();
            Note = new Note()
            {
                Title = "",
                Content = ""
            };
            IdLibreta = idLibreta;
            Title = "Nueva Nota";
            IsUpdate = isUpdate;

            LoadNote();
        }

        public RegistrarNota(Note note, int idLibreta, string title, bool isUpdate)
        {
            InitializeComponent();
            Note = note;
            IdLibreta = idLibreta;
            Title = title;
            IsUpdate = isUpdate;
            LoadNote();
        }


        private async void LoadNote()
        {
            lbNoteWindowTitle.Content = this.Title;
            tbNoteTitle.Text = this.Note.Title;
            tbNoteContent.Text = this.Note.Content;
            cbPrioridad.Items.Clear();

            Response response = await PriorityService.Consultar();

            List<Priority> priorityList = response.Priorities;
            cbPrioridad.ItemsSource = priorityList;
            cbPrioridad.SelectedIndex = priorityList.FindIndex(p => p.IdPriority == Note.IdPriority );
        }

        private async Task<Response> SaveChanges()
        {
            string noteTitle = tbNoteTitle.Text;
            string noteContent = tbNoteContent.Text;
            int idNote = this.Note.IdNote;
            Response response;

            Priority priority = (Priority)cbPrioridad.SelectedItem;
            
            if (IsUpdate)
            {
                Note note = new Note()
                {
                    IdNote = idNote,
                    Title = noteTitle,
                    Content = noteContent,
                    IdPriority = priority.IdPriority,
                    IdUser = CurrentUser.Instance.IdUser,
                    IdNotebook = this.IdLibreta
                };
                response = await NoteService.Actualizar(note);
            }
            else
            {
                Note note = new Note()
                {
                    Title = noteTitle,
                    Content = noteContent,
                    IdPriority = priority.IdPriority,
                    IdUser = CurrentUser.Instance.IdUser,
                    IdNotebook = this.IdLibreta
                };
                response = await NoteService.Registrar(note);
            }

            return response;
        }

        private async void BtnGuardar(object sender, RoutedEventArgs e)
        {
            string noteTitle = tbNoteTitle.Text;
            string noteContent = tbNoteContent.Text;

            if (!String.IsNullOrWhiteSpace(noteTitle) && !String.IsNullOrWhiteSpace(noteContent) && this.IdLibreta > 0) {
                Response response = await SaveChanges();
                if (!response.Error) {
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
