using System;
using System.Collections.Generic;

namespace PathfinderLib {
    public class PQueue<T> where T : INode<T> {
        private struct PObject<T1> : IComparable where T1 : INode<T1> {
            public T1 obj;
            public int priority;
            public PObject(T1 obj, int priority) {
                this.obj = obj;
                this.priority = priority;
            }

            public int CompareTo(object obj) {
                if (obj is PObject<T1>) {
                    PObject<T1> pObject = (PObject<T1>)obj;
                    if (pObject.priority >= priority) {
                        if (pObject.priority == priority) {
                            return 0;
                        }
                        return -1;
                    }
                    return 1;
                }
                throw new Exception("Compare impossible");
            }
        }

        private readonly List<PObject<T>> queue;
        public int Count {
            get {
                return queue.Count;
            }
        }

        public PQueue() {
            queue = new List<PObject<T>>();
        }

        public T Dequeue() {
            if (queue.Count > 0) {
                T obj = queue[0].obj;
                queue.RemoveAt(0);
                return obj;
            }
            return default(T);
        }

        public void Enqueue(T obj, int priority) {
            queue.Add(new PObject<T>(obj, priority));
            queue.Sort();
        }
    }
}