using AplicacionBlogNotas.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Services
{
    public class PriorityService
    {
        private static readonly string CREDENTIALS = Properties.Settings.Default.Token;

        public static async Task<Response> Consultar()
        {
            Response response = await NotepadServices.NotepadRequestWithoutParams("auth/libreta", HttpMethod.Get, "Bearer", CREDENTIALS);
            return response;
        }

    }
}
