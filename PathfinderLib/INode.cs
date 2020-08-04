using System.Collections.Generic;

namespace Pathfinder
{
    public interface INode<T>  where T : INode<T>
    {
        int Cost { get; }
        bool IsWalkable();
        int HeuristicCostTo(T n);
        void AddNeighbor(T neighbor);
        T[] GetNeighbors();
    }    
}