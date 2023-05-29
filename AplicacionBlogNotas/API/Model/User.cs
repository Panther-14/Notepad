using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Model
{
    public class User
    {
        [JsonProperty("idUsuario")]
        public int IdUser { get; set; }
        [JsonProperty("nombres")]
        public string Name { get; set; }
        [JsonProperty("apellidos")]
        public string LastName { get; set; }
        [JsonProperty("tiempoRegistro")]
        public DateTime RegisterDate { get; set; }
        [JsonProperty("activo")]
        public int Status { get; set; }
        [JsonProperty("celular")]
        public string Phone { get; set; }
        [JsonProperty("contrasena")]
        public string Password { get; set; }
        [JsonProperty("ultimoTokenAcceso")]
        public string LstAccesToken { get; set; }
        [JsonProperty("tiempoUltimoAcceso")]
        public DateTime LastAccessDate { get; set; }
        [JsonProperty("otp")]
        public string TempPassword { get; set; }
        [JsonProperty("tiempoActivacion")]
        public DateTime ActivationDate { get; set; }


    }
}
