using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client json to client object
            List<Client> l1 = Client.FileToObj("../../../dataClient.json");

            Client test = new Client("Abril", "Aarrane", new DateTime(2015, 12, 31) , "19, place de Miremont 47300 VILLENEUVE-SUR-LOT", "pierre.dupond@gmail.com", "016391645",
            null);

            Client.Add(l1,test);
            Client.Delete(l1, "Margand");
            //Client.Modify(l1, "Authier");
            foreach (Client client in l1)
                Console.WriteLine(client);

            // client object to client json
            Client.ObjToFile(l1, "../../../testClient.json");

            // json to object
            string json = File.ReadAllText("../../../data.json");

            Salarie salarie = Newtonsoft.Json.JsonConvert.DeserializeObject<Salarie>(json);

            Organigramme Org = new Organigramme(salarie);
            //Org.Afficher();
            Salarie nouveau = new Salarie(1093847, "Grateau", "Valentin", new DateTime(2002,09,13), "Fresnes", "valentin.grateau@gmail.com", "0782082123", new DateTime(2014,07,20), "chauffeur",2000);
            Org.Add("Romu","Pierpont",nouveau);
            Org.Delete("Romi", "Chandler");

            Org.Afficher();

        }
    }
}