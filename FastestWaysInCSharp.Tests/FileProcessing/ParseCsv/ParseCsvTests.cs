using FastestWaysInCSharp.FileProcessing.ParseCsv;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V2;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V3;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V4;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V5CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FastestWaysInCSharp.Tests.FileProcessing.ParseCsv;

[TestClass]
public class ParseCsvTests
{
    private readonly string _filePath;

    public ParseCsvTests()
    {
        _filePath = System.IO.Path.Combine("FileProcessing", "ParseCsv", "FakeNamesSmall.csv");
    }

    [TestMethod]
    public void V1StringArray_Parse100Lines_Gets100Records() => TestParsedList(StringArray.Parse(_filePath).ToList());

    [TestMethod]
    public async Task V1StringArrayAsync_Parse100Lines_Gets100RecordsAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in StringArray.ParseAsync(_filePath))
        {
            fakeNames.Add(fakeName);
        }

        TestParsedList(fakeNames);
    }

    [TestMethod]
    public void V2Span_Parse100Lines_Gets100Records() => TestParsedList(Span.Parse(_filePath).ToList());

    [TestMethod]
    public async Task V2Span_Parse100Lines_Gets100RecordsAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in Span.ParseAsync(_filePath))
        {
            fakeNames.Add(fakeName);
        }

        TestParsedList(fakeNames);
    }

    [TestMethod]
    public async Task V3PipelinesAndSpan_Parse100Lines_Gets100RecordsAsync() => TestParsedList(await PipelinesAndSpan.ParseAsync(_filePath));

    [TestMethod]
    public async Task V4FilePipeReaderAndSpan_Parse100Lines_Gets100RecordsAsync() => TestParsedList(await FilePipeReaderAndSpan.ParseAsync(_filePath));

    [TestMethod]
    public void V5CsvHelper_Parse100Lines_Gets100Records() => TestParsedList(CsvHelperParser.Parse(_filePath).ToList());

    private void TestParsedList(List<FakeName> fakeNames)
    {
        Assert.AreEqual(100, fakeNames[99].Id);
        Assert.AreEqual(new Guid("5d1d0e33-71c6-49fe-9305-78ebc7300390"), fakeNames[99].Guid);
        Assert.IsTrue(string.Equals("male", fakeNames[99].Gender));
        Assert.IsTrue(string.Equals("Harrison", fakeNames[99].GivenName));
        Assert.IsTrue(string.Equals("Lee", fakeNames[99].Surname));
        Assert.IsTrue(string.Equals("WESTWELL", fakeNames[99].City));
        Assert.IsTrue(string.Equals("33 Bouverie Road", fakeNames[99].StreetAddress));
        Assert.IsTrue(string.Equals("HarrisonLee@armyspy.com", fakeNames[99].EmailAddress));
        Assert.AreEqual(new DateOnly(1936, 5, 16), fakeNames[99].Birthday);
        Assert.IsTrue(string.Equals("IndependentBookshop.co.uk", fakeNames[99].Domain));
    }
}
