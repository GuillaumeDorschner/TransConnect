using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// client json to client object
            //List<Client> l1 = Client.FileToObj("../../../data/dataClient.json");

            //Client test = new Client("Abril", "Aarrane", new DateTime(2015, 12, 31), "19, place de Miremont 47300 VILLENEUVE-SUR-LOT", "pierre.dupond@gmail.com", "016391645",
            //null);

            //Client.Add(l1, test);
            //Client.Delete(l1, "Margand");
            //foreach (Client client in l1)
            //    Console.WriteLine(client);

            //// client object to client json
            //Client.ObjToFile(l1, "../../../data/testClient.json");

            // json to object
            string json = File.ReadAllText("../../../data/data.json");

            Salarie salarie = Newtonsoft.Json.JsonConvert.DeserializeObject<Salarie>(json);

            Organigramme Org = new Organigramme(salarie);
            Org.Afficher();


            // graph des villes
            Graph graph = new Graph("../../../data/distances.csv");

            var path = graph.ShortestPath("Lyon", "Rouen");

            Console.WriteLine("Shortest path : " + string.Join(" -> ", path.Item1));
        }
    }
}