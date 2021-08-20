using System.Collections.Generic;

namespace PathfinderLib {
    [System.Serializable]
    public class BFS<T> : Pathfinder<T> where T : INode<T> {
        private Queue<T> fronter;
        private List<T> visited;

        public BFS() {
            OnInit += Init;
            OnSearch += SearchPath;
        }

        private void Init(T start) {
            fronter = new Queue<T>();
            fronter.Enqueue(start);
            visited = new List<T>
            {
                start
            };
        }

        private void SearchPath(T end) {
            while (fronter.Count > 0) {
                T root = fronter.Dequeue();
                if (root.Equals(end)) {
                    break;
                }
                int neighbors = graph.CountOfNeighbors(root);
                for (int i = 0; i < neighbors; i++) {
                    var n = graph.GetNeighbor(root, i);
                    if (n.IsWalkableFor(agent) && !visited.Contains(n)) {
                        parents.Add(n, root);
                        visited.Add(n);
                        fronter.Enqueue(n);
                    }
                }
            }
        }
    }
}