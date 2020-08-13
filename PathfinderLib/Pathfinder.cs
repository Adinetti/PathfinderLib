using System.Collections.Generic;

namespace PathfinderLib
{
    public abstract class Pathfinder<T1> where T1 : INode<T1>
    {
        protected delegate void InitDelegate(T1 start);
        protected event InitDelegate OnInit;

        protected delegate void SearchDelegate(T1 end);
        protected event SearchDelegate OnSearch;

        protected List<T1> path;
        protected Dictionary<T1, T1> parents;

        public List<T1> Search(T1 start, T1 end)
        {
            parents = new Dictionary<T1, T1>
            {
                [start] = start
            };
            if (OnInit != null && OnSearch != null)
            {
                OnInit(start);
                OnSearch(end);
                CreatePath(start, end);
            }
            return path;
        }

        private void CreatePath(T1 start, T1 end)
        {
            T1 node;
            if (parents.TryGetValue(end, out node))
            {
                path = new List<T1>
                {
                    end
                };
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