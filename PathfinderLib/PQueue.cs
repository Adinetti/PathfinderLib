using System;
using System.Collections.Generic;

namespace PathfinderLib {
    [Serializable]
    public class PQueue<T> where T : INode {
        private List<Tuple<T, float>> _elements;

        public int Count => _elements.Count;

        public PQueue() {
            _elements = new List<Tuple<T, float>>();
        }

        public void Enqueue(T node, float priority) {
            _elements.Add(Tuple.Create(node, priority));
        }

        public T Dequeue() {
            int bestIndex = 0;

            for (int i = 0; i < _elements.Count; i++) {
                if (_elements[i].Item2 < _elements[bestIndex].Item2) {
                    bestIndex = i;
                }
            }

            T bestItem = _elements[bestIndex].Item1;
            _elements.RemoveAt(bestIndex);
            return bestItem;
        }

        public void Clear() {
            _elements = new List<Tuple<T, float>>();
        }
    }
}
