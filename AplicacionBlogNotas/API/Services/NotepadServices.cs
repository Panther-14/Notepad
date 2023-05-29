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
    public static class NotepadServices
    {
        private static readonly string URL = Properties.Settings.Default.Url;
        public static async Task<Response> NotepadRequestWithoutParams(string endpoint, HttpMethod httpMethod, string authMethod, string credentials, params object[] arguments)
        {
            string url = string.Concat(URL, endpoint);
            Response response = new Response();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authMethod, credentials);

                var rquestContent = new StringContent(JsonConvert.SerializeObject(arguments[0]), Encoding.UTF8, "application/json");

                try
                {
                    var httpRequestMessage = new HttpRequestMessage()
                    {
                        Content = rquestContent,
                        Method = httpMethod,
                        RequestUri = new Uri(url)
                    };
                    httpRequestMessage.Headers.Add("Origin", Properties.Settings.Default.Origin);
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                    if (httpResponseMessage != null)
                    {
                        string content = await httpResponseMessage.Content.ReadAsStringAsync();
                        MessageBox.Show(content);
                        response = JsonConvert.DeserializeObject<Response>(content);
                        if (response == null)
                        {
                            response.Error = true;
                            response.Message = "ERROR AL DESERIALIZAR JSON";
                        }
                    }
                    else
                    {
                        response.Error = true;
                        response.Message = "SIN CONEXIÓN CON EL SERVICIO";
                    }
                }
                catch (Exception exception)
                {
                    response.Error = true;
                    response.Message = exception.Message;
                }
            }
            return response;
        }

        public static async Task<Response> NotepadRequestWithParams(string endpoint, HttpMethod httpMethod, string authMethod, string credentials, params object[] arguments)
        {
            string url = string.Concat(URL, endpoint, "/", arguments[0]);
            Response response = new Response();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authMethod, credentials);

                try
                {
                    var httpRequestMessage = new HttpRequestMessage()
                    {
                        Method = httpMethod,
                        RequestUri = new Uri(url)
                    };
                    httpRequestMessage.Headers.Add("Origin", Properties.Settings.Default.Origin);
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                    if (httpResponseMessage != null)
                    {
                        string content = await httpResponseMessage.Content.ReadAsStringAsync();
                        MessageBox.Show(content);
                        response = JsonConvert.DeserializeObject<Response>(content);
                        if (response == null)
                        {
                            response.Error = true;
                            response.Message = "ERROR AL DESERIALIZAR JSON";
                        }
                    }
                    else
                    {
                        response.Error = true;
                        response.Message = "SIN CONEXIÓN CON EL SERVICIO";
                    }
                }
                catch (Exception exception)
                {
                    response.Error = true;
                    response.Message = exception.Message;
                }
            }
            return response;
        }
    }
}
