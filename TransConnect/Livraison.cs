using System;
namespace TransConnect
{
	public class Livraison
	{
		protected string pointA;
		protected string pointB;
		protected int distance;
		protected string chemin;
		protected TimeSpan tempsTrajet;

		public Livraison(string pointA, string pointB)
		{
            var path = graph.ShortestPath(this.PointA, this.PointB);
			this.distance = path.Item2;
			this.tempsTrajet = path.Item3;
			this.chemin = string.Join(" -> ", path.Item1);
            this.pointA = pointA;
			this.pointB = pointB;
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

