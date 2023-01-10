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

        public Livraison(Graph graph, string pointA, string pointB)
        {
            this.pointA = pointA;
            this.pointB = pointB;
            var path = graph.ShortestPath(PointA, PointB);
            this.chemin = string.Join(" -> ", path.Item1);
            this.distance = path.Item2;
            this.tempsTrajet = path.Item3;
        }

        public string PointA
        {
            get { return pointA; }
            set { pointA = value; }
        }

        public string PointB
        {
            get { return pointB; }
            set { pointB = value; }
        }

        public int Distance
        {
            get { return distance; }
        }

        public TimeSpan TempsTrajet
        {
            get { return tempsTrajet; }
        }

        public string Chemin
        {
            get { return chemin; }
        }
    }
}

