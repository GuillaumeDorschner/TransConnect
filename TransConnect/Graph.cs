using System;

namespace TransConnect
{
    public class Graph
    {
        private Dictionary<string, Dictionary<string, int>> vertices = new Dictionary<string, Dictionary<string, int>>();

        public Graph()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public Graph(string path)
        {
            string[] lines = File.ReadAllLines(path);


            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string city1 = values[0];
                string city2 = values[1];
                int distance = int.Parse(values[2]);

                if (!vertices.ContainsKey(city1))
                {
                    vertices[city1] = new Dictionary<string, int>();
                }

                if (!vertices.ContainsKey(city2))
                {
                    vertices[city2] = new Dictionary<string, int>();
                }

                vertices[city1][city2] = distance;
                vertices[city2][city1] = distance;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="edges"></param>
        public void AddVertex(string name, Dictionary<string, int> edges)
        {
            vertices[name] = edges;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public List<string> ShortestPath(string start, string finish)
        {
            var previous = new Dictionary<string, string>();
            var distances = new Dictionary<string, int>();
            var nodes = new List<string>();

            List<string> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
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
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            path.Reverse();
            path.Insert(0, start);

            return path;
        }

    }
}