using FastestWaysInCSharp.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class ParseByteArrayStringToIntTests
{
    public static IEnumerable<object[]> Data()
    {
        yield return new object[] { 0, System.Text.Encoding.UTF8.GetBytes("0") };
        yield return new object[] { 0, System.Text.Encoding.UTF8.GetBytes("0000") };
        yield return new object[] { 69, System.Text.Encoding.UTF8.GetBytes("69") };
        yield return new object[] { 1234567890, System.Text.Encoding.UTF8.GetBytes("1234567890") };
        yield return new object[] { 2147483647, System.Text.Encoding.UTF8.GetBytes("2147483647") };
    }

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Method)]
    public void GetStringIntParse_PassByteArray_ReturnsInt(int expexted, byte[] stringAsByteArray) => Assert.AreEqual(expexted, ParseByteArrayStringToInt.GetStringIntParse(stringAsByteArray));

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Method)]
    public void ParseByteArrayStringToInt_PassByteArray_ReturnsInt(int expexted, byte[] stringAsByteArray) => Assert.AreEqual(expexted, ParseByteArrayStringToInt.Utf8ParserTryParse(stringAsByteArray));

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Method)]
    public void CustomIntParse_PassByteArray_ReturnsInt(int expexted, byte[] stringAsByteArray) => Assert.AreEqual(expexted, ParseByteArrayStringToInt.CustomIntParse(stringAsByteArray));
}
