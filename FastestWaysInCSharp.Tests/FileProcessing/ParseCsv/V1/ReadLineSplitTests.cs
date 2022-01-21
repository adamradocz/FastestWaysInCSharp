using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastestWaysInCSharp.Tests.FileProcessing.ParseCsv.V1;

[TestClass]
public class ReadLineSplitTests
{

    [TestMethod]
    public void Parse() => new ReadLineSplit().Parse(@"FileProcessing\ParseCsv\FakeNamesSmall.csv");
}
