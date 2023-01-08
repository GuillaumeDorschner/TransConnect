using System;

namespace TransConnect
{
    public class Graph
    {
        private Dictionary<string, Dictionary<string, (int, TimeSpan)>> vertices = new Dictionary<string, Dictionary<string, (int, TimeSpan)>>();

        public Graph()
        {

        }

        /// <summary>
        /// Constructeur de la classe Graph à partir d'un fichier
        /// </summary>
        /// <param name="path">Chemin du ficher .csv</param>
        public Graph(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);


                foreach (string line in lines)
                {
                    string[] values = line.Split(';');
                    string city1 = values[0];
                    string city2 = values[1];
                    int distance = int.Parse(values[2]);
                    Console.Write(values[3].Replace('h', ':'));
                    TimeSpan time = TimeSpan.Parse(values[3].Replace('h', ':'));

                    if (!vertices.ContainsKey(city1))
                    {
                        vertices[city1] = new Dictionary<string, (int, TimeSpan)>();
                    }

                    if (!vertices.ContainsKey(city2))
                    {
                        vertices[city2] = new Dictionary<string, (int, TimeSpan)>();
                    }


                    vertices[city1][city2] = (distance, time);
                    vertices[city2][city1] = (distance, time);
                }
            }
            catch (FileNotFoundException f)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Erreur : ");
                Console.WriteLine(f.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Ajoute un sommet au graphe
        /// </summary>
        /// <code>
        /// graph.AddVertex("A", new Dictionary<string, (int, TimeSpan)>() { { "B", (7, new TimeSpan(0, 4, 34, 0, 0)) }, { "C", (8, new TimeSpan(0, 4, 34, 0, 0)) } });
        /// </code>
        /// <param name="name">Nom du sommet</param>
        /// <param name="edges">Liste des sommets adjacents</param>
        public void AddVertex(string name, Dictionary<string, (int, TimeSpan)> edges)
        {
            vertices[name] = edges;
        }

        ///<summary>
        /// Retourne le chemin le plus court entre deux points dans un graphe.
        ///</summary>
        ///<param name="start">Le nom du point de départ</param>
        ///<param name="finish">Le nom du point d'arrivée</param>
        ///<returns>Une liste de chaînes de caractères représentant le chemin le plus court entre les deux points</returns>
        public (List<string>, int, TimeSpan) ShortestPath(string start, string finish)
        {
            var previous = new Dictionary<string, string>();
            var distances = new Dictionary<string, int>();
            var times = new Dictionary<string, TimeSpan>();
            var nodes = new List<string>();

            List<string> path = null;
            int distance = 0;
            TimeSpan time = new TimeSpan();

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                    times[vertex.Key] = new TimeSpan();
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                    times[vertex.Key] = new TimeSpan(int.MaxValue);
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<string>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value.Item1;
                    var altTime = times[smallest] + neighbor.Value.Item2;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                        times[neighbor.Key] = altTime;
                    }
                }
            }

            path.Reverse();
            path.Insert(0, start);

            distance = distances[finish];
            time = times[finish];
            return (path, distance, time);
        }


    }
}