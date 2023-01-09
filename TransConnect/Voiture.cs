using System;
namespace TransConnect
{
	public class Voiture : Vehicule
	{

		public Voiture(string immatriculation) : base(immatriculation)
		{
			this.immatriculation = immatriculation;
		}

        public override string ToString()
        {
            return "Voiture : " + this.immatriculation ;
        }
    }
}

