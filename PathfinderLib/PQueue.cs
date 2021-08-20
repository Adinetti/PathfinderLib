using System;
using System.Collections.Generic;

namespace PathfinderLib {
    [Serializable]
    public class PQueue<T> where T : INode<T> {
        private List<Tuple<T, float>> elements;

        public int Count => elements.Count;

        public PQueue() {
            elements = new List<Tuple<T, float>>();
        }

        public void Enqueue(T node, float priority) {
            elements.Add(Tuple.Create(node, priority));
        }

        public T Dequeue() {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++) {
                if (elements[i].Item2 < elements[bestIndex].Item2) {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Item1;
            elements.RemoveAt(bestIndex);
            return bestItem;
        }

        public void Clear() {
            elements = new List<Tuple<T, float>>();
        }
    }
}
