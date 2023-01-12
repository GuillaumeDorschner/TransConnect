using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace TransConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tout les imports
            string json = File.ReadAllText("../../../data/data.json");
            Salarie salarie = Newtonsoft.Json.JsonConvert.DeserializeObject<Salarie>(json);
            Organigramme Org = new Organigramme(salarie);
            List<Client> clientsList = Client.FileToObj("../../../data/dataClient.json");
            Graph graph = new Graph("../../../data/distances.csv");
            List<Commande> listCommande = new List<Commande>();

            mainMenu(Org, clientsList, listCommande, graph);
        }

        static void mainMenu(Organigramme org, List<Client> listClients, List<Commande> listCommandes, Graph graph)
        {
            bool exit = false;

            do
            {
                Console.WriteLine("Sur quelle interface souhaitez vous vous rendre :\n"
                                    + "1 : Salarié \n"
                                    + "2 : Client \n"
                                    + "3 : Commande \n"
                                    + "4 : Statistiques \n"
                                    + "5 : Sauvegarde \n"
                                    + "6 : Exit \n\n"
                                    + "\rSélectionnez l'interface désirée :\n\n");
                int exo = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (exo)
                {
                    case 1:
                        salarieMenu(org, listClients, listCommandes);
                        break;

                    case 2:
                        clientMenu(org, listClients, listCommandes);
                        break;
                    case 3:
                        commandeMenu(org, listClients, listCommandes, graph);
                        break;
                    case 4:
                        statistiquesMenu(org, listClients, listCommandes);
                        break;
                    case 5:
                        try
                        {
                            File.WriteAllText("../../../data/data.json", Newtonsoft.Json.JsonConvert.SerializeObject(org.Pdg, Formatting.Indented));
                            Client.ObjToFile(listClients, "../../../data/dataClient.json");
                            Console.WriteLine("Fichiers sauvegardés avec succés");
                        }
                        catch (FileNotFoundException f)
                        {
                            Console.WriteLine(f.Message);
                        }
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }


            } while (!exit);

        }

        static void salarieMenu(Organigramme Org, List<Client> listClients, List<Commande> listCommandes)
        {
            bool exit = false;

            do
            {
                Org.Afficher();
                Console.WriteLine("Quelle action souhaitez vous éxecuter sur vos salariés :\n"
                                    + "1 : Embaucher \n"
                                    + "2 : Licencier \n"
                                    + "3 : Exit \n\n"
                                    + "\rSélectionnez l'action désirée :\n\n");
                int exo = Int32.Parse(Console.ReadLine());
                Console.Clear();
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
                        Org.Add(nomManager, prenomManager, nouveauEmbauche);
                        break;

                    case 2:
                        Console.WriteLine("Veuillez rentrer le nom du salarié à licencier :");
                        string nomLicencie = Console.ReadLine();
                        Console.WriteLine("Ainsi que son prénom :");
                        string prenomLicencie = Console.ReadLine();
                        Org.Delete(nomLicencie, prenomLicencie);
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }


            } while (!exit);

        }

        static void clientMenu(Organigramme org, List<Client> clientsList, List<Commande> listCommandes)
        {

            bool exit = false;

            do
            {
                foreach (Client i in clientsList) Console.WriteLine(i.ToString());
                Console.WriteLine("Quelle action souhaitez vous éxecuter sur vos clients :\n"
                                    + "1 : Créer un client \n"
                                    + "2 : Supprimer un client \n"
                                    + "3 : Modifier un client \n"
                                    + "4 : Trier clients \n"
                                    + "5 : Exit \n\n"
                                    + "\rSélectionnez l'action désirée :\n\n");
                int exo = Int32.Parse(Console.ReadLine());
                Console.Clear();
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
                        Queue<Commande> commandes = new Queue<Commande>();
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

                    case 4:
                        Console.WriteLine("Voici la liste des tris :" +
                            "\nTri par montant des achats cumulés (a)" +
                            "\nTri par villes (v)" +
                            "\nTri par ordre alphabétique (p)" +
                            "\nL'ordre des priorités des tris est celui ci-dessus");
                        string input = Console.ReadLine();


                        if (input.Contains("p"))
                        {
                            clientsList.Sort(clientsList[0].TriPrenomNom);
                        }
                        if (input.Contains("v"))
                        {
                            clientsList.Sort(clientsList[0].TriVille);
                        }
                        if (input.Contains("a"))
                        {
                            clientsList.Sort(clientsList[0].TriAchatCumul);
                        }

                        break;

                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }

            } while (!exit);

        }

        static void commandeMenu(Organigramme org, List<Client> listClients, List<Commande> listCommandes, Graph graph)
        {

            bool exit = false;

            do
            {

                Console.WriteLine("Quelle action souhaitez vous éxecuter sur vos commandes :\n"
                                    + "1 : Créer une commande \n"
                                    + "2 : Modifier une commande \n"
                                    + "3 : Afficher les commandes \n"
                                    + "4 : Exit \n\n"
                                    + "\rSélectionnez l'action désirée :\n\n");
                int exo = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (exo)
                {
                    case 1:

                        Console.WriteLine("Veuillez rentrer le nom du client de votre commande :");
                        string nomCommande = Console.ReadLine();
                        Client clientCommande = listClients.Find((Client a) => a.Nom == nomCommande);
                        if (clientCommande == null)
                        {
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
                            Queue<Commande> commandes = new Queue<Commande>();
                            clientCommande = new Client(nom, prenom, naissance, adressePostale, adresseMail, portable, commandes);
                            listClients.Add(clientCommande);
                        }

                        Console.WriteLine("Veuillez entrer une ville de départ :");
                        string villeA = Console.ReadLine();
                        Console.WriteLine("Veuillez entrer une ville d'arrivée :");
                        string villeB = Console.ReadLine();

                        DateTime today = DateTime.Today;
                        DateTime chosenDate;

                        do
                        {
                            Console.WriteLine("Veuillez choisir une date (jj/mm/aaaa) :");
                            chosenDate = DateTime.Parse(Console.ReadLine());
                            if (chosenDate < today)
                            {
                                Console.WriteLine("La date choisie ne peut pas être inférieure à la date d'aujourd'hui.");
                            }
                        } while (chosenDate < today);

                        Livraison livraison = new Livraison(graph, villeA, villeB);
                        Commande newCommande;

                        Console.WriteLine("Veuillez rentrer voiture si vous voulez une voiture, camionnette pour une camionnette ou camion pour un camion");
                        string vehicule = Console.ReadLine();
                        if (vehicule.ToLower() == "voiture")
                        {
                            newCommande = new Commande(clientCommande, livraison, new Voiture("123"), org.chauffeurLibre(chosenDate), chosenDate);
                            if (newCommande.Chauffeur != null)
                            { listCommandes.Add(newCommande); }
                        }
                        if (vehicule.ToLower() == "camionnette")
                        {
                            newCommande = new Commande(clientCommande, livraison, new Camionnette("123"), org.chauffeurLibre(chosenDate), chosenDate);
                            if (newCommande.Chauffeur != null)
                            { listCommandes.Add(newCommande); }
                        }
                        if (vehicule.ToLower() == "camion")
                        {
                            Console.WriteLine("Veuillez rentrer 1 pour un camion citerne, 2 pour un camion benne et 3 pour un camion frigorifique");
                            int camion = Int32.Parse(Console.ReadLine());
                            if (camion == 1)
                            {
                                newCommande = new Commande(clientCommande, livraison, new Camion("123", 1), org.chauffeurLibre(chosenDate), chosenDate);
                                if (newCommande.Chauffeur != null)
                                { listCommandes.Add(newCommande); }
                            }
                            if (camion == 2)
                            {
                                newCommande = new Commande(clientCommande, livraison, new Camion("123", 2), org.chauffeurLibre(chosenDate), chosenDate);
                                if (newCommande.Chauffeur != null)
                                { listCommandes.Add(newCommande); }
                            }
                            if (camion == 3)
                            {
                                newCommande = new Commande(clientCommande, livraison, new Camion("123", 3), org.chauffeurLibre(chosenDate), chosenDate);
                                if (newCommande.Chauffeur != null)
                                { listCommandes.Add(newCommande); }
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("Veuillez rentrer le nom du client sur la commande :");
                        string nomModify = Console.ReadLine();
                        Console.WriteLine("Ainsi que son prénom :");
                        string prenomModify = Console.ReadLine();
                        Console.WriteLine("Ville de départ :");
                        string villeDepart = Console.ReadLine();
                        Console.WriteLine("Et la ville d'arrivée :");
                        string villeArrivee = Console.ReadLine();

                        Commande modify = listCommandes.Find((Commande a) => a.Client.Nom == nomModify && a.Client.Prenom == prenomModify && a.Livraison.PointA==villeDepart && a.Livraison.PointB == villeArrivee);
                        if (modify == null) Console.WriteLine("Commande à modifier introuvable");
                        else
                        {
                            Console.WriteLine("Voici le client que vous voulez modifier : \n");
                            Console.WriteLine(modify.ToString());


                            bool valide = false;

                            while (!valide)
                            {
                                Console.WriteLine("\n\nQuelle donnée de la commande souhaitez vous modifier : \n" +
                                    "1 : nom du client \n" +
                                    "2 : prénom du client\n" +
                                    "3 : ville de départ\n" +
                                    "4 : ville d'arrivée \n" );
                                int choix = Int32.Parse(Console.ReadLine());

                                switch (choix)
                                {
                                    case 1:
                                        Console.WriteLine("Entrer le nouveau nom :");
                                        string change = Console.ReadLine();
                                        if (change != null)
                                        {
                                            modify.Client.Nom = change;
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucun nom rentré ");
                                        break;
                                    case 2:
                                        Console.WriteLine("Entrer le nouveau prénom :");
                                        change = Console.ReadLine();
                                        if (change != null)
                                        {
                                            modify.Client.Prenom = change;
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucun prénom rentré ");
                                        break;
                                    case 3:
                                        Console.WriteLine("Entrer la nouvelle ville de départ :");
                                        string newDepart = Console.ReadLine();
                                        if (newDepart != null)
                                        {
                                            modify.Livraison.PointA = newDepart;
                                            modify = new Commande(modify.Client, new Livraison(graph, newDepart,modify.Livraison.PointB), modify.Vehicule, modify.Chauffeur, modify.DateLivraison);
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucune ville rentrée ");
                                        break;
                                    case 4:
                                        Console.WriteLine("Entrer la nouvelle ville d'arrivée :");
                                        string newArrivee = Console.ReadLine();
                                        if (newArrivee != null)
                                        {
                                            modify.Livraison.PointB = newArrivee;
                                            modify = new Commande(modify.Client, new Livraison(graph, modify.Livraison.PointA, newArrivee), modify.Vehicule, modify.Chauffeur, modify.DateLivraison);
                                            valide = true;
                                        }
                                        else Console.WriteLine("Aucune ville rentrée ");
                                        break;
                                    default:
                                        Console.WriteLine("Veuillez rentrer un numéro valide");
                                        break;
                                }
                            }

                        }
                        break;
                    case 3:
                        foreach (Commande commande in listCommandes)
                        {
                            Console.WriteLine(commande.ToString());
                        }
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }

            } while (!exit);
        }

        static void statistiquesMenu(Organigramme org, List<Client> listClients, List<Commande> listCommandes)
        {

            bool exit = false;

            do
            {

                Console.WriteLine("\n\nQuelle action souhaitez vous éxecuter sur vos commandes :\n"
                                    + "1 : Afficher par chauffeur le nombre de livraisons effectuées \n"
                                    + "2 : Afficher les commandes selon une période de temps \n"
                                    + "3 : Afficher la moyenne des prix des commandes \n"
                                    + "4 : Afficher la moyenne des comptes clients  \n"
                                    + "5 : Afficher la liste des commandes pour un client \n"
                                    + "6 : Exit \n\n"
                                    + "\rSélectionnez l'action désirée :\n\n");
                int exo = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (exo)
                {
                    case 1:
                        Console.WriteLine("Veuillez saisir le nom du chauffeur dont vous voulez afficher les commandes :");
                        string chauffeurNom = Console.ReadLine();
                        Console.WriteLine("Veuillez également saisir son prenom :");
                        string chauffeurPrenom = Console.ReadLine();
                        utilitairesStat.nombreLivraisons(org, chauffeurNom, chauffeurPrenom);
                        break;

                    case 2:
                        DateTime start;
                        Console.WriteLine("Veuillez rentrer la date de début de la forme suivante MM/DD/YYYY :");
                        DateTime.TryParse(Console.ReadLine(), out start);
                        DateTime stop;
                        Console.WriteLine("Veuillez rentrer la date de fin de la forme suivante MM/DD/YYYY :");
                        DateTime.TryParse(Console.ReadLine(), out stop);
                        utilitairesStat.commandesPeriode(listCommandes, start, stop);

                        break;

                    case 3:
                        Console.WriteLine("Veuillez rentrer le nom du client dont vous voulez calculer le prix moyen des commandes :");
                        string clientNom = Console.ReadLine();
                        Console.WriteLine("Veuillez également rentrer le prénom du client :");
                        string clientPrenom = Console.ReadLine();
                        Client client = listClients.Find((Client a) => a.Nom == clientNom && a.Prenom == clientPrenom);
                        utilitairesStat.moyennePrixClient(client);
                        break;

                    case 4:
                        utilitairesStat.moyennePrix(listCommandes);
                        break;

                    case 5:
                        Console.WriteLine("Veuillez rentrer le nom du client dont vous voulez afficher les commandes :");
                        string clientNom2 = Console.ReadLine();
                        Console.WriteLine("Veuillez également rentrer le prénom du client :");
                        string clientPrenom2 = Console.ReadLine();
                        Client client2 = listClients.Find((Client a) => a.Nom == clientNom2 && a.Prenom == clientPrenom2);
                        utilitairesStat.affichageCommandesClient(client2);
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("ce choix n'est pas disponible.");
                        break;
                }
            } while (!exit);
        }



    }
}