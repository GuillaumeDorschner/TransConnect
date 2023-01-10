using System;

namespace TransConnect
{
    public class Commande
    {
        protected Client client;
        protected Livraison livraison;
        protected int prix;
        protected Vehicule vehicule;
        protected Salarie chauffeur;
        protected DateTime dateLivraison;

        public delegate float calculPrix();
        public delegate float tarif(Commande a);

        public Commande(Client client, Livraison livraison, Vehicule vehicule, Salarie chauffeur, DateTime dateLivraison)
        {
            if (chauffeur == null)
            {
                Console.WriteLine("Aucun chauffeur n'est disponible");
            }
            this.client = client;
            this.livraison = livraison;
            this.vehicule = vehicule;
            this.chauffeur = chauffeur;
            this.dateLivraison = dateLivraison;
            this.client.Commande.Enqueue(this);
            this.chauffeur.Commande.Enqueue(this);
            this.prix = (int)calculPrixCommande(this);

        }

        public Client Client
        {
            get { return client; }
        }

        public Livraison Livraison
        {
            get { return livraison; }
        }

        public int Prix
        {
            get { return prix; }
        }

        public Vehicule Vehicule
        {
            get { return vehicule; }
        }

        public Salarie Chauffeur
        {
            get { return chauffeur; }
        }

        public DateTime DateLivraison
        {
            get { return dateLivraison; }
        }

        public static double calculPrixCommande(Commande a)
        {
            double res = 0;
            res = a.Livraison.Distance / 3;
            res = res + a.Chauffeur.Anciennete();

            double type = 0;
            if (a.Vehicule.GetType() == typeof(Voiture)) type = 1;
            else if (a.Vehicule.GetType() == typeof(Camionnette)) type = 1.5;
            else type = 2;

            res = res * type;
            return res;
        }

        public double tarifFinal()
        {
            return calculPrixCommande(this);
        }

        public override string ToString()
        {
            return "Client : " + this.client.Nom + " " + this.client.Prenom + "\nLivraison : " + this.livraison.PointA + " - " + this.livraison.PointB + "\nPrix : " + this.prix + "€ \nVehicule : " + this.vehicule.ToString() + " \nChauffeur : " + this.chauffeur.Nom + " " + this.chauffeur.Prenom + " \nDate de livraison : " + this.dateLivraison;
        }

    }
}

