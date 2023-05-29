using AplicacionBlogNotas.API.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AplicacionBlogNotas.API.Services
{
    public class AccessService
    {
        private static readonly string CREDENTIALS = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Properties.Settings.Default.Username}:{Properties.Settings.Default.Password}"));

        public static async Task<Response> Login(User user)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("basic/acceso/login", HttpMethod.Post, "Basic", CREDENTIALS, user);
            return response;
        }

        public static async Task<Response> Registrar(User user)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("basic/acceso/registro", HttpMethod.Post, "Basic", CREDENTIALS, user);
            return response;
        }

        public static async Task<Response> Activar(string phone, string tempPassword)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("basic/acceso/activar", HttpMethod.Post, "Basic", CREDENTIALS, new { celular = phone, otp = tempPassword });
            return response;
        }
    }
}
