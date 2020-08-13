namespace PathfinderLib
{
    public class PQueue<T> 
    {
        private class PObject<T> 
        {
            public T obj;
            public int priority;
            public PObject<T> prev;
            public PObject<T> next;

            public PObject(T obj, int priority)
            {
                this.obj = obj;
                this.priority = priority;
            }
        }

        private PObject<T> start;
        public bool MinPriorityFirst { get; private set; }
        public int Count { get; private set; }

        public PQueue() : this(true) { }

        public PQueue(bool minPriorityFirst)
        {
            MinPriorityFirst = minPriorityFirst;
        }

        public T Dequeue()
        { 
            if (start != null)
            {
                T obj = start.obj;
                start = start.next;
                if (start != null)
                {
                    start.prev = null;
                }
                Count--;
                return obj;
            }
            return default(T);
        }

        public void Enqueue(T obj, int priority)
        {
            PObject<T> newObject = new PObject<T>(obj, priority);
            if (start == null)
            {
                start = newObject;
            }
            else
            {
                PObject<T> currentObj = MinPriorityFirst ? GetMax(priority) : GetMin(priority);
                bool range = MinPriorityFirst ? currentObj.priority <= priority : currentObj.priority >= priority;
                if (range)
                {
                    SetNext(currentObj, newObject);
                }
                else
                {
                    SetPrev(currentObj, newObject);
                }
            }
            Count++;
        }

        private PObject<T> GetMin(int priority)
        {
            PObject<T> pObj = start;
            while (pObj.priority >= priority && (pObj.next != null && pObj.next.priority >= priority))
            {
                pObj = pObj.next;
            }
            return pObj;
        }

        private PObject<T> GetMax(int priority)
        {
            PObject<T> pObj = start;
            while (pObj.priority <= priority && (pObj.next != null && pObj.next.priority <= priority))
            {
                pObj = pObj.next;
            }
            return pObj;
        }

        private void SetNext(PObject<T> currentObj, PObject<T> newObject)
        {
            newObject.prev = currentObj;
            newObject.next = currentObj.next;
            currentObj.next = newObject;
        }

        private void SetPrev(PObject<T> currentObj, PObject<T> newObject)
        {
            newObject.next = currentObj;
            newObject.prev = currentObj.prev;
            currentObj.prev = newObject;
            if (currentObj == start)
            {
                start = newObject;
            }
        }
    }
}