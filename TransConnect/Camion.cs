using System;
namespace TransConnect
{
    struct CamionType
    {
        public string typeCamion;
        public string materiaux;
    };

    public class Camion : Vehicule
	{
        CamionType camionCiterne;
        CamionType camionBenne;
        CamionType camionFrigorifique;

        public double volume;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chauffeur"></param>
        /// <param name="immatriculation"></param>
        /// <param name="type">1 : Camion Citerne, 2 : Camion Benne, 3 : Camion Frigorifique</param>
        public Camion(string immatriculation,int type) : base(immatriculation)
		{
            this.immatriculation = immatriculation;

            switch (type)
            { 
                case 1:
                    camionCiterne.typeCamion = "Camion Citerne";
                    camionCiterne.materiaux = "Liquides et Gaz";
                    break;
                case 2:
                    camionBenne.typeCamion = "Camion Benne";
                    camionBenne.materiaux = "Sable, terre et gravier";
                    break;
                case 3:
                    camionFrigorifique.typeCamion = "Camion Frigorifique";
                    camionFrigorifique.materiaux = "Marchandise périssable";
                    break;
                default:
                    Console.OpenStandardError();
                    break;                
            }
		}

        public override string ToString()
        {
            return "Camion : " + this.immatriculation;
        }
    }
}

