using Pathfinder;
using System;
using System.Collections.Generic;

namespace PathfinderLib.Tests
{
    internal class Tile : INode
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private bool isWalkable;
        protected List<INode> neighbors;

        public Tile(int x, int y, bool isWalkable)
        {
            X = x;
            Y = y;
            this.isWalkable = isWalkable;
            neighbors = new List<INode>();
        }


        public int Cost
        {
            get
            {
                return 1;
            }
        }

        public INode[] GetNeighbors()
        {
            return neighbors.ToArray();
        }

        public int HeuristicCostTo(INode neighbor)
        {
            if (neighbor is Tile)
            {
                Tile neighborTile = (Tile)neighbor;
                return (int)Math.Sqrt(Math.Pow(X + neighborTile.X, 2) + Math.Pow(Y + neighborTile.Y, 2));
            }

            return int.MaxValue;
        }

        public bool IsWalkable()
        {
            return isWalkable;
        }

        public void AddNeighbor(INode neighbor)
        {
            if (neighbor is Tile)
            {
                neighbors.Add(neighbor);
                ((Tile)neighbor).neighbors.Add(this);
            }
        }

        public static Tile[] CreateTestMap()
        {
            int[] walk = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
                                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };


            Tile[] tiles = new Tile[100];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    bool walkable = walk[x + (y * 10)] == 0;
                    tiles[x + (y * 10)] = new Tile(x, y, walkable);
                    if (x > 0)
                    {
                        tiles[x + (y * 10)].AddNeighbor(tiles[x - 1 + (y * 10)]);
                    }
                    if (y > 0)
                    {
                        tiles[x + (y * 10)].AddNeighbor(tiles[x + ((y - 1) * 10)]);
                    }
                }
            }

            return tiles;
        }
    }
}