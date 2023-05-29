using AplicacionBlogNotas.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Services
{
    public class UserService
    {
        private static readonly string CREDENTIALS = Properties.Settings.Default.Token;

        public static async Task<Response> Actualizar(User user)
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/usuario/actualizar", HttpMethod.Put, "Bearer", CREDENTIALS, user);
            return response;
        }
    }
}
