using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace TransConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {


            mainMenu();

            // client json to client object
            List<Client> l1 = Client.FileToObj("../../../dataClient.json");

            Client test = new Client("Abril", "Aarrane", new DateTime(2015, 12, 31) , "19, place de Miremont 47300 VILLENEUVE-SUR-LOT", "pierre.dupond@gmail.com", "016391645",
            null);

            Client.Add(l1,test);
            Client.Delete(l1, "Margand");
            //Client.Modify(l1, "Authier");
            foreach (Client client in l1)
                Console.WriteLine(client);

            // client object to client json
            Client.ObjToFile(l1, "../../../testClient.json");

            // json to object
            string json = File.ReadAllText("../../../data.json");

            Salarie salarie = Newtonsoft.Json.JsonConvert.DeserializeObject<Salarie>(json);

            Organigramme Org = new Organigramme(salarie);
            //Org.Afficher();
            Salarie nouveau = new Salarie(1093847, "Grateau", "Valentin", new DateTime(2002, 09, 13), "Fresnes", "valentin.grateau@gmail.com", "0782082123", new DateTime(2014, 07, 20), "chauffeur", 2000);
            Salarie nouveau2 = new Salarie(1093847, "Dorschner", "Guillaume", new DateTime(2002, 09, 13), "Fresnes", "valentin.grateau@gmail.com", "0782082123", new DateTime(2014, 07, 20), "chauffeur", 2000);
            Salarie nouveau3 = new Salarie(1093847, "Hollande", "François", new DateTime(2002, 09, 13), "Fresnes", "valentin.grateau@gmail.com", "0782082123", new DateTime(2014, 07, 20), "chauffeur", 2000);
            Commande commande = new Commande(test, new Livraison("Paris", "Marseille", 800, new TimeSpan(2,2, 5,0)),new Camion(nouveau,"ABC",1),nouveau,new DateTime(2022,10,10));
            
            Console.WriteLine("Ancienneté : " + nouveau.Anciennete() + " mois");
            Console.WriteLine("Prix de la commande " + commande.tarifFinal() + " €");
            Org.Add("Romu","Pierpont",nouveau);
            Org.Add("Grateau", "Valentin", nouveau2);
            Org.Add("Romu", "Pierpont", nouveau3);

            //Org.Delete("Royal", "Theodore");

            Org.Afficher();

        }

        static void mainMenu()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                Console.WriteLine("Sur quelle interface souhaitez vous vous rendre :\n"
                                    + "1 : Salarié \n"
                                    + "2 : Client \n"
                                    + "3 : Commande \n\n"
                                    + "\rSélectionnez l'interface désirée :");
                int exo = Int32.Parse(Console.ReadLine());
                switch (exo)
                {
                    case 1:
                        salarieMenu();
                        break;

                    case 2:
                        clientMenu();
                        break;
                    case 3:
                       
                        break;

                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }
                Console.WriteLine("\nTapez Escape pour sortir ou tapez une autre touche pour continuer");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

        }

        static void salarieMenu()
        {
            string json = File.ReadAllText("../../../data.json");

            Salarie salarie = Newtonsoft.Json.JsonConvert.DeserializeObject<Salarie>(json);

            Organigramme Org = new Organigramme(salarie);
            

            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                Org.Afficher();
                Console.WriteLine("Quelle action souhaitez vous éxecuter sur vos salariés :\n"
                                    + "1 : Embaucher \n"
                                    + "2 : Licencier \n\n"
                                    + "\rSélectionnez l'action désirée :");
                int exo = Int32.Parse(Console.ReadLine());
                switch (exo)
                {
                    case 1:
                        Console.WriteLine("Vous allez rentrer les informations du salarié à embaucher \n");
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
                        Salarie nouveauEmbauche = new Salarie(numeroSS, nom, prenom, naissance, adressePostale, adresseMail, portable, arrivee, poste, salaire);
                        Console.WriteLine("Pour finir, veuillez rentrer le nom de son manager :\n");
                        string nomManager = Console.ReadLine();
                        Console.WriteLine("Ainsi que son prénom :\n");
                        string prenomManager = Console.ReadLine();
                        Org.Add(nomManager,prenomManager,nouveauEmbauche);
                        break;

                    case 2:
                        Console.WriteLine("Veuillez rentrer le nom du salarié à licencier :");
                        string nomLicencie = Console.ReadLine();
                        Console.WriteLine("Ainsi que son prénom :");
                        string prenomLicencie = Console.ReadLine();
                        Org.Delete(nomLicencie, prenomLicencie);
                        break;

                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }
                File.WriteAllText("../../../data.json", Newtonsoft.Json.JsonConvert.SerializeObject(Org));
                Console.WriteLine("\nTapez Escape pour sortir ou tapez une autre touche pour continuer");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

        }

        static void clientMenu()
        {
            List<Client> clientsList = Client.FileToObj("../../../dataClient.json");

            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                foreach (Client i in clientsList) Console.WriteLine(i.ToString());
                Console.WriteLine("Quelle action souhaitez vous éxecuter sur vos clients :\n"
                                    + "1 : Créer un client \n"
                                    + "2 : Supprimer un client \n"
                                    + "3 : Modifier un client \n\n"
                                    + "\rSélectionnez l'action désirée :");
                int exo = Int32.Parse(Console.ReadLine());
                switch (exo)
                {
                    case 1:
                        Console.WriteLine("Vous allez rentrer les informations du client à créer \n");
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
                        List<Commande> commandes = new List<Commande>();
                        Client nouveauClient = new Client(nom, prenom, naissance, adressePostale, adresseMail, portable, commandes);
                        clientsList.Add(nouveauClient);

                        break;

                    case 2:
                        Console.WriteLine("Veuillez rentrer le nom du client à supprimer :");
                        string nomDelete = Console.ReadLine();
                        Console.WriteLine("Ainsi que son prénom :");
                        string prenomDelete = Console.ReadLine();

                        int index = clientsList.FindIndex((Client a) => a.Nom == nomDelete && a.Prenom == prenomDelete);
                        clientsList.RemoveAt(index);
                        break;
                    case 3:
                        Console.WriteLine("Veuillez rentrer le nom du client à modifier :");
                        string nomModify = Console.ReadLine();
                        Console.WriteLine("Ainsi que son prénom :");
                        string prenomModify = Console.ReadLine();

                        Client modify = clientsList.Find((Client a) => a.Nom == nomModify && a.Prenom == prenomModify);
                        if (modify == null) Console.WriteLine("Client à modifier introuvable");
                        else
                        {
                            Console.WriteLine("Voici le client que vous voulez modifier : \n");
                            Console.WriteLine(modify.ToString());


                            bool valide = false;

                            while (!valide)
                            {
                                Console.WriteLine("Quelle donnée du client souhaitez vous modifier : \n" +
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
                                            modify.Nom = change;
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucun nom rentré ");
                                        break;
                                    case 2:
                                        Console.WriteLine("Entrer le nouveau prénom :");
                                        change = Console.ReadLine();
                                        if (change != null)
                                        {
                                            modify.Prenom = change;
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucun prénom rentré ");
                                        break;
                                    case 3:
                                        Console.WriteLine("Entrer la nouvelle date de naissance :");
                                        DateTime newDate = DateTime.Parse(Console.ReadLine());
                                        if (newDate.ToString() != null)
                                        {
                                            modify.Naissance = newDate;
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucune date de naissance rentrée ");
                                        break;
                                    case 4:
                                        Console.WriteLine("Entrer la nouvelle adresse postale :");
                                        change = Console.ReadLine();
                                        if (change != null)
                                        {
                                            modify.AdressePostale = change;
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucune adresse postale rentrée ");
                                        break;
                                    case 5:
                                        Console.WriteLine("Entrer la nouvelle adresse mail :");
                                        change = Console.ReadLine();
                                        if (change != null)
                                        {
                                            modify.AdresseMail = change;
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucune adresse mail rentrée ");
                                        break;
                                    case 6:
                                        Console.WriteLine("Entrer le nouveau numéro de portable :");
                                        change = Console.ReadLine();
                                        if (change != null)
                                        {
                                            modify.Portable = change;
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
                        break;

                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }
                Client.ObjToFile(clientsList, "../../../dataClient.json");
                Console.WriteLine("\nTapez Escape pour sortir ou tapez une autre touche pour continuer");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

        }

        static void commandeMenu()
        {
            //?? création base de donnée vide
            
            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();

                Console.WriteLine("Quelle action souhaitez vous éxecuter sur vos commandes :\n"
                                    + "1 : Créer une commande \n"
                                    + "2 : Modifier une commande \n\n"
                                    + "\rSélectionnez l'action désirée :");
                int exo = Int32.Parse(Console.ReadLine());
                switch (exo)
                {
                    case 1:

                        break;
                    case 2:
                        break;

                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }
                //?? écriture dans la base de donnée vide
                Console.WriteLine("\nTapez Escape pour sortir ou tapez une autre touche pour continuer");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
        }


        }
}