using NUnit.Framework;

namespace PathfinderLib.Tests {
    class BFSTests {
        BFS<TileNode> bfs;
        PathfinderTests tests;

        [SetUp]
        public void Setup() {
            bfs = new BFS<TileNode>();
            tests = new PathfinderTests();
        }

        [Test]
        public void CreatePath_should_return_null_for_unreachable_tile() {
            tests.CreatePath_should_return_empty_list_for_unreachable_tile(bfs);
        }

        [Test]
        public void CreatePath_return_list_with_count_equal_length_of_shortest_path() {
            tests.CreatePath_return_list_with_count_equal_length_of_shortest_path(bfs);
        }

        [Test]
        public void CreatePath_return_list_with_count_equal_zero_if_start_and_end_is_same_node() {
            tests.CreatePath_return_list_with_count_equal_zero_if_start_and_end_is_same_node(bfs);
        }
    }
}
