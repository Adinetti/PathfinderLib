using System.Collections.Generic;

namespace Pathfinder
{
    public abstract class Pathfinder<T> where T : INode
    {
        protected delegate void InitDelegate(T start);
        protected event InitDelegate OnInit;

        protected delegate void SearchDelegate(T end);
        protected event SearchDelegate OnSearch;

        protected List<T> path;
        protected Dictionary<T, T> parents;

        public List<T> Search(T start, T end)
        {
            parents = new Dictionary<T, T>();
            parents[start] = start;
            if (OnInit != null && OnSearch != null)
            {
                OnInit(start);
                OnSearch(end);
                CreatePath(start, end);
            }
            return path;
        }

        private void CreatePath(T start, T end)
        {
            T node;
            if (parents.TryGetValue(end, out node))
            {
                path = new List<T>();
                path.Add(end);
                while (!node.Equals(start))
                {
                    path.Add(node);
                    node = parents[node];
                }
                path.Remove(start);
            }
        }
    }
}