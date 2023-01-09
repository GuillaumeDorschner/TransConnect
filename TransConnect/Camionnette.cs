using System;
namespace TransConnect
{
	public class Camionnette : Vehicule
	{

		public Camionnette(string immatriculation) : base(immatriculation)
		{
			this.immatriculation = immatriculation;
		}

        public override string ToString()
        {
            return "Camionnette : " + this.immatriculation;
        }
    }
}

