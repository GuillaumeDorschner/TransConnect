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


    }
}
