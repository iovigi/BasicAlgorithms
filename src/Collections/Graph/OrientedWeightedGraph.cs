namespace Collection.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrientedWeightedGraph<T>
    {
        private readonly HashSet<Vertex> vertexes;

        public OrientedWeightedGraph()
        {
            this.vertexes = new HashSet<Vertex>();
        }

        public bool Add(T value)
        {
            var vertex = new Vertex(value);

            return this.vertexes.Add(vertex);
        }

        public bool Remove(T value)
        {
            var vertex = this.vertexes.FirstOrDefault(x => x.value.Equals(value));

            if (vertex == null)
            {
                return false;
            }

            var result = this.vertexes.Remove(vertex);

            if (result)
            {
                foreach (var candidateParent in this.vertexes.Where(v => v.edges.Any(e => e.toVertex == vertex)))
                {
                    candidateParent.edges.RemoveAll(x => x.toVertex == vertex);
                }
            }

            return result;
        }

        public void AddEdge(T fromValue, T toValue, int cost)
        {
            var fromVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(fromValue));
            var toVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(toValue));

            if (fromVertex == null)
            {
                fromVertex = new Vertex(fromValue);
                vertexes.Add(fromVertex);
            }

            if (toVertex == null)
            {
                toVertex = new Vertex(toValue);
                vertexes.Add(toVertex);
            }

            fromVertex.edges.Add(new Edge(toVertex, cost));
        }

        public void RemoveEdge(T fromValue, T toValue, int cost)
        {
            var fromVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(fromValue));

            if (fromVertex == null)
            {
                fromVertex = new Vertex(fromValue);
                vertexes.Add(fromVertex);
            }

            fromVertex.edges.RemoveAll(x => x.cost == cost && x.toVertex.value.Equals(toValue));
        }

        public void RemoveEdge(T fromValue, T toValue)
        {
            var fromVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(fromValue));

            if (fromVertex == null)
            {
                fromVertex = new Vertex(fromValue);
                vertexes.Add(fromVertex);
            }

            fromVertex.edges.RemoveAll(x => x.toVertex.value.Equals(toValue));
        }

        public void Clear()
        {
            this.vertexes.Clear();
        }


        public IEnumerable<T> GetAllValues()
        {
            return this.vertexes.Select(x => x.value);
        }

        public IEnumerable<T> BFS(T startValue)
        {
            var startVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(startValue));

            if (startVertex == null)
            {
                yield break;
            }

            var queue = new Queue<Vertex>();
            var used = new HashSet<Vertex>();

            queue.Enqueue(startVertex);
            used.Add(startVertex);

            while (queue.Count > 0)
            {
                var currVertex = queue.Dequeue();

                yield return currVertex.value;

                foreach (var edge in currVertex.edges)
                {
                    if (used.Contains(edge.toVertex))
                    {
                        continue;
                    }

                    used.Add(edge.toVertex);
                    queue.Enqueue(edge.toVertex);
                }
            }
        }

        public Dictionary<T, int> FortBelman(T startValue)
        {
            var startVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(startValue));

            if (startVertex == null)
            {
                return new Dictionary<T, int>();
            }

            var dic = new Dictionary<T, int>();
            var children = startVertex.edges.ToList();


            foreach (var vertex in this.vertexes)
            {
                var cost = 0;

                if (vertex != startVertex)
                {
                    cost = int.MaxValue;

                    var edge = children.Where(x => x.toVertex.value.Equals(vertex.value)).OrderBy(x => x.cost).FirstOrDefault();

                    if (edge != null)
                    {
                        cost = edge.cost;
                    }
                }

                dic.Add(vertex.value, cost);
            }

            var vertexes = this.vertexes.ToList();

            for (int i = 1; i < vertexes.Count - 2; i++)
            {
                for (int j = 0; j < vertexes.Count; j++)
                {
                    for (int k = 0; k < vertexes.Count; k++)
                    {
                        var vertJ = vertexes[j];
                        var cost = dic[vertJ.value];

                        var vertK = vertexes[k];
                        var costK = dic[vertK.value];

                        var edge = vertK.edges.Where(x => x.toVertex == vertJ).OrderBy(x => x.cost).FirstOrDefault();
                        var costTo = edge == null ? int.MaxValue : edge.cost;

                        if (cost > costK + costTo)
                        {
                            dic[vertJ.value] = costK + costTo;
                        }
                    }
                }
            }

            return dic;
        }

        public int[] Dijkstra(int startValue)
        {
            var startVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(startValue));

            if (startVertex == null)
            {
                return new int[this.vertexes.Count];
            }

            int[,] graph = new int[this.vertexes.Count, this.vertexes.Count];

            var vertexesList = this.vertexes.ToList();

            var startIndex = vertexesList.IndexOf(startVertex);

            for (int i = 0; i < vertexesList.Count; i++)
            {
                for (int j = 0; j < vertexesList.Count; j++)
                {
                    var cost = int.MaxValue;

                    var vert = vertexesList[i];
                    var toVert = vertexesList[j];

                    var edge = vert.edges.Where(x => x.toVertex == toVert).OrderBy(x => x.cost).FirstOrDefault();

                    if(edge != null)
                    {
                        cost = edge.cost;
                    }

                    graph[i, j] = cost;
                }
            }

            return Dijkstra(graph, startIndex);
        }

        private int[] Dijkstra(int[,] graph, int source)
        {
            var verticesCount = graph.GetLength(0);

            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            return distance;
        }


        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public IEnumerable<T> DFS(T startValue)
        {
            var startVertex = this.vertexes.FirstOrDefault(x => x.value.Equals(startValue));

            if (startVertex == null)
            {
                yield break;
            }

            var used = new HashSet<Vertex>();

            foreach (var value in this.DFS(used, startVertex))
            {
                yield return value;
            }
        }

        public bool HasCircle()
        {
            var used = new HashSet<Vertex>();

            foreach (var vertex in this.vertexes)
            {
                if (used.Contains(vertex))
                {
                    continue;
                }

                if (HasCircle(used, vertex))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasCircle(HashSet<Vertex> used, Vertex currentVertex)
        {
            used.Add(currentVertex);

            foreach (var edge in currentVertex.edges)
            {
                if (used.Contains(edge.toVertex))
                {
                    return true;
                }

                if (HasCircle(used, edge.toVertex))
                {
                    return true;
                }
            }

            return false;
        }

        private IEnumerable<T> DFS(HashSet<Vertex> used, Vertex currentVertex)
        {
            yield return currentVertex.value;

            used.Add(currentVertex);

            foreach (var edge in currentVertex.edges)
            {
                if (used.Contains(edge.toVertex))
                {
                    continue;
                }

                foreach (var value in this.DFS(used, edge.toVertex))
                {
                    yield return value;
                }
            }
        }

        private class Vertex
        {
            public readonly T value;

            public readonly List<Edge> edges;

            public Vertex(T value)
            {
                this.value = value;
                this.edges = new List<Edge>();
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var vertex = obj as Vertex;

                if (vertex == null)
                {
                    return false;
                }

                return this.value.Equals(vertex.value);
            }
        }

        private class Edge
        {
            public readonly Vertex toVertex;
            public readonly int cost;

            public Edge(Vertex toVertex, int cost)
            {
                this.toVertex = toVertex;
                this.cost = cost;
            }
        }
    }
}
