using System;
using System.Collections.Generic;

namespace PathfinderLib {
    [Serializable]
    public abstract class Pathfinder<T> where T : INode {
        protected event Action<T> OnInit;
        protected event Action<T> OnSearch;

        protected List<T> path;
        protected Dictionary<T, T> parents;
        protected IAgent agent;
        protected IGraph<T> graph;

        protected Pathfinder() {
            parents = new Dictionary<T, T>();
            path = new List<T>();
        }

        public List<T> Search(IAgent agent, T start, T end, IGraph<T> graph) {
            path.Clear();
            parents.Add(start, start);
            this.agent = agent;
            this.graph = graph;
            if (OnInit != null && OnSearch != null) {
                OnInit(start);
                OnSearch(end);
                CreatePath(start, end);
            }
            return path;
        }

        private void CreatePath(T start, T end) {
            if (parents.TryGetValue(end, out T node)) {
                path.Add(end);
                while (path.Contains(start) == false) {
                    path.Add(node);
                    node = parents[node];
                }
            }
        }
    }
}