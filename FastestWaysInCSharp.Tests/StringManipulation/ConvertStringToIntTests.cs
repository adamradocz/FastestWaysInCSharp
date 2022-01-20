using FastestWaysInCSharp.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class ConvertStringToIntTests
{
    private const int _expectedInt = 1234567890;

    [TestMethod]
    public void IntParse() => Assert.AreEqual(_expectedInt, ConvertStringToInt.IntParse());

    [TestMethod]
    public void ConvertToInt32() => Assert.AreEqual(_expectedInt, ConvertStringToInt.ConvertToInt32());

    [TestMethod]
    public void CustomIntParse() => Assert.AreEqual(_expectedInt, ConvertStringToInt.CustomIntParse());

    [TestMethod]
    public void CustomIntParseUnsafe() => Assert.AreEqual(_expectedInt, ConvertStringToInt.CustomIntParseUnsafe());
}
