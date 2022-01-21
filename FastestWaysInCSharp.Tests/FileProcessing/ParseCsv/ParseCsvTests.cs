using FastestWaysInCSharp.FileProcessing.ParseCsv;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
    public void V1_Parse100Lines_Get100Records() => TestParsedList(ReadLineSplit.Parse(_smallCsvFilePath));

    [TestMethod]
    public void V2_Parse100Lines_Get100Records() => TestParsedList(ReadLineSlice.Parse(_smallCsvFilePath));

    private static void TestParsedList(in List<FakeName> fakeNames)
    {
        Assert.AreEqual(100, fakeNames.Count);
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
