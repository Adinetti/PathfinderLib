using System.Collections.Generic;

namespace PathfinderLib
{
    /// <summary>
    /// T must be same type that corrent impementation this interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INode<T>  where T : INode<T>
    {
        int Cost { get; }
        bool IsWalkable();
        int HeuristicCostTo(T n);
        void AddNeighbor(T neighbor);
        T[] GetNeighbors();
    }    
}