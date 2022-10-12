using Playground;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace Tests;

[TestClass]
public class FpListTest
{
    [TestMethod]
    public void Deconstruction()
    {
        var (head, tail) = new FpList<string>("B", null) + "A";
        Assert.AreEqual(head, "A");
        AssertAreEqual(new[] { "B" }, tail);
    }

    [TestMethod]
    public void Enumerating()
    {
        var test = new FpList<string>("A", null) + ("B") + ("C");
        AssertAreEqual(new[] { "C", "B", "A" }, test);
    }

    [TestMethod]
    public void CollectionInitialization()
    {
        var test = new FpList<string>.Builder { "A", "B" }.Build();
        AssertAreEqual(new[] { "B", "A" }, test);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyCollectionInitialization()
    {
        (new FpList<string>.Builder { }).Build();
    }

    private void AssertAreEqual<T>(T[] array, FpList<T> list)
    {
        var arr = list.ToArray();
        var a = string.Join(", ", list.ToArray());
        var b = string.Join(", ", array);
        Assert.AreEqual(a, b);
    }
}