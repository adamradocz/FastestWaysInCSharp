using FastestWaysInCSharp.FileProcessing.ParseCsv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FastestWaysInCSharp.FileProcessing.ParseCsv.Model;
using FastestWaysInCSharp.FileProcessing.ParseCsv.Utilities;

namespace FastestWaysInCSharp.Tests.FileProcessing.ParseCsv;

[TestClass]
public class ParseCsvTests
{
    private readonly string _filePath;

    public ParseCsvTests()
    {
        _filePath = Data.GetTestFilePath();
    }

    // StringArray
    [TestMethod]
    public void StringArray_Parse() => TestParsedList(StringArray.Parse(_filePath).ToList());

    [TestMethod]
    public async Task StringArray_ParseAsync() => TestParsedList(await StringArray.ParseAsync(_filePath).ToListAsync());

    // Span
    [TestMethod]
    public void Span_Parse() => TestParsedList(Span.Parse(_filePath).ToList());

    [TestMethod]
    public async Task Span_ParseAsync() => TestParsedList(await Span.ParseAsync(_filePath).ToListAsync());

    // PipelinesAndSequenceReader
    [TestMethod]
    public async Task PipelinesAndSequenceReader_ParseAsync() => TestParsedList(await PipelinesAndSequenceReader.ParseAsync(_filePath));

    // PipelinesAndBufferReader
    [TestMethod]
    public async Task PipelinesAndBufferReader_ParseAsync() => TestParsedList(await PipelinesAndBufferReader.ParseAsync(_filePath));

    // CsvHelper
    [TestMethod]
    public void CsvHelper_Parse() => TestParsedList(CsvHelperParser.Parse(_filePath).ToList());

    [TestMethod]
    public async Task CsvHelper_ParseAsync() => TestParsedList(await CsvHelperParser.ParseAsync(_filePath).ToListAsync());

    // SylvanDataCsv
    [TestMethod]
    public void CSylvanDataCsv_Parse() => TestParsedList(SylvanDataCsv.Parse(_filePath).ToList());

    [TestMethod]
    public async Task CSylvanDataCsv_ParseAsync() => TestParsedList(await SylvanDataCsv.ParseAsync(_filePath).ToListAsync());

    private void TestParsedList(List<FakeName> fakeNames)
    {
        Assert.AreEqual(100000, fakeNames.Count);
        Assert.AreEqual(100, fakeNames[99].Id);
        Assert.AreEqual(new Guid("becc7c8b-3176-4cb1-8105-2ee8bcf3ebd8"), fakeNames[99].Guid);
        Assert.IsTrue(string.Equals("male", fakeNames[99].Gender));
        Assert.IsTrue(string.Equals("Oscar", fakeNames[99].GivenName));
        Assert.IsTrue(string.Equals("Pearson", fakeNames[99].Surname));
        Assert.IsTrue(string.Equals("SUTTON ON SEA", fakeNames[99].City));
        Assert.IsTrue(string.Equals("19 Mounthoolie Lane", fakeNames[99].StreetAddress));
        Assert.IsTrue(string.Equals("OscarPearson@einrot.com", fakeNames[99].EmailAddress));
        Assert.AreEqual(new DateOnly(1934, 3, 22), fakeNames[99].Birthday);
        Assert.AreEqual(168, fakeNames[99].Height);
        Assert.AreEqual(62.5f, fakeNames[99].Weight);
        Assert.AreEqual(5346646292138171, fakeNames[99].CreditCardNumber);
        Assert.IsTrue(string.Equals("IPODaily.co.uk", fakeNames[99].Domain));
    }
}
