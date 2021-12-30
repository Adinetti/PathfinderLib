using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderLib {
    public interface IPQueue<T> where T : INode {
        int Count { get; }
        void Enqueue(T node, float priority);
        T Dequeue();
        void Clear();
    }
}
