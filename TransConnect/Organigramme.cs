using System;
namespace TransConnect
{
    public class Organigramme
    {
        protected Salarie pdg;
        protected string nom;

        public Organigramme()
        {
            this.nom = "TransConnect";
        }

        public Organigramme(Salarie pdg)
        {
            this.pdg = pdg;
            this.nom = "TransConnect";
        }

        public void Afficher()
        {

            if (this.pdg == null)
            {
                Console.WriteLine("L'organigramme est vide...");
            }

            Afficher(this.pdg);
        }

        public void Afficher(Salarie node, int level = 0)
        {
            for (int i = 0; i < level; i++)
            {
                if (i < level - 1)
                {
                    Console.Write("|\t");
                }
                else
                {
                    Console.Write("+-------");
                }
            }

            // changement de couleur par level
            Console.ForegroundColor = (ConsoleColor)level + 3;
            Console.WriteLine(node);
            Console.ResetColor();

            if (node.Enfant != null) Afficher(node.Enfant, level + 1);
            if (node.Frere != null) Afficher(node.Frere, level);
        }
        public Salarie Find(string nom, string prenom)
        {
            return Find(nom, prenom, this.pdg);
        }
        private Salarie Find(string nom,string prenom,Salarie temp)
        {
            if (temp != null)
            {
                if(temp.Nom == nom && temp.Prenom == prenom)
                {
                    return temp;
                }
                else 
                {
                    Salarie tmp = Find(nom, prenom, temp.Frere);
                    if (tmp != null) return tmp;
                    return Find(nom, prenom, temp.Enfant);
                }
            }
            else return null;
        }
        public void Add(string managerNom, string managerPrenom, Salarie embauche)
        {
            Salarie manager = this.Find(managerNom, managerPrenom);
            if (manager == null)
            {
                Console.WriteLine("Manager introuvable");
                return;
            }
            Add(manager,embauche,pdg);
        }
        private void Add(Salarie manager, Salarie embauche, Salarie temp)
        {
            /*Console.WriteLine("Vous allez rentrer les informations du salarié à ajouter : \n");
            Console.WriteLine("Veuillez rentrer son numéro de sécurité sociale : \n");
            int numeroSS = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez rentrer son nom : \n");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer son prénom : \n");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer sa date de naissance avec le modèle suivant Année/Mois/Jour : \n");
            DateTime naissance = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez rentrer son adresse postale : \n");
            string adressePostale = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer son adresse mail : \n");
            string adresseMail = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer son numéro de portable : \n");
            string portable = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer sa date d'arrivée avec le modèle suivant Année/Mois/Jour : \n");
            DateTime arrivee = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez rentrer son poste : \n");
            string poste = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer son salaire : \n");
            int salaire = Int32.Parse(Console.ReadLine());
            Salarie temp2 = new Salarie(numeroSS, nom, prenom, naissance, adressePostale, adresseMail, portable, arrivee, poste, salaire);*/
            if (manager.Enfant == null)
                {
                manager.Enfant = embauche;
                }
                else
                {
                    Salarie temp2 = manager.Enfant;
                    while (temp2 != null)
                    {
                        temp2 = temp2.Frere;
                    }
                    temp2 = embauche;
                }
        }

        public Salarie FindFrere(string nom, string prenom)
        {
            return FindFrere(nom, prenom, this.pdg);
        }
        private Salarie FindFrere(string nom, string prenom, Salarie temp)
        {
            if (temp != null)
            {
                
                    if (temp.Frere != null && temp.Frere.Nom == nom && temp.Frere.Prenom == prenom)
                    {
                        return temp;
                    }
                    else
                    {
                        Salarie tmp = FindFrere(nom, prenom, temp.Frere);
                        if (tmp != null) return tmp;
                        return FindFrere(nom, prenom, temp.Enfant);
                    }
            }
            else return null;
        }
        public void Delete(string licencieNom, string licenciePrenom)
        {
            Salarie licencie = this.FindFrere(licencieNom, licenciePrenom);
            if (licencie == null)
            {
                Console.WriteLine("Licensié introuvable");
                return;
            }
            Delete(licencie);
        }
        private void Delete(Salarie licencie)
        {      
            licencie.Frere = licencie.Frere.Frere;
        }

        public void chauffeurLivraisonsTot()
        {
            
        }

    }
}

