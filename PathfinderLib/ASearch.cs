using System;
using System.Collections.Generic;

namespace  Pathfinder {    
    public class ASearch<T>  : DSearch<T> where T : Node {
        public ASearch() : base() {
            OnSearch += SearchPath;
        }


        void SearchPath(T end) {
            while (fronter.Count > 0) {
                T root = fronter.Dequeue();
                if (root == end) {
                    break;
                }
                foreach (T n in root.Neighbors) {
                    if (n.IsWalkable()) {
                        int cost = pathcost[root] + n.Cost;
                        if (!pathcost.ContainsKey(n) || cost <  pathcost[n]) {
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