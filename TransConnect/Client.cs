using System;
namespace TransConnect
{
    public class Client : Personne, ITris
    {
        //Collection de clients en mémoire = static List<Client> dans le main surement
        protected Queue<Commande> commande;

        public delegate int typeDeTri();
        public delegate int Tri(Client a, Client b);

        public Client(string nom, string prenom, DateTime naissance, string adressePostale, string adresseMail, string portable,
            Queue<Commande> commande) : base(nom, prenom, naissance, adressePostale, adresseMail, portable)
        {
            this.commande = new Queue<Commande>();
        }


        public Queue<Commande> Commande
        {
            get { return commande; }
            set { commande = value; }
        }

        public int TriPrenomNom(Client a, Client b)
        {
            int x = a.Nom.CompareTo(b.Nom);
            if (x == 0)
            {
                x = x + a.Prenom.CompareTo(b.Prenom);
            }
            return x;
        }
        public int achatsCumule()
        {
            int sum = 0;
            foreach (Commande i in commande)
            {
                sum += i.Prix;
            }
            return sum;
        }

        public int TriVille(Client a, Client b)
        {
            return a.adressePostale.CompareTo(b.adressePostale);
        }

        public int TriAchatCumul(Client a, Client b) //A tester pas de delegte car je ne sais pas comment faire
        {
            return a.achatsCumule().CompareTo(b.achatsCumule());
        }

        /// <summary>
        /// Permet de lire les clients d'un fichier .json et de les mettre dans une List
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Une List de Client</returns>
        public static List<Client> FileToObj(string path)
        {
            List<Client> clients = new List<Client>();
            try
            {
                foreach (Client client in Newtonsoft.Json.JsonConvert.DeserializeObject<Client[]>(File.ReadAllText(path)))
                    clients.Add(client);

            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
            }
            return clients;

        }

        /// <summary>
        /// Permet de sauvegarder la liste de clients dans un fichier .json
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="path"></param>
        public static void ObjToFile(List<Client> clients, string path)
        {
            try
            {
                File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(clients));
            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + commande;
        }

        public static void Add(List<Client> listClient, Client add)
        {
            listClient.Add(add);
        }

        public static void Delete(List<Client> listClient, string NameDelete)
        {
            foreach (Client i in listClient)
            {
                if (i.Nom == NameDelete)
                {
                    listClient.Remove(i);
                    break;
                }
                else
                {
                    Console.WriteLine("Aucuns clients trouvé avec ce nom");
                    break;
                }
            }
        }

        public static void Modify(List<Client> listClient, string modify)
        {
            bool valide = false;
            foreach (Client i in listClient)
            {
                if (i.Nom == modify)
                {
                    while (!valide)
                    {
                        Console.WriteLine("Quelle donnée du client " + modify + " souhaitez voys modifier : \n" +
                            "1 : nom \n" +
                            "2 : prénom\n" +
                            "3 : date de naissance\n" +
                            "4 : adresse postale\n" +
                            "5 : adresse mail\n" +
                            "6 : portable");
                        int choix = Int32.Parse(Console.ReadLine());

                        switch (choix)
                        {
                            case 1:
                                Console.WriteLine("Entrer le nouveau nom :");
                                string change = Console.ReadLine();
                                if (change != null)
                                {
                                    i.Nom = change;
                                    valide = true;
                                }
                                else Console.WriteLine("Aucun nom rentré ");
                                break;
                            case 2:
                                Console.WriteLine("Entrer le nouveau prénom :");
                                change = Console.ReadLine();
                                if (change != null)
                                {
                                    i.Prenom = change;
                                    valide = true;
                                }
                                else Console.WriteLine("Aucun prénom rentré ");
                                break;
                            case 3:
                                Console.WriteLine("Entrer la nouvelle date de naissance :");
                                DateTime newDate = DateTime.Parse(Console.ReadLine());
                                if (newDate.ToString() != null)
                                {
                                    i.Naissance = newDate;
                                    valide = true;
                                }
                                else Console.WriteLine("Aucune date de naissance rentrée ");
                                break;
                            case 4:
                                Console.WriteLine("Entrer la nouvelle adresse postale :");
                                change = Console.ReadLine();
                                if (change != null)
                                {
                                    i.AdressePostale = change;
                                    valide = true;
                                }
                                else Console.WriteLine("Aucune adresse postale rentrée ");
                                break;
                            case 5:
                                Console.WriteLine("Entrer la nouvelle adresse mail :");
                                change = Console.ReadLine();
                                if (change != null)
                                {
                                    i.AdresseMail = change;
                                    valide = true;
                                }
                                else Console.WriteLine("Aucune adresse mail rentrée ");
                                break;
                            case 6:
                                Console.WriteLine("Entrer le nouveau numéro de portable :");
                                change = Console.ReadLine();
                                if (change != null)
                                {
                                    i.Portable = change;
                                    valide = true;
                                }
                                else Console.WriteLine("Aucun numéro de portable rentré ");
                                break;
                            default:
                                Console.WriteLine("Veuillez rentrer un numéro valide");
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("Aucuns clients trouvé avec ce nom");

        }

    }
}