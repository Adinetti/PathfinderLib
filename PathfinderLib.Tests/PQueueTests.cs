using AutoFixture;
using NUnit.Framework;

namespace PathfinderLib.Tests
{
    class PQueueTests
    {
        PQueue<TileNode> queue;
        Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
        }

        [Test]
        public void Count_should_become_greater_after_Enqueue()
        {
            int expectCount = 1;
            queue = new PQueue<TileNode>();

            queue.Enqueue(new TileNode(0, 0), 0);
            int actualeCount = queue.Count;

            Assert.AreEqual(expectCount, actualeCount);
        }

        [Test]
        public void Count_should_become_less_after_Dequeue()
        {
            int expectedCount = 0;
            queue = new PQueue<TileNode>();

            queue.Enqueue(new TileNode(0, 0), 1);
            queue.Dequeue();
            int actualeCount = queue.Count;

            Assert.AreEqual(expectedCount, actualeCount);
        }

        [Test]
        public void Dequeue_should_return_first_object_with_lowest_priority()
        {
            TileNode expectedTile = fixture.Create<TileNode>();
            queue = new PQueue<TileNode>();

            queue.Enqueue(new TileNode(0, 0), 1);
            queue.Enqueue(expectedTile, 0);
            queue.Enqueue(new TileNode(1, 0), 0);
            TileNode actualeTile = queue.Dequeue();

            Assert.AreEqual(expectedTile, actualeTile);
        }

        [Test]
        public void Dequeue_should_return_first_come_object_if_all_objects_has_same_priority()
        {
            TileNode expectedTile = fixture.Create<TileNode>();
            queue = new PQueue<TileNode>();

            queue.Enqueue(expectedTile, 0);
            queue.Enqueue(new TileNode(0, 0), 0);
            queue.Enqueue(new TileNode(1, 0), 0);
            TileNode actualeTile = queue.Dequeue();

            Assert.AreEqual(expectedTile, actualeTile);
        }
    }
}
