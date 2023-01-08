namespace TransConnect.UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestShortestPath()
    {
        //test the ShortestPath method
        Graph graph = new Graph();

        graph.AddVertex("A", new Dictionary<string, (int, TimeSpan)>() { { "B", (7, new TimeSpan(1, 3, 0)) }, { "C", (8, new TimeSpan(4, 34, 0)) } });
        graph.AddVertex("B", new Dictionary<string, (int, TimeSpan)>() { { "A", (7, new TimeSpan(4, 34, 0)) }, { "F", (2, new TimeSpan(7, 3, 0)) } });
        graph.AddVertex("C", new Dictionary<string, (int, TimeSpan)>() { { "A", (8, new TimeSpan(4, 34, 0)) }, { "F", (6, new TimeSpan(4, 34, 0)) }, { "G", (4, new TimeSpan(4, 34, 0)) } });
        graph.AddVertex("D", new Dictionary<string, (int, TimeSpan)>() { { "F", (8, new TimeSpan(4, 34, 0)) } });
        graph.AddVertex("E", new Dictionary<string, (int, TimeSpan)>() { { "H", (1, new TimeSpan(4, 34, 0)) } });
        graph.AddVertex("F", new Dictionary<string, (int, TimeSpan)>() { { "B", (2, new TimeSpan(4, 34, 0)) }, { "C", (6, new TimeSpan(4, 34, 0)) }, { "D", (8, new TimeSpan(4, 34, 0)) }, { "G", (9, new TimeSpan(4, 34, 0)) }, { "H", (3, new TimeSpan(1, 9, 0)) } });
        graph.AddVertex("G", new Dictionary<string, (int, TimeSpan)>() { { "C", (4, new TimeSpan(4, 34, 0)) }, { "F", (9, new TimeSpan(4, 34, 0)) } });
        graph.AddVertex("H", new Dictionary<string, (int, TimeSpan)>() { { "E", (1, new TimeSpan(4, 34, 0)) }, { "F", (3, new TimeSpan(4, 34, 0)) } });

        (List<string>, int, TimeSpan) path = graph.ShortestPath("A", "H");

        Assert.AreEqual("A -> B -> F -> H", string.Join(" -> ", path.Item1));
        Assert.AreEqual(12, path.Item2);
        Assert.AreEqual(new TimeSpan(9, 15, 0), path.Item3);
    }
}
