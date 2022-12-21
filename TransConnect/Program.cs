using System;
using Newtonsoft.Json;

namespace TransConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // json to object
            string json = File.ReadAllText("../../../data.json");

            Salarie salarie = Newtonsoft.Json.JsonConvert.DeserializeObject<Salarie>(json);

            Organigramme Org = new Organigramme(salarie);
            Org.Afficher();

        }
    }
}