using AplicacionBlogNotas.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Services
{
    public class NoteService
    {
        private static readonly string CREDENTIALS = Properties.Settings.Default.Token;

        public static async Task<Response> Consultar(int idUsuario)
        {
            Response response = await NotepadServices.NotepadRequestWithParams("auth/nota", HttpMethod.Get, "Bearer", CREDENTIALS, idUsuario);
            return response;
        }

        public static async Task<Response> Registrar(Note note)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/nota/registrar", HttpMethod.Post, "Bearer", CREDENTIALS, note);
            return response;
        }

        public static async Task<Response> Actualizar(Note note)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/nota/actualizar", HttpMethod.Put, "Bearer", CREDENTIALS, note);
            return response;
        }

        public static async Task<Response> Eliminar(int idNote, int idUser)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/note/actualizar", HttpMethod.Delete, "Bearer", CREDENTIALS, new { idNota = idNote, idUsuario = idUser });
            return response;
        }
    }
}
