using System;
namespace TransConnect
{
	public class Voiture : Vehicule
	{
		protected int nombrePassagers;

		public Voiture(Salarie chauffeur, int nombrePassagers,string immatriculation) : base(chauffeur,immatriculation)
		{
			this.chauffeur = chauffeur;
			this.nombrePassagers = nombrePassagers;
			this.immatriculation = immatriculation;
		}
	}
}

