using System;
namespace TransConnect
{
    public abstract class Personne
    {
        protected string nom;
        protected string prenom;
        protected DateTime naissance;
        protected string adressePostale;
        protected string adresseMail;
        protected string portable;

        public Personne(string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, string portable)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adressePostale = adressePostale;
            this.adresseMail = adresseMail;
            this.portable = portable;
        }


        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime Naissance
        {
            get { return naissance; }
            set { naissance = value; }
        }

        public string AdressePostale
        {
            get { return adressePostale; }
            set { adressePostale = value; }
        }

        public string AdresseMail
        {
            get { return adresseMail; }
            set { adresseMail = value; }
        }

        public string Portable
        {
            get { return portable; }
            set { portable = value; }
        }

        public override string ToString()
        {
            return "Nom : " + nom + " Prenom : " + prenom + " Naissance : " + naissance + " Adresse Postale : " + adressePostale + " Adresse Mail : " + adresseMail + " Portable : " + portable;
        }
    }
}

