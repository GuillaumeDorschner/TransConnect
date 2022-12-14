using System;
namespace TransConnect
{
	public class Camionnette : Vehicule
	{
		protected string usage;

		public Camionnette(Salarie chauffeur, string usage, string immatriculation) : base(chauffeur,immatriculation)
		{
			this.chauffeur = chauffeur;
			this.usage = usage;
			this.immatriculation = immatriculation;
		}
	}
}

