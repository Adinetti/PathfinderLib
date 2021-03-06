﻿using System;

namespace PathfinderLib {
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
                foreach (T n in root.GetNeighbors()) {
                    if (n.IsWalkable()) {
                        int cost = pathcost[root] + Math.Abs(n.Cost) + 1;
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