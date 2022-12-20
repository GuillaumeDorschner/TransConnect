using System;
using Newtonsoft.Json;

namespace TransConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client json to client object
            List<Client> l1 = Client.FileToObj("../../../dataClient.json");

            foreach (Client client in l1)
                Console.WriteLine(client);

            // client object to client json
            Client.ObjToFile(l1, "../../../testClient.json");

            // json to object
            string json = File.ReadAllText("../../../data.json");

            Salarie salarie = Newtonsoft.Json.JsonConvert.DeserializeObject<Salarie>(json);

            Organigramme Org = new Organigramme(salarie);
            Org.Afficher();
        }
    }
}