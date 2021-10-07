using System;
using System.Collections.Generic;

namespace PathfinderLib {
    [Serializable]
    public class DSearch<T> : Pathfinder<T> where T : INode {
        [NonSerialized] protected PQueue<T> fronter;
        protected Dictionary<T, int> pathcost;

        public DSearch() {
            OnInit += Init;
            OnSearch += SearchPath;
        }

        protected void Init(T start) {
            fronter = new PQueue<T>();
            fronter.Enqueue(start, 0);
            pathcost = new Dictionary<T, int> {
                [start] = 0
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
                    var n = graph.GetNeighborFor(root, i);
                    if (n.IsWalkableFor(agent)) {
                        int cost = pathcost[root] + Math.Abs(n.CostFor(agent)) + 1;
                        if (!pathcost.ContainsKey(n) || cost < pathcost[n]) {
                            pathcost[n] = cost;
                            fronter.Enqueue(n, cost);
                            parents[n] = root;
                        }
                    }
                }
            }
        }
    }
}