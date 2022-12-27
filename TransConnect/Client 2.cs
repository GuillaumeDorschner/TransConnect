using System;
namespace TransConnect
{
    public class Client : Personne
    {
        //Collection de clients en mémoire = static List<Client> dans le main surement
        protected List<Commande> commande;

        public Client(string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, string portable,
            List<Commande> commande) : base(nom, prenom, naissance, adressePostale, adresseMail, portable)
        {
            this.commande = commande;
        }

        List<Commande> Commande
        {
            get { return commande; }
        }

        public static List<Client> FileToObj(string path)
        {
            List<Client> clients = new List<Client>();

            foreach (Client client in Newtonsoft.Json.JsonConvert.DeserializeObject<Client[]>(File.ReadAllText(path)))
                clients.Add(client);

            return clients;
        }

        public static void ObjToFile(List<Client> clients, string path)
        {
            File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(clients));
        }

        public override string ToString()
        {
            return base.ToString() + " " + commande;
        }
    }
}

