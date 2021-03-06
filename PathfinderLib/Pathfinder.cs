﻿using System.Collections.Generic;

namespace PathfinderLib {
    public abstract class Pathfinder<T1> where T1 : INode<T1> {
        protected delegate void InitDelegate(T1 start);
        protected event InitDelegate OnInit;

        protected delegate void SearchDelegate(T1 end);
        protected event SearchDelegate OnSearch;

        protected List<T1> path;
        protected Dictionary<T1, T1> parents;

        public List<T1> Search(T1 start, T1 end) {
            path = new List<T1>();
            parents = new Dictionary<T1, T1>();
            parents[start] = start;
            if (OnInit != null && OnSearch != null) {
                OnInit(start);
                OnSearch(end);
                CreatePath(start, end);
            }
            return path;
        }

        private void CreatePath(T1 start, T1 end) {
            T1 node;
            if (parents.TryGetValue(end, out node)) {
                path.Add(end);
                while (path.Contains(start) == false) {
                    path.Add(node);
                    node = parents[node];
                }                
            }
        }
    }
}