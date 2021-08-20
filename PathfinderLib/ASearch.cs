using System;

namespace PathfinderLib {
    [Serializable]
    public class ASearch<T> : DSearch<T> where T : INode<T> {
        public ASearch() : base() {
            OnSearch += SearchPath;
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
                    if (n.IsWalkableFor(agent)) {
                        int cost = pathcost[root] + Math.Abs(n.CostFor(agent)) + 1;
                        if (!pathcost.ContainsKey(n) || cost < pathcost[n]) {
                            pathcost[n] = cost;
                            fronter.Enqueue(n, cost + end.HeuristicCostTo(n));
                            parents[n] = root;
                        }
                    }
                }
            }
        }
    }
}