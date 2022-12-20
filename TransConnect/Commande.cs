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


        public Commande(Client client, Livraison livraison, int prix, Vehicule vehicule, Salarie chauffeur, DateTime dateLivraison)
        {
            this.client = client;
            this.livraison = livraison;
            this.prix = prix;
            this.vehicule = vehicule;
            this.chauffeur = chauffeur;
            this.dateLivraison = dateLivraison;
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
    }
}

