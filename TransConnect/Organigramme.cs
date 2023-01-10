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

        /// <summary>
        /// Constructeur de l'organigramme
        /// </summary>
        /// <param name="pdg">PDG de l'entreprise</param>
        public Organigramme(Salarie pdg)
        {
            this.pdg = pdg;
            this.nom = "TransConnect";
        }

        public Salarie Pdg
        {
            get { return this.pdg; }
        }

        /// <summary>
        /// affiche l'organigramme d'une entreprise sous forme de liste hiérarchique à partir du PDG
        /// </summary>
        public void Afficher()
        {

            if (this.pdg == null)
            {
                Console.WriteLine("L'organigramme est vide...");
            }

            Afficher(this.pdg);
        }

        /// <summary>
        /// affiche l'organigramme d'une entreprise sous forme de liste hiérarchique à partir d'un Salarie de départ
        /// </summary>
        /// <param name="node">Salarie de départ</param>
        /// <param name="level">niveau de profondeur [ne rien attribuer] c'est pour la récursivité</param>
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

        /// <summary>
        /// Permet de trouver un salarié dans l'organigramme à partir de son nom et prénom
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns>Le salarié trouvé</returns>
        public Salarie Find(string nom, string prenom)
        {
            return Find(nom, prenom, this.pdg);
        }
        private Salarie Find(string nom, string prenom, Salarie temp)
        {
            if (temp != null)
            {
                if (temp.Nom == nom && temp.Prenom == prenom)
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

        /// <summary>
        /// Permet d'ajouter un salarié à l'oganigramme
        /// </summary>
        /// <param name="managerNom"></param>
        /// <param name="managerPrenom"></param>
        /// <param name="embauche"></param>
        public void Add(string managerNom, string managerPrenom, Salarie embauche)
        {
            Salarie manager = this.Find(managerNom, managerPrenom);
            if (manager == null)
            {
                Console.WriteLine("Manager introuvable");
                return;
            }
            Add(manager, embauche, pdg);
        }
        private void Add(Salarie manager, Salarie embauche, Salarie temp)
        {
            if (manager.Enfant == null)
            {
                manager.Enfant = embauche;
            }
            else
            {
                Salarie temp2 = manager.Enfant;
                while (temp2.Frere != null)
                {
                    temp2 = temp2.Frere;
                }
                temp2.Frere = embauche;
            }
        }


        /// <summary>
        /// Permet de trouver le parent d'un enfant recherché
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns>Le manager du salarié recherché</returns>
        public Salarie FindEnfant(string nom, string prenom)
        {
            return FindEnfant(nom, prenom, this.pdg);
        }
        private Salarie FindEnfant(string nom, string prenom, Salarie temp)
        {
            if (temp != null)
            {

                if (temp.Enfant != null && temp.Enfant.Nom == nom && temp.Enfant.Prenom == prenom)
                {
                    return temp;
                }
                else
                {
                    Salarie tmp = FindEnfant(nom, prenom, temp.Frere);
                    if (tmp != null) return tmp;
                    return FindEnfant(nom, prenom, temp.Enfant);
                }
            }
            else return null;
        }

        /// <summary>
        /// Permet de trouver le frère du salaroé recherché
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns>Le frère du salarié</returns>
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

        /// <summary>
        /// Permet de supprimer un salarié
        /// </summary>
        /// <param name="licencieNom"></param>
        /// <param name="licenciePrenom"></param>
        public void Delete(string licencieNom, string licenciePrenom)
        {
            Salarie licencie = this.FindEnfant(licencieNom, licenciePrenom);

            if (licencie == null)
            {
                licencie = this.FindFrere(licencieNom, licenciePrenom);
                Delete(licencie, true);
                if (licencie == null)
                {
                    Console.WriteLine("Licensié introuvable");
                    return;
                }
            }
            else Delete(licencie, false);

        }
        private void Delete(Salarie licencie, bool frere)
        {
            if (!frere)
            {
                licencie.Enfant = licencie.Enfant.Enfant;
            }
            else
            {
                licencie.Frere = licencie.Frere.Frere;
            }

        }


        /// <summary>
        /// Test les chauffeurs afin d'en trouver un libre pour l'assigner à une commande
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Un chauffeur disponible</returns>
        public Salarie chauffeurLibre(DateTime date)
        {
            return chauffeurLibre(date, this.pdg);
        }
        private Salarie chauffeurLibre(DateTime date, Salarie temp)
        {
            if (temp == null) return null;

            if (temp.Poste == "Chauffeur")
            {
                bool libre = true;
                foreach (Commande i in temp.Commande)
                {
                    if (i.DateLivraison == date)
                    {
                        libre = false;
                    }
                }

                if (libre) return temp;
            }

            var tmp = chauffeurLibre(date, temp.Frere);
            if (tmp != null)
                return tmp;
            return chauffeurLibre(date, temp.Enfant);
        }
    }
}

