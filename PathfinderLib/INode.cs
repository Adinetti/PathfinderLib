using System.Collections.Generic;

namespace Pathfinder
{
    public interface INode
    {
        int Cost { get; }
        bool IsWalkable();
        int HeuristicCostTo(INode n);
        void SetNeighbor(INode neighbor);
        INode[] GetNeighbors();
    }
}