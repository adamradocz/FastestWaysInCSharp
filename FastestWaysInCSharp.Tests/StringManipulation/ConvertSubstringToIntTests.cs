using FastestWaysInCSharp.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class ConvertSubstringToIntTests
{
    private const int _expectedInt = 69;

    [TestMethod]
    public void SubstringIntParse() => Assert.AreEqual(_expectedInt, ConvertSubstringToInt.SubstringIntParse());

    [TestMethod]
    public void SpanIntParse() => Assert.AreEqual(_expectedInt, ConvertSubstringToInt.SpanIntParse());

    [TestMethod]
    public void SpanGenericCustomParse() => Assert.AreEqual(_expectedInt, ConvertSubstringToInt.SpanGenericCustomParse());

    [TestMethod]
    public void SpanSpecificCustomParse() => Assert.AreEqual(_expectedInt, ConvertSubstringToInt.SpecificCustomIntParse());
}
