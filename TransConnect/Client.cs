using System;
namespace TransConnect
{
<<<<<<< Updated upstream
	public class Client : Personne , ITris
	{
		//Collection de clients en mémoire = static List<Client> dans le main surement
		protected List<Commande> commande;
		public delegate int typeDeTri();
		public delegate int Tri(Client a, Client b);
=======
    public class Client : Personne
    {
        //Collection de clients en mémoire = static List<Client> dans le main surement
        protected List<Commande> commande;
>>>>>>> Stashed changes

        public Client(string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, string portable,
            List<Commande> commande) : base(nom, prenom, naissance, adressePostale, adresseMail, portable)
        {
            this.commande = commande;
        }

<<<<<<< Updated upstream
		List<Commande> Commande
		{
			get { return commande; }
		}

		public int achatsCumule()
		{
			int sum = 0;
			foreach(Commande i in commande)
			{
				sum += i.Prix;
			}
			return sum;
		}

		public int Tri1(Client a, Client b)
		{
			int x = a.Nom.CompareTo(b.Nom);
			if(x==0)
			{
				x = x + a.Prenom.CompareTo(b.Prenom);
			}
			return x;
		}

        public int Tri2(Client a, Client b)
        {
			return a.adressePostale.CompareTo(b.adressePostale);
        }

        public static int Tri3(Client a, Client b)
        {
            return a.achatsCumule().CompareTo(b.achatsCumule());
        }

		public int typeDeTri1(Tri tri, Client a, Client b)
		{
			return tri(a, b);
		}
=======
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
>>>>>>> Stashed changes
    }
}


