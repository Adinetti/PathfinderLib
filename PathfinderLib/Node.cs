using System;
using System.Collections.Generic;

namespace  Pathfinder {    
    public abstract class Node {
        protected List<Node> neighbors;
        public int Cost { get; private set; }

        public Node(int cost) {
            neighbors = new List<Node>();
            Cost      = cost;
        }

        public virtual bool IsWalkable() {
            return true;
        }
        
        public abstract int HeuristicCostTo(Node n);

        public void SetNeighbor(Node neighbor) {
            neighbors.Add(neighbor);
            neighbor.neighbors.Add(this);
        }
            
        public Node[] Neighbors {
            get {
                return neighbors.ToArray();
            }
        }
    }
}