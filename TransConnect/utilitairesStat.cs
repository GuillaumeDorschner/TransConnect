using System;
using System.Text;

namespace TransConnect
{
	public class utilitairesStat
	{
		public utilitairesStat()
		{
		}

		static public void nombreLivraisons(Organigramme org,string chauffeurNom, string chauffeurPrenom)
		{
			Salarie chauffeur = org.Find(chauffeurNom, chauffeurPrenom);
			int cpt = 0;
			foreach(Commande i in chauffeur.Commande)
			{
				cpt++;
			}
			Console.WriteLine("Le nombre de livraisons pour le chauffeur : " + cpt);
		}

		static public void commandesPeriode(List<Commande> listCommande,DateTime start, DateTime stop)
        {
			foreach(Commande i in listCommande)
			{
				if((start <= i.DateLivraison) &&(i.DateLivraison <= stop))
				{
					Console.WriteLine(i.ToString());
				}
			}
        }

		static public void moyennePrixClient(Client client)
		{
			double res = 0;
			int cpt = 0;
			foreach(Commande i in client.Commande)
			{
				res += i.Prix;
				cpt++;
			}
			res = res / cpt;
			Console.WriteLine("La moyenne de prix des commande de " + client.Nom + " est : " + res);
		}

		static public void moyennePrix(List<Commande> listCommande)
		{
			double res = 0;
			int cpt = 0;
			foreach(Commande i in listCommande)
			{
				res = res + i.Prix;
				cpt++;
			}
			res = res / cpt;
            Console.WriteLine("La moyenne de prix des commande de la liste est : " + res);
        }

		static public void affichageCommandesClient(Client client)
		{
			foreach(Commande i in client.Commande)
			{
				Console.WriteLine(i.ToString());
			}
		}

    }
}

