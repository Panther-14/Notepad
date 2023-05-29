using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Model
{
    public class Priority
    {
        [JsonProperty("idPrioridad")]
        public int IdPriority { get; set; }
        [JsonProperty("nombre")]
        public string Name { get; set; }
    }
}
