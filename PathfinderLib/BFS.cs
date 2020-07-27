using System;
using System.Collections.Generic;

namespace  Pathfinder {
    public class BFS<T>  : Pathfinder<T> where T : Node {
        Queue<T> fronter;
        List<T> visited;
        
        public BFS() {
            OnInit += Init;
            OnSearch += SearchPath;
        }

        void Init(T start) {
            fronter = new Queue<T>();
            fronter.Enqueue(start);
            visited = new List<T>();
            visited.Add(start);
        }

        void SearchPath(T end) {
            while (fronter.Count > 0) {
                T root = fronter.Dequeue();
                if (root == end) {
                    break;
                }
                foreach (T n in root.Neighbors) {
                    if (n.IsWalkable() && !visited.Contains(n)) {
                        parents.Add(n, root);
                        visited.Add(n);
                        fronter.Enqueue(n);
                    }
                }
            }
        }
    }
}