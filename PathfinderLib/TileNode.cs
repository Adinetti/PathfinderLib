using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderLib
{
    public class TileNode : INode<TileNode>
    {
        protected List<TileNode> neighbors;
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public virtual int Cost { get => 1; }

        public void AddNeighbor(TileNode neighbor)
        {
            if (neighbors == null)
            {
                neighbors = new List<TileNode>();
            }
            neighbors.Add(neighbor);
        }

        public TileNode[] GetNeighbors()
        {
            return neighbors.ToArray();
        }

        public int HeuristicCostTo(TileNode n)
        {
            return (int)Math.Sqrt(Math.Pow(X + n.X, 2) + Math.Pow(Y + n.Y, 2));
        }

        public virtual bool IsWalkable()
        {
            return true;
        }
    }
}
