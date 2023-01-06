namespace TransConnect.UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestShortestPath()
    {
        //test the ShortestPath method
        Graph graph = new Graph();

        graph.AddVertex("A", new Dictionary<string, int>() { { "B", 7 }, { "C", 8 } });
        graph.AddVertex("B", new Dictionary<string, int>() { { "A", 7 }, { "F", 2 } });
        graph.AddVertex("C", new Dictionary<string, int>() { { "A", 8 }, { "F", 6 }, { "G", 4 } });
        graph.AddVertex("D", new Dictionary<string, int>() { { "F", 8 } });
        graph.AddVertex("E", new Dictionary<string, int>() { { "H", 1 } });
        graph.AddVertex("F", new Dictionary<string, int>() { { "B", 2 }, { "C", 6 }, { "D", 8 }, { "G", 9 }, { "H", 3 } });
        graph.AddVertex("G", new Dictionary<string, int>() { { "C", 4 }, { "F", 9 } });
        graph.AddVertex("H", new Dictionary<string, int>() { { "E", 1 }, { "F", 3 } });

        List<string> path = graph.ShortestPath("A", "H");

        Assert.AreEqual("A -> B -> F -> H", string.Join(" -> ", path));
    }
}
