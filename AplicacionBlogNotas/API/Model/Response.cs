using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.API.Model
{
    public class Response
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("error")]
        public bool Error { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
        [JsonProperty("notes")]
        public List<Note>? Notes { get; set; }
        [JsonProperty("notebooks")]
        public List<Notebook>? Notebooks { get; set; }
        [JsonProperty("priorities")]
        public List<Priority>? Priorities { get; set; }
        [JsonProperty("user")]
        public User? User { get; set; }
        [JsonProperty("affectedRows")]
        public int? AffectedRows { get; set; }

    }
}
