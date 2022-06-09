using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenXamarinAMH.Models
{
    public class Personaje
    {
        [JsonProperty("idPersonaje")]
        public int IdPersonaje { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int IdSerie { get; set; }

    }
}
