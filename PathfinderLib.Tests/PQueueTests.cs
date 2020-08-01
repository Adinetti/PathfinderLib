using NUnit.Framework;
using Pathfinder;
using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderLib.Tests
{
    public class PQueueTests
    {
        int queueAmount;
        int maxPriority;
        PQueue<string> stringQueueMinFirst;
        PQueue<string> stringQueueMaxFirst;
        Queue<string> ordinaryQueue;

        [SetUp]
        public void Setup()
        {
            queueAmount = 11;
            maxPriority = 2;
            InitQueues();
            SetQueues();
        }

        private void InitQueues()
        {
            stringQueueMinFirst = new PQueue<string>();
            stringQueueMaxFirst = new PQueue<string>(false);
            ordinaryQueue = new Queue<string>();
        }

        private void SetQueues()
        {
            for (int i = 0; i < queueAmount; i++)
            {
                int priority = i % (maxPriority + 1);
                string str = $"{priority}";
                AddToQueues(priority, str);
            }
        }

        private void AddToQueues(int priority, string str)
        {
            stringQueueMinFirst.Enqueue(str, priority);
            stringQueueMaxFirst.Enqueue(str, priority);
            ordinaryQueue.Enqueue(str);
        }

        [Test]
        public void QueueAmoutTest()
        {
            Assert.AreEqual(queueAmount, stringQueueMinFirst.Count);
            Assert.AreEqual(queueAmount, stringQueueMaxFirst.Count);
            Assert.AreEqual(queueAmount, ordinaryQueue.Count);
        }

        [Test]
        public void FirstObjectInQueue()
        {
            string strMin = stringQueueMinFirst.Dequeue();
            string strMax = stringQueueMaxFirst.Dequeue();
            string strOrd = ordinaryQueue.Dequeue();
            Assert.AreEqual("0", strMin);
            Assert.AreEqual($"{maxPriority}", strMax);
            Assert.AreEqual("0", strOrd);
        }

        [Test]
        public void LastObjectInQueue()
        {
            string strMin = "";
            string strMax = "";
            string strOrd = "";

            for (int i = 0; i < queueAmount; i++)
            {
                strMin = stringQueueMinFirst.Dequeue();
                strMax = stringQueueMaxFirst.Dequeue();
                strOrd = ordinaryQueue.Dequeue();
            }

            Assert.AreEqual($"{maxPriority}", strMin);
            Assert.AreEqual("0", strMax);
            Assert.AreEqual("1", strOrd);
        }

        [Test]
        public void SecondObjectInQueue()
        {
            string strMin = "";
            string strMax = "";
            string strOrd = "";

            for (int i = 0; i < 2; i++)
            {
                strMin = stringQueueMinFirst.Dequeue();
                strMax = stringQueueMaxFirst.Dequeue();
                strOrd = ordinaryQueue.Dequeue();
            }

            Assert.AreEqual("0", strMin);
            Assert.AreEqual($"{maxPriority}", strMax);
            Assert.AreEqual("1", strOrd);
        }
    }
}
