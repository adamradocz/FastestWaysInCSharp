using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastestWaysInCSharp.Tests.FileProcessing.ParseCsv.V1;

[TestClass]
public class ParseCsvTests
{
    private readonly string _smallCsvFilePath;

    public ParseCsvTests()
    {
        _smallCsvFilePath = System.IO.Path.Combine("FileProcessing", "ParseCsv", "FakeNamesSmall.csv");
    }

    [TestMethod]
    public void V1_Parse100Lines_Get100Records()
    {
        // Act
        var fakeNames = ReadLineSplit.Parse(_smallCsvFilePath);

        // Assert
        Assert.AreEqual(100, fakeNames.Count);
    }


    [TestMethod]
    public void V2_Parse100Lines_Get100Records()
    {
        // Act
        var fakeNames = ReadLineSlice.Parse(_smallCsvFilePath);

        // Assert
        Assert.AreEqual(100, fakeNames.Count);
    }
}
