using System;
namespace TransConnect
{
	public abstract class Vehicule
	{
		protected string immatriculation;

		public Vehicule(string immatriculation)
		{
			this.immatriculation = immatriculation;
		}
	}
}

