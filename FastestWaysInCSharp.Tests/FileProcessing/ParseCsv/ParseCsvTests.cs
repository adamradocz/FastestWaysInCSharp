using FastestWaysInCSharp.FileProcessing.ParseCsv;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V2;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V3;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V5CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    public void V1StringArray_Parse100Lines_Gets100Records() => TestParsedList(StringArray.Parse(_filePath));

    [TestMethod]
    public async Task V1StringArrayAsync_Parse100Lines_Gets100RecordsAsync() => await TestParsedListAsync(StringArray.ParseAsync(_filePath));

    [TestMethod]
    public void V2Span_Parse100Lines_Gets100Records() => TestParsedList(Span.Parse(_filePath));

    [TestMethod]
    public async Task V2Span_Parse100Lines_Gets100RecordsAsync() => await TestParsedListAsync(Span.ParseAsync(_filePath));

    [TestMethod]
    public async Task V3PipelinesAndSpan_Parse100Lines_Gets100RecordsAsync() => await TestParsedListAsync(PipelinesAndSpan.ParseAsync(_filePath));

    [TestMethod]
    public void V5CsvHelper_Parse100Lines_Gets100Records() => TestParsedList(CsvHelperParser.Parse(_filePath));

    private void TestParsedList(IEnumerable<FakeName> fakeNames)
    {
        int i = 0;
        foreach (var fakeName in fakeNames)
        {
            if (i == 99)
            {
                Assert.AreEqual(100, fakeName.Id);
                Assert.AreEqual(new Guid("5d1d0e33-71c6-49fe-9305-78ebc7300390"), fakeName.Guid);
                Assert.IsTrue(string.Equals("male", fakeName.Gender));
                Assert.IsTrue(string.Equals("Harrison", fakeName.GivenName));
                Assert.IsTrue(string.Equals("Lee", fakeName.Surname));
                Assert.IsTrue(string.Equals("WESTWELL", fakeName.City));
                Assert.IsTrue(string.Equals("33 Bouverie Road", fakeName.StreetAddress));
                Assert.IsTrue(string.Equals("HarrisonLee@armyspy.com", fakeName.EmailAddress));
                Assert.AreEqual(new DateOnly(1936, 5, 16), fakeName.Birthday);
                Assert.IsTrue(string.Equals("IndependentBookshop.co.uk", fakeName.Domain));
            }

            i++;
        }
    }

    private async Task TestParsedListAsync(IAsyncEnumerable<FakeName> fakeNames)
    {
        int i = 0;
        await foreach (var fakeName in fakeNames)
        {
            if (i == 99)
            {
                Assert.AreEqual(100, fakeName.Id);
                Assert.AreEqual(new Guid("5d1d0e33-71c6-49fe-9305-78ebc7300390"), fakeName.Guid);
                Assert.IsTrue(string.Equals("male", fakeName.Gender));
                Assert.IsTrue(string.Equals("Harrison", fakeName.GivenName));
                Assert.IsTrue(string.Equals("Lee", fakeName.Surname));
                Assert.IsTrue(string.Equals("WESTWELL", fakeName.City));
                Assert.IsTrue(string.Equals("33 Bouverie Road", fakeName.StreetAddress));
                Assert.IsTrue(string.Equals("HarrisonLee@armyspy.com", fakeName.EmailAddress));
                Assert.AreEqual(new DateOnly(1936, 5, 16), fakeName.Birthday);
                Assert.IsTrue(string.Equals("IndependentBookshop.co.uk", fakeName.Domain));
            }

            i++;
        }
    }
}
