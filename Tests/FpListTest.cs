using Playground;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace Tests;

[TestClass]
public class FpListTest
{
    [TestMethod]
    public void Deconstruction()
    {
        var (head, tail) = FpList<string>.Create("B") + "A";
        Assert.AreEqual(head, "A");
        AssertAreEqual(new[] { "B" }, tail);
    }

    [TestMethod]
    public void Enumerating()
    {
        var test = FpList<string>.Create("A") + ("B") + ("C");
        AssertAreEqual(new[] { "C", "B", "A" }, test);
    }

    [TestMethod]
    public void CollectionInitialization()
    {
        var test = new FpList<string>.Builder { "A", "B" }.Build();
        AssertAreEqual(new[] { "B", "A" }, test);
    }

    [TestMethod]
    public void EmptyCollectionInitialization()
    {
        var test = new FpList<string> { };
        AssertAreEqual(new string[0], test);
    }

    private void AssertAreEqual<T>(T[] array, FpList<T> list)
    {
        var arr = list.ToArray();
        var a = string.Join(", ", list.ToArray());
        var b = string.Join(", ", array);
        Assert.AreEqual(a, b);
    }
}