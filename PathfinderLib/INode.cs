namespace PathfinderLib {
    public interface INode {
        int CostFor(IAgent agent);
        bool IsWalkableFor(IAgent agent);
    }
}