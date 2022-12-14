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
        protected int portable;

        public Personne( string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, int portable)
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
        }

        public DateTime Naissance
        {
            get { return naissance; }
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

        public int Portable
        {
            get { return portable; }
            set { portable = value; }
        }
    }
}

