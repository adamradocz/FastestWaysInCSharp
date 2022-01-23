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
        _filePath = System.IO.Path.Combine("FileProcessing", "ParseCsv", "FakeNames.csv");
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
        Assert.AreEqual(100000, fakeNames.Count);
        Assert.AreEqual(100, fakeNames[99].Id);
        Assert.AreEqual(new Guid("5bbecefd-95e6-416d-83f3-31ffcb9cdb9e"), fakeNames[99].Guid);
        Assert.IsTrue(string.Equals("female", fakeNames[99].Gender));
        Assert.IsTrue(string.Equals("Natasha", fakeNames[99].GivenName));
        Assert.IsTrue(string.Equals("Wright", fakeNames[99].Surname));
        Assert.IsTrue(string.Equals("NatashaWright@teleworm.us", fakeNames[99].EmailAddress));
        Assert.AreEqual(new DateOnly(1939, 3, 16), fakeNames[99].Birthday);
        Assert.IsTrue(string.Equals("ToledoTelevision.co.uk", fakeNames[99].Domain));
    }
}
