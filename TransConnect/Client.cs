using System;
namespace TransConnect
{
	public class Client : Personne , ITris
	{
		//Collection de clients en mémoire = static List<Client> dans le main surement
		protected List<Commande> commande;
		public delegate int typeDeTri();
		public delegate int Tri(Client a, Client b);

		public Client( string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, int portable,
            List<Commande> commande) : base(nom, prenom, naissance, adressePostale, adresseMail, portable)
        {
            this.commande = commande;
		}

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

		public int TriPrenomNom(Client a, Client b)
		{
			int x = a.Nom.CompareTo(b.Nom);
			if(x==0)
			{
				x = x + a.Prenom.CompareTo(b.Prenom);
			}
			return x;
		}

        public int TriVille(Client a, Client b)
        {
			return a.adressePostale.CompareTo(b.adressePostale);
        }

        public static int MontantAchatCumule(Client a, Client b)
        {
            return a.achatsCumule().CompareTo(b.achatsCumule());
        }

		public int typeDeTri1(Tri tri, Client a, Client b)
		{
			return tri(a, b);
		}

		

    }
}


