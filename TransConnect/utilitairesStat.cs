using System;
using System.Text;

namespace TransConnect
{
	public class utilitairesStat
	{
		public utilitairesStat()
		{
		}

		/// <summary>
		/// Affiche le nombre de livraisons par chauffeur
		/// </summary>
		/// <param name="org"></param>
		/// <param name="chauffeurNom"></param>
		/// <param name="chauffeurPrenom"></param>
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

		/// <summary>
		/// Affiche toutes les commandes pendant une durée de temps
		/// </summary>
		/// <param name="listCommande"></param>
		/// <param name="start"></param>
		/// <param name="stop"></param>
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

		/// <summary>
		/// Moyenne des prix des commandes concernant un client
		/// </summary>
		/// <param name="client"></param>
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

		/// <summary>
		/// Moyenne des prix de toutes les commandes de tous les clients
		/// </summary>
		/// <param name="listCommande"></param>
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

		/// <summary>
		/// Affichage de toutes les commandes de tous les clients
		/// </summary>
		/// <param name="client"></param>
		static public void affichageCommandesClient(Client client)
		{
			foreach(Commande i in client.Commande)
			{
				Console.WriteLine(i.ToString());
			}
		}

    }
}

