using System;
namespace TransConnect
{
    public abstract class Vehicule
    {
        protected Salarie chauffeur;
        protected string immatriculation;

        public Vehicule(Salarie chauffeur, string immatriculation)
        {
            this.chauffeur = chauffeur;
            this.immatriculation = immatriculation;
        }
    }
}
