using FastestWaysInCSharp.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class StringConcatenationTests
{
    private readonly string _expectedText;
    private readonly string _firstName = "Jane";
    private readonly string _lastName = "Doe";
    private readonly int _number = 69;
    private readonly DateOnly _date;

    public StringConcatenationTests()
    {
        var now = DateTime.Now;
        _date = new DateOnly(now.Year, now.Month, now.Day);

        _expectedText = StringConcatenation.PlusOperator(_firstName, _lastName, _number, _date);
    }

    [TestMethod]
    public void Interpolation() => Assert.AreEqual(_expectedText, StringConcatenation.Interpolation(_firstName, _lastName, _number, _date));

    [TestMethod]
    public void StringConcat() => Assert.AreEqual(_expectedText, StringConcatenation.StringConcat(_firstName, _lastName, _number, _date));

    [TestMethod]
    public void StringFormat() => Assert.AreEqual(_expectedText, StringConcatenation.StringFormat(_firstName, _lastName, _number, _date));

    [TestMethod]
    public void StringBuilder() => Assert.AreEqual(_expectedText, StringConcatenation.StringBuilder(_firstName, _lastName, _number, _date));

    [TestMethod]
    public void StringBuilderPool() => Assert.AreEqual(_expectedText, StringConcatenation.StringBuilderPool(_firstName, _lastName, _number, _date));

    [TestMethod]
    public void Zstring() => Assert.AreEqual(_expectedText, StringConcatenation.Zstring(_firstName, _lastName, _number, _date));
}
