using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderLib {
    public interface IGraph<T> where T : INode {
        int CountOfNeighbors(T node);
        T GetNeighborFor(T node, int neighborIndex);
        int HeuristicCost(INode start, INode end);
    }
}
