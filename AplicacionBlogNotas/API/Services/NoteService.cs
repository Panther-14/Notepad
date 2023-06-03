using AplicacionBlogNotas.API.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AplicacionBlogNotas.API.Services
{
    public class NoteService
    {
        private static readonly string CREDENTIALS = Properties.Settings.Default.Token;

        public static async Task<Response> Consultar(int idUsuario, int idLibreta = -255 , int idPrioridad = -255)
        {
            Response response;

            if (idLibreta != -255 && idPrioridad != -255)
            {
                response = await NotepadServices.NotepadRequestWithoutParams("auth/nota/consultar", HttpMethod.Get, "Bearer", CREDENTIALS, new { idUsuario, idLibreta, idPrioridad });
            }else if (idLibreta != -255 && idPrioridad == -255)
            {
                response = await NotepadServices.NotepadRequestWithoutParams("auth/nota/consultar", HttpMethod.Get, "Bearer", CREDENTIALS, new { idUsuario, idLibreta });
            }else if (idLibreta == -255 && idPrioridad != -255)
            {
                response = await NotepadServices.NotepadRequestWithoutParams("auth/nota/consultar", HttpMethod.Get, "Bearer", CREDENTIALS, new { idUsuario, idPrioridad });
            }
            else
            {
                response = await NotepadServices.NotepadRequestWithoutParams("auth/nota/consultar", HttpMethod.Get, "Bearer", CREDENTIALS, new { idUsuario });
            }
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
