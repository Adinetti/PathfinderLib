using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderLib {
    public interface IGraph<T> where T : INode<T> {
        int CountOfNeighbors(T node);
        T GetNeighbor(T node, int order);
    }
}
