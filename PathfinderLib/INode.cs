namespace PathfinderLib {
    /// <summary>
    /// T must be same type that corrent impementation this interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INode<T> where T : INode<T> {
        int CostFor(IAgent agent);
        bool IsWalkableFor(IAgent agent);
        int HeuristicCostTo(T n);
        bool IsNeighborTo(T n);
    }
}