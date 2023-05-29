using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Model
{
    public class Note
    {
        [JsonProperty("idNota")]
        public int IdNote { get; set; }
        [JsonProperty("titulo")]
        public string Title { get; set; }
        [JsonProperty("contenido")]
        public string Content { get; set; }
        [JsonProperty("tiempoCreacion")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("eliminado")]
        public bool Deleted { get; set; }
        [JsonProperty("idLibreta")]
        public int IdNotebook { get; set; }
        [JsonProperty("idPrioridad")]
        public int IdPriority { get; set; }
        [JsonProperty("idUsuario")]
        public int IdUser { get; set; }
    }
}
