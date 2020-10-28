using System;
using System.Collections.Generic;

namespace PathfinderLib {
    public class TileNode : INode<TileNode> {
        List<TileNode> neighbors;
        public int X { get; protected set; }
        public int Y { get; protected set; }

        protected bool walkable;
        protected int cost;
        public virtual int Cost { get => cost; }

        public TileNode(int x, int y, int cost, bool walkable) {
            X = x;
            Y = y;
            this.cost = cost;
            this.walkable = walkable;
            neighbors = new List<TileNode>();
        }

        public void AddNeighbor(TileNode neighbor) {
            if (neighbors == null) {
                neighbors = new List<TileNode>();
            }
            if (neighbors.Contains(neighbor)) {
                return;
            }
            neighbors.Add(neighbor);
            neighbor.AddNeighbor(this);
        }

        public TileNode[] GetNeighbors() {
            return neighbors.ToArray();
        }

        public int HeuristicCostTo(TileNode n) {
            return (int)Math.Sqrt(Math.Pow(X + n.X, 2) + Math.Pow(Y + n.Y, 2));
        }

        public bool IsWalkable() {
            return walkable;
        }

        public bool IsNeighborTo(TileNode sector) {
            return neighbors.Contains(sector);
        }
    }
}
