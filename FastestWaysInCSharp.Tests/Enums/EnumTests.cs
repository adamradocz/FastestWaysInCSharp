using FastestWaysInCSharp.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FastestWaysInCSharp.Tests.Enums;

[TestClass]
public class EnumTests
{
    [TestMethod]
    public void ToString_ToStringFast_ResultsAreEqual()
    {
        // Arrange

        // Act
        string expected = Fruits.Apple.ToString();
        string stringFast = Fruits.Apple.ToStringFast();

        Assert.AreEqual(expected, stringFast);
    }

    [TestMethod]
    public void IsDefinedName_IsDefinedNameExtension_ResultsAreEqual()
    {
        // Arrange

        // Act
        bool expected = Enum.IsDefined(typeof(Fruits), nameof(Fruits.Apple));
        bool isDefinedNameExtension = FruitsExtensions.IsDefined(nameof(Fruits.Apple));

        // Assert
        Assert.AreEqual(expected, isDefinedNameExtension);
    }

    [TestMethod]
    public void IsDefined_IsDefinedExtension_ResultsAreEqual()
    {
        // Arrange

        // Act
        bool expected = Enum.IsDefined(typeof(Fruits), Fruits.Apple);
        bool isDefinedNameExtension = FruitsExtensions.IsDefined(Fruits.Apple);

        // Assert
        Assert.AreEqual(expected, isDefinedNameExtension);
    }

    [TestMethod]
    public void GetValues_GetValuesExtension_ResultsAreEqual()
    {
        // Arrange

        // Act
        var expected = Enum.GetValues(typeof(Fruits));
        var getValuesExtension = FruitsExtensions.GetValues();

        // Assert
        CollectionAssert.AreEqual(expected, getValuesExtension);
    }

    [TestMethod]
    public void GetNames_GetNamesExtension_ResultsAreEqual()
    {
        // Arrange

        // Act
        string[] expected = Enum.GetNames(typeof(Fruits));
        string[] getValuesExtension = FruitsExtensions.GetNames();

        // Assert
        CollectionAssert.AreEqual(expected, getValuesExtension);
    }

    [TestMethod]
    public void TryParse_TryParseExtension_ResultsAreEqual()
    {
        // Arrange

        // Act
        bool expected = Enum.TryParse("Apple", ignoreCase: false, out Fruits result);
        bool tryParseExtension = FruitsExtensions.TryParse("Apple", ignoreCase: false, out var resultExtension);

        // Assert
        Assert.AreEqual(expected, tryParseExtension);
        Assert.AreEqual(result, resultExtension);
    }

    [TestMethod]
    public void TryParseIgnoreCase_TryParseIgnoreCaseExtension_ResultsAreEqual()
    {
        // Arrange

        // Act
        bool expected = Enum.TryParse("Apple", ignoreCase: true, out Fruits result);
        bool tryParseIgnoreCaseExtension = FruitsExtensions.TryParse("Apple", ignoreCase: true, out var resultExtension);

        // Assert
        Assert.AreEqual(expected, tryParseIgnoreCaseExtension);
        Assert.AreEqual(result, resultExtension);
    }
}
