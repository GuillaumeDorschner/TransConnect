using System;
namespace TransConnect
{
	public class Livraison
	{
		protected string pointA;
		protected string pointB;
		protected int distance;
		protected TimeSpan tempsTrajet;

		public Livraison(string pointA, string pointB, int distance, TimeSpan tempsTrajet)
		{
			this.pointA = pointA;
			this.pointB = pointB;
			this.distance = distance;
			this.tempsTrajet = tempsTrajet;
		}

		string PointA
		{
			get { return pointA; }
		}

        string PointB
        {
            get { return pointB; }
        }

        int Distance
        {
            get { return distance; }
        }

        TimeSpan TempsTrajet
		{
			get { return tempsTrajet; }
		}
    }
}

