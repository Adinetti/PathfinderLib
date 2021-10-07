using AutoFixture;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace PathfinderLib.Tests {
    [TestFixture()]
    class PathfinderTests {
        private IAgent _agent;
        private BFS<INode> _BFS;
        private DSearch<INode> _dSearch;
        private ASearch<INode> _aSearch;
        private Mock<IGraph<INode>> _graphMock;
        private INode _unwalkableNode;
        private INode _nodeAtoBC;
        private INode _nodeBtoAC;
        private INode _nodeCtoABD;
        private INode _nodeDtoC;

        [SetUp]
        public void Setup() {
            _agent = new Mock<IAgent>().Object;
            _BFS = new BFS<INode>();
            _dSearch = new DSearch<INode>();
            _aSearch = new ASearch<INode>();

            _nodeAtoBC = CreateNode(1, true);
            _nodeBtoAC = CreateNode(1, true);
            _nodeCtoABD = CreateNode(1, true);
            _nodeDtoC = CreateNode(1, true);
            _unwalkableNode = CreateNode(1, false);

            _graphMock = new Mock<IGraph<INode>>();
            _graphMock.Setup(x => x.CountOfNeighbors(_nodeAtoBC)).Returns(3);
            _graphMock.Setup(x => x.CountOfNeighbors(_nodeBtoAC)).Returns(2);
            _graphMock.Setup(x => x.CountOfNeighbors(_nodeCtoABD)).Returns(3);
            _graphMock.Setup(x => x.CountOfNeighbors(_nodeDtoC)).Returns(1);

            _graphMock.Setup(x => x.GetNeighborFor(_nodeAtoBC, 0)).Returns(_nodeBtoAC);
            _graphMock.Setup(x => x.GetNeighborFor(_nodeAtoBC, 1)).Returns(_nodeCtoABD);
            _graphMock.Setup(x => x.GetNeighborFor(_nodeAtoBC, 2)).Returns(_unwalkableNode);

            _graphMock.Setup(x => x.GetNeighborFor(_nodeBtoAC, 0)).Returns(_nodeAtoBC);
            _graphMock.Setup(x => x.GetNeighborFor(_nodeBtoAC, 1)).Returns(_nodeCtoABD);

            _graphMock.Setup(x => x.GetNeighborFor(_nodeCtoABD, 0)).Returns(_nodeAtoBC);
            _graphMock.Setup(x => x.GetNeighborFor(_nodeCtoABD, 1)).Returns(_nodeBtoAC);
            _graphMock.Setup(x => x.GetNeighborFor(_nodeCtoABD, 2)).Returns(_nodeDtoC);

            _graphMock.Setup(x => x.GetNeighborFor(_nodeDtoC, 0)).Returns(_nodeCtoABD);

            _graphMock.Setup(x => x.HeuristicCost(_nodeAtoBC, _nodeBtoAC)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeAtoBC, _nodeCtoABD)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeAtoBC, _nodeDtoC)).Returns(2);
            _graphMock.Setup(x => x.HeuristicCost(_nodeAtoBC, _unwalkableNode)).Returns(1);

            _graphMock.Setup(x => x.HeuristicCost(_nodeBtoAC, _nodeAtoBC)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeBtoAC, _nodeCtoABD)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeBtoAC, _nodeDtoC)).Returns(2);
            _graphMock.Setup(x => x.HeuristicCost(_nodeBtoAC, _unwalkableNode)).Returns(2);

            _graphMock.Setup(x => x.HeuristicCost(_nodeCtoABD, _nodeAtoBC)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeCtoABD, _nodeBtoAC)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeCtoABD, _nodeDtoC)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeCtoABD, _unwalkableNode)).Returns(2);

            _graphMock.Setup(x => x.HeuristicCost(_nodeDtoC, _nodeAtoBC)).Returns(2);
            _graphMock.Setup(x => x.HeuristicCost(_nodeDtoC, _nodeBtoAC)).Returns(2);
            _graphMock.Setup(x => x.HeuristicCost(_nodeDtoC, _nodeCtoABD)).Returns(1);
            _graphMock.Setup(x => x.HeuristicCost(_nodeDtoC, _unwalkableNode)).Returns(2);
        }

        private INode CreateNode(int cost, bool isWalkable) {
            Mock<INode> nodeMock = new Mock<INode>();
            nodeMock.Setup(x => x.CostFor(_agent)).Returns(cost);
            nodeMock.Setup(x => x.IsWalkableFor(_agent)).Returns(isWalkable);
            return nodeMock.Object;
        }

        #region UnwalkableNode
        [Test()]
        public void Search_of_BFS_should_return_empty_list_for_nodeAtoBC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_empty_list_for_nodeAtoBC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_empty_list_for_nodeAtoBC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_empty_list_for_nodeBtoAC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _BFS.Search(_agent, _nodeBtoAC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_empty_list_for_nodeBtoAC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _dSearch.Search(_agent, _nodeBtoAC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_empty_list_for_nodeBtoAC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _aSearch.Search(_agent, _nodeBtoAC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_empty_list_for_nodeCtoABD_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _BFS.Search(_agent, _nodeCtoABD, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_empty_list_for_nodeCtoABD_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _dSearch.Search(_agent, _nodeCtoABD, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_empty_list_for_nodeCtoABD_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _aSearch.Search(_agent, _nodeCtoABD, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_empty_list_for_nodeDtoC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _BFS.Search(_agent, _nodeDtoC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_empty_list_for_nodeDtoC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _dSearch.Search(_agent, _nodeDtoC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_empty_list_for_nodeDtoC_and_unwalkableNode() {
            var expectedValue = 0;

            var actualValue = _aSearch.Search(_agent, _nodeDtoC, _unwalkableNode, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region BFS_for_nodeAtoBC_and_nodeBtoAC
        [Test()]
        public void Search_of_BFS_should_return_two_count_list_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = 2;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_list_with_nodeBtoAC_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = true;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Contains(_nodeBtoAC);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = true;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region BFS_for_nodeAtoBC_and_nodeCtoABD
        [Test()]
        public void Search_of_BFS_should_return_two_count_list_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = 2;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_list_with_nodeCtoABD_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = true;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Contains(_nodeCtoABD);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = true;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region BFS_for_nodeAtoBC_and_nodeDtoC
        [Test()]
        public void Search_of_BFS_should_return_three_count_list_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = 3;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_list_with_nodeCtoABD_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeCtoABD);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_BFS_should_return_list_with_nodeDtoC_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _BFS.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeDtoC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region DSearch_for_nodeAtoBC_and_nodeBtoAC
        [Test()]
        public void Search_of_DSearch_should_return_two_count_list_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = 2;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_list_with_nodeBtoAC_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = true;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Contains(_nodeBtoAC);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = true;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region DSearch_for_nodeAtoBC_and_nodeCtoABD
        [Test()]
        public void Search_of_DSearch_should_return_two_count_list_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = 2;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_list_with_nodeCtoABD_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = true;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Contains(_nodeCtoABD);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = true;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region DSearch_for_nodeAtoBC_and_nodeDtoC
        [Test()]
        public void Search_of_DSearch_should_return_three_count_list_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = 3;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_list_with_nodeCtoABD_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeCtoABD);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_DSearch_should_return_list_with_nodeDtoC_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _dSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeDtoC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region ASearch_for_nodeAtoBC_and_nodeBtoAC
        [Test()]
        public void Search_of_ASearch_should_return_two_count_list_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = 2;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_list_with_nodeBtoAC_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = true;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Contains(_nodeBtoAC);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeBtoAC() {
            var expectedValue = true;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeBtoAC, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region ASearch_for_nodeAtoBC_and_nodeCtoABD
        [Test()]
        public void Search_of_ASearch_should_return_two_count_list_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = 2;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_list_with_nodeCtoABD_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = true;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Contains(_nodeCtoABD);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeCtoABD() {
            var expectedValue = true;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeCtoABD, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion

        #region ASearch_for_nodeAtoBC_and_nodeDtoC
        [Test()]
        public void Search_of_ASearch_should_return_three_count_list_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = 3;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_list_with_nodeCtoABD_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeCtoABD);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_list_with_nodeAtoBC_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeAtoBC);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        public void Search_of_ASearch_should_return_list_with_nodeDtoC_for_nodeAtoBC_and_nodeDtoC() {
            var expectedValue = true;

            var actualValue = _aSearch.Search(_agent, _nodeAtoBC, _nodeDtoC, _graphMock.Object).Contains(_nodeDtoC);

            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion
    }
}