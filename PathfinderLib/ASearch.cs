namespace Pathfinder
{
    public class ASearch<T> : DSearch<T> where T : INode
    {
        public ASearch() : base()
        {
            OnSearch += SearchPath;
        }

        void SearchPath(T end)
        {
            while (fronter.Count > 0)
            {
                T root = fronter.Dequeue();
                if (root.Equals(end))
                {
                    break;
                }
                foreach (T n in root.GetNeighbors())
                {
                    if (n.IsWalkable())
                    {
                        int cost = pathcost[root] + n.Cost;
                        if (!pathcost.ContainsKey(n) || cost < pathcost[n])
                        {
                            pathcost[n] = cost;
                            fronter.Enqueue(n, cost);
                            parents[n] = root;
                        }
                    }
                }
            }
        }
    }
}