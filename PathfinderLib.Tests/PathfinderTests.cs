using AutoFixture;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace PathfinderLib.Tests
{
    class PathfinderTests
    {
        TileNode[] tiles;
        int widthMap;
        int heightMap;
        Fixture fixture;
        public PathfinderTests()
        {
            fixture = new Fixture();
            widthMap = 3;
            heightMap = 3;
            tiles = new TileNode[widthMap * heightMap];

            for (int x = 0; x < widthMap; x++)
            {
                for (int y = 0; y < heightMap; y++)
                {
                    TileNode tile = new TileNode(x, y, 0, true);
                    if (x > 0)
                        tile.AddNeighbor(tiles[x - 1 + y * widthMap]);
                    if (y > 0)
                        tile.AddNeighbor(tiles[x + (y - 1) * widthMap]);
                    tiles[x + y * widthMap] = tile;
                }
            }
        }

        public void CreatePath_should_return_null_for_unreachable_tile(Pathfinder<TileNode> pathfinder)
        {
            TileNode start = fixture.Create<TileNode>();
            TileNode end = fixture.Create<TileNode>();

            List<TileNode> actualPath = pathfinder.Search(start, end);

            Assert.IsNull(actualPath);
        }

        public void CreatePath_return_list_with_count_equal_length_of_shortest_path(Pathfinder<TileNode> pathfinder)
        {
            TileNode start = tiles[0];
            TileNode end = tiles[widthMap - 1];
            int expectedLength = widthMap - 1;

            int actualLength = pathfinder.Search(start, end).Count;

            Assert.AreEqual(expectedLength, actualLength);
        }

        public void CreatePath_return_list_with_count_equal_zero_if_start_and_end_is_same_node(Pathfinder<TileNode> pathfinder)
        {
            TileNode start = tiles[0];
            TileNode end = start;
            int expectedLength = 0;

            int actualLength = pathfinder.Search(start, end).Count;

            Assert.AreEqual(expectedLength, actualLength);
        }
    }
}
