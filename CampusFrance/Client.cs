using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CampusFrance
{
    public class Client
    {
        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("Motdepass")]
        public string Motdepass { get; set; }

        [JsonProperty("confMotPasse")]
        public string confMotPasse { get; set; }

        [JsonProperty("Nom")]
        public string Nom { get; set; }

        [JsonProperty("Prénom")]
        public string Prénom { get; set; }

        [JsonProperty("PaysNationnalité")]
        public string PaysdeNationalité { get; set; }

        [JsonProperty("Codepostal")]
        public string Codepostal { get; set; }

        [JsonProperty("Ville")]
        public string? Ville { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [JsonProperty("Institution")]
        public Institution? Institution { get; set; }
    }

    public class Institution
    {
        [JsonProperty("Fonction")]
        public string? Fonction { get; set; }

        [JsonProperty("NomdeLorganisation" +
            "")]
        public string NomdeLorganisation { get; set; }
    }
}
