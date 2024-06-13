using System;
using System.IO;
using CampusFrance;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CampusFrance
{
    // Cette classe est utilisée pour lire les données à partir d'un fichier JSON.
    public class ReadData
    {
        // Variable pour stocker le nom du fichier.
        public string file_name;
        // Variable pour stocker la chaîne JSON.
        public string jsonStr;
        // Variable pour stocker l'objet client désérialisé.
        public List<Client> clients;

        // Méthode pour lire les données à partir d'un fichier JSON et retourner un objet Client.
        public List<Client> ReadDataFromJson()
        {
            // Assignation du nom du fichier.
            file_name = @"C:\\Users\\chiha\\source\\repos\\CampusFrance\\CampusFrance\\DataCampus.json";

            // Utilisation d'un StreamReader pour lire le fichier.
            using (StreamReader r = new StreamReader(file_name))
            {
                // Lecture de tout le contenu du fichier dans jsonStr.
                jsonStr = r.ReadToEnd();
                // Désérialisation de la chaîne JSON en un objet Client.
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonStr);
            }
            // Retour de l'objet Client.
            return clients;
        }
    }
}
