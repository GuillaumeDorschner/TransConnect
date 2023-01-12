using System;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace TransConnect
{
    public class Salarie : Personne
    {
        protected long numeroSS;
        protected DateTime arrivee;
        protected string poste;
        protected int salaire;
        protected Salarie frere;
        protected Salarie enfant;
        protected Queue<Commande> commande;

        public Salarie(long numeroSS, string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, string portable,
            DateTime arrivee, string poste, int salaire) : base(nom, prenom, naissance, adressePostale, adresseMail, portable)
        {
            this.numeroSS = numeroSS;
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adressePostale = adressePostale;
            this.adresseMail = adresseMail;
            this.portable = portable;
            this.arrivee = arrivee;
            this.poste = poste;
            this.salaire = salaire;
            this.commande = new Queue<Commande>();
        }

        public Queue<Commande> Commande
        {
            get { return commande; }
            set { commande = value; }
        }

        public override string ToString()
        {
            string titre = ((int)(numeroSS.ToString()[0]) - 48 == 1) ? "Mr" : "Mme";

            return $"{titre}  {nom} {prenom} / {poste}";
        }

        public long NumeroSS
        {
            get { return numeroSS; }
        }

        public DateTime Arrivee
        {
            get { return arrivee; }
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public int Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public Salarie Frere
        {
            get { return frere; }
            set { frere = value; }
        }

        public Salarie Enfant
        {
            get { return enfant; }
            set { enfant = value; }
        }

        /// <summary>
        /// Calcul de l'ancienneté d'un salarié par rapport à la date actuelle
        /// </summary>
        /// <returns>Un nombre de mois</returns>
        public int Anciennete()
        {
            TimeSpan res = DateTime.Now.Subtract(Arrivee);
            return res.Days / 30;
        }

    }
}

