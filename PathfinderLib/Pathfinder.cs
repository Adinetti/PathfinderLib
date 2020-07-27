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
            path = new List<T>();
            parents = new Dictionary<T, T>();
            if (OnInit != null && OnSearch != null)
            {
                OnInit(start);
                OnSearch(end);
                CreatePath(start, end);
            }
            return path;
        }

        void CreatePath(T start, T end)
        {
            T node;
            if (parents.TryGetValue(end, out node))
            {
                path.Add(end);
                path.Add(node);
                while (node.Equals(start))
                {
                    node = parents[node];
                    path.Add(node);
                }
            }
        }
    }
}