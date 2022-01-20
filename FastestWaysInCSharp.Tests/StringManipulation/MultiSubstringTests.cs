using FastestWaysInCSharp.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class MultiSubstringTests
{
    private const string _expectedText = "Loremconsecteturaliqua";

    [TestMethod]
    public void Substring() => Assert.AreEqual(_expectedText, MultiSubstring.Substring());

    [TestMethod]
    public void CharArray() => Assert.AreEqual(_expectedText, MultiSubstring.CharArray());

    [TestMethod]
    public void CharArrayStackAlloc() => Assert.AreEqual(_expectedText, MultiSubstring.CharArrayStackAlloc());

    [TestMethod]
    public void CharArrayStackAllocToString() => Assert.AreEqual(_expectedText, MultiSubstring.CharArrayStackAllocToString());

    [TestMethod]
    public void StringCreate() => Assert.AreEqual(_expectedText, MultiSubstring.StringCreate());

    [TestMethod]
    public void StringCreateClosure() => Assert.AreEqual(_expectedText, MultiSubstring.StringCreateClosure());

    [TestMethod]
    public void StringCreateReverse() => Assert.AreEqual(_expectedText, MultiSubstring.StringCreateReverse());
}
