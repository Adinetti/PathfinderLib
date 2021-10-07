using System.Collections.Generic;

namespace PathfinderLib {
    [System.Serializable]
    public class BFS<T> : Pathfinder<T> where T : INode {
        private Queue<T> _fronter;
        private List<T> _visited;

        public BFS() {
            OnInit += Init;
            OnSearch += SearchPath;
        }

        private void Init(T start) {
            _fronter = new Queue<T>();
            _fronter.Enqueue(start);
            _visited = new List<T>
            {
                start
            };
        }

        private void SearchPath(T end) {
            while (_fronter.Count > 0) {
                T root = _fronter.Dequeue();
                if (root.Equals(end)) {
                    break;
                }
                int neighbors = graph.CountOfNeighbors(root);
                for (int i = 0; i < neighbors; i++) {
                    var n = graph.GetNeighborFor(root, i);
                    if (n.IsWalkableFor(agent) && !_visited.Contains(n)) {
                        parents.Add(n, root);
                        _visited.Add(n);
                        _fronter.Enqueue(n);
                    }
                }
            }
        }
    }
}