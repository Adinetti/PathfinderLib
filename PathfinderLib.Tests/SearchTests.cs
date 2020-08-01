using NUnit.Framework;
using Pathfinder;
using System.Collections.Generic;

namespace PathfinderLib.Tests
{
    public class SearchTests
    {
        private Tile[] tiles;
        private BFS<Tile> bfs;
        private DSearch<Tile> dSearch;
        private ASearch<Tile> aSearch;

        [SetUp]
        public void Setup()
        {
            tiles = Tile.CreateTestMap();
            bfs = new BFS<Tile>();
            dSearch = new DSearch<Tile>();
            aSearch = new ASearch<Tile>();
        }

        [Test]
        public void SearchToUnreachableNode()
        {
            Tile start = tiles[0];
            Tile end = tiles[tiles.Length - 1];
            List<Tile> path1 = bfs.Search(start, end);
            List<Tile> path2 = dSearch.Search(start, end);
            List<Tile> path3 = aSearch.Search(start, end);
            Assert.AreEqual(null, path1);
            Assert.AreEqual(null, path2);
            Assert.AreEqual(null, path3);

        }

        [Test]
        public void SearchPathFromStartToStartNode()
        {
            Tile start = tiles[0];
            List<Tile> path1 = bfs.Search(start, start);
            List<Tile> path2 = dSearch.Search(start, start);
            List<Tile> path3 = aSearch.Search(start, start);
            Assert.AreEqual(0, path1.Count);
            Assert.AreEqual(0, path2.Count);
            Assert.AreEqual(0, path3.Count);
        }

        [Test]
        public void SearchPathFromStartToNearTileNode()
        {
            Tile start = tiles[0];
            Tile end = tiles[1];
            List<Tile> path1 = bfs.Search(start, end);
            List<Tile> path2 = dSearch.Search(start, end);
            List<Tile> path3 = aSearch.Search(start, end);
            Assert.AreEqual(1, path1.Count);
            Assert.AreEqual(1, path2.Count);
            Assert.AreEqual(1, path3.Count);
        }

        [Test]
        public void SearchPathFromStartToReachableTileNode()
        {
            Tile start = tiles[0];
            Tile end = tiles[76];
            List<Tile> path1 = bfs.Search(start, end);
            List<Tile> path2 = dSearch.Search(start, end);
            List<Tile> path3 = aSearch.Search(start, end);
            Assert.AreEqual(13, path1.Count);
            Assert.AreEqual(13, path2.Count);
            Assert.AreEqual(13, path3.Count);
        }
    }
}