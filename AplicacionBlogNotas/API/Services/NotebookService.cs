using AplicacionBlogNotas.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Services
{
    public class NotebookService
    {
        private static readonly string CREDENTIALS = Properties.Settings.Default.Token;

        public static async Task<Response> Consultar(int idUsuario)
        {
            //TODO
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/libreta", HttpMethod.Get, "Bearer", CREDENTIALS, idUsuario);
            return response;
        }

        public static async Task<Response> Registrar(Notebook notebook)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/libreta/registrar", HttpMethod.Post, "Bearer", CREDENTIALS, notebook);
            return response;
        }

        public static async Task<Response> Actualizar(Notebook notebook)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/libreta/actualizar", HttpMethod.Put, "Bearer", CREDENTIALS, notebook);
            return response;
        }

        public static async Task<Response> Eliminar(int idNotebook, int idUser)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/libreta/actualizar", HttpMethod.Delete, "Bearer", CREDENTIALS, new { idLibreta = idNotebook, idUsuario = idUser });
            return response;
        }
    }
}
