using FastestWaysInCSharp.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class CharacterReplaceTests
{
    private const string _expectedText = "L#rem ipsum dolor sit amet";

    [TestMethod]
    public void Substring() => Assert.AreEqual(_expectedText, CharacterReplace.Substring());

    [TestMethod]
    public void StringCreate() => Assert.AreEqual(_expectedText, CharacterReplace.StringCreate());

    [TestMethod]
    public void Unsafe() => Assert.AreEqual(_expectedText, CharacterReplace.Unsafe());
}
