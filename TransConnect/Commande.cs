using System;

namespace TransConnect
{
    public class Commande 
    {
        protected Client client;
        protected string destinationA;
        protected string destinationB;
        protected int prix;
        protected Vehicule vehicule;
        protected Salarie chauffeur;
        protected DateTime dateLivraison;


        public Commande(Client client, string destinationA, int prix, Vehicule vehicule, Salarie chauffeur, DateTime dateLivraison)
        {
            this.client = client;
            this.destinationA = destinationA;
            this.prix = prix;
            this.vehicule = vehicule;
            this.chauffeur = chauffeur;
            this.dateLivraison = dateLivraison;
        }
    }
}

