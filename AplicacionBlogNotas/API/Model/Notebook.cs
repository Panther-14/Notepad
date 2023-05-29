using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Model
{
    public class Notebook
    {
        [JsonProperty("idLibreta")]
        public int IdNotebook { get; set; }
        [JsonProperty("nombre")]
        public string Name { get; set; }
        [JsonProperty("colorHexadecimal")]
        public string HexadecimalColor { get; set; }
        [JsonProperty("idUsuario")]
        public int IdUser { get; set; }
    }
}
