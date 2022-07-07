using FastestWaysInCSharp.FileProcessing.ParseCsv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FastestWaysInCSharp.FileProcessing.Model;
using FastestWaysInCSharp.FileProcessing.Utilities;

namespace FastestWaysInCSharp.Tests.FileProcessing.ParseCsv;

[TestClass]
public class ParseCsvTests
{
    private readonly string _filePath;

    public ParseCsvTests()
    {
        _filePath = Data.GetCsvTestFilePath();
    }

    [TestMethod]
    public async Task StringArray_ParseAsync() => TestParsedList(await StringArray.ParseAsync(_filePath).ToListAsync());

    [TestMethod]
    public async Task Span_ParseAsync() => TestParsedList(await Span.ParseAsync(_filePath).ToListAsync());

    [TestMethod]
    public async Task SpanAndChannel_ParseAsync() => TestParsedList(await SpanAndChannel.ParseAsync(_filePath));

    [TestMethod]
    public async Task PipeReaderAndSequenceReader_ParseAsync() => TestParsedList(await PipeReaderAndSequenceReader.ParseAsync(_filePath));

    [TestMethod]
    public async Task FullPipeAndSequenceReader_ParseAsync() => TestParsedList(await FullPipeAndSequenceReader.ParseAsync(_filePath));

    [TestMethod]
    public async Task FullPipeAndChannel_ParseAsync() => TestParsedList(await FullPipeAndChannel.ParseAsync(_filePath));

    [TestMethod]
    public async Task CsvHelper_ParseAsync() => TestParsedList(await CsvHelperParser.ParseAsync(_filePath).ToListAsync());

    [TestMethod]
    public async Task CSylvanDataCsv_ParseAsync() => TestParsedList(await SylvanDataCsv.ParseAsync(_filePath).ToListAsync());

    private static void TestParsedList(List<FakeName> fakeNames)
    {
        Assert.AreEqual(100000, fakeNames.Count);

        var fakeNameNumber99 = fakeNames[98];
        Assert.AreEqual(99, fakeNameNumber99.Id);
        Assert.AreEqual(new Guid("748e4c71-9ca6-4ad7-97c9-f7e544dc229c"), fakeNameNumber99.Guid);
        Assert.IsTrue(fakeNameNumber99.IsVip);
        Assert.AreEqual('f', fakeNameNumber99.Gender);
        Assert.IsTrue(string.Equals("Laura", fakeNameNumber99.GivenName, StringComparison.Ordinal));
        Assert.IsTrue(string.Equals("Crawford", fakeNameNumber99.Surname, StringComparison.Ordinal));
        Assert.AreEqual(new DateOnly(1952, 06, 15), fakeNameNumber99.Birthday);
        Assert.AreEqual(168, fakeNameNumber99.Height);
        Assert.AreEqual(64.3f, fakeNameNumber99.Weight);
        Assert.AreEqual(5483321095549460, fakeNameNumber99.CreditCardNumber);

        var fakeNameNumber100 = fakeNames[99];
        Assert.AreEqual(100, fakeNameNumber100.Id);
        Assert.AreEqual(new Guid("becc7c8b-3176-4cb1-8105-2ee8bcf3ebd8"), fakeNameNumber100.Guid);
        Assert.IsFalse(fakeNameNumber100.IsVip);
        Assert.AreEqual('m', fakeNameNumber100.Gender);
        Assert.IsTrue(string.Equals("Oscar", fakeNameNumber100.GivenName, StringComparison.Ordinal));
        Assert.IsTrue(string.Equals("Pearson", fakeNameNumber100.Surname, StringComparison.Ordinal));
        Assert.AreEqual(new DateOnly(1934, 3, 22), fakeNameNumber100.Birthday);
        Assert.AreEqual(168, fakeNameNumber100.Height);
        Assert.AreEqual(62.5f, fakeNameNumber100.Weight);
        Assert.AreEqual(5346646292138171, fakeNameNumber100.CreditCardNumber);
    }
}
