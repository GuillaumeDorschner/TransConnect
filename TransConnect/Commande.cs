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
            this.client = client;
            this.livraison = livraison;
            this.vehicule = vehicule;
            this.chauffeur = chauffeur;
            this.dateLivraison = dateLivraison;
            this.prix = (int)(calculPrixAnciennete(this));
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

        public static float calculPrixAnciennete(Commande a)
        {
            float res = 0;
            res = a.Livraison.Distance / 3;
            res =  res + (a.Chauffeur.Anciennete().Days ) * 50;
            return res;
        }

        public float tarifFinal()
        {
            return calculPrixAnciennete(this);
        }

    }
}

