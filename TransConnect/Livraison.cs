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

		public string PointA
		{
			get { return pointA; }
		}

        public string PointB
        {
            get { return pointB; }
        }

        public int Distance
        {
            get { return distance; }
        }

        public TimeSpan TempsTrajet
		{
			get { return tempsTrajet; }
		}
    }
}

