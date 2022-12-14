using System;
namespace TransConnect
{
	public class Client : Personne
	{
		//Collection de clients en mémoire = static List<Client> dans le main surement
		protected List<Commande> commande;

		public Client( string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, int portable,
            List<Commande> commande) : base(nom, prenom, naissance, adressePostale, adresseMail, portable)
        {
            this.commande = commande;
		}

		List<Commande> Commande
		{
			get { return commande; }
		}
	}
}

