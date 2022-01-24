using FastestWaysInCSharp.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class ConvertStringToIntTests
{
    public static IEnumerable<object[]> Data()
    {
        yield return new object[] { 0, "0" };
        yield return new object[] { 0, "0000" };
        yield return new object[] { 69, "69" };
        yield return new object[] { 1234567890, "1234567890" };
        yield return new object[] { 123456789, "0123456789" };
        yield return new object[] { 2147483647, "2147483647" };
    }

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Method)]
    public void IntParse(int expexted, string integerAsString) => Assert.AreEqual(expexted, ConvertStringToInt.IntParse(integerAsString));

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Method)]
    public void ConvertToInt32(int expexted, string integerAsString) => Assert.AreEqual(expexted, ConvertStringToInt.ConvertToInt32(integerAsString));

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Method)]
    public void CustomIntParse(int expexted, string integerAsString) => Assert.AreEqual(expexted, ConvertStringToInt.CustomIntParse(integerAsString));

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Method)]
    public void CustomIntParseUnsafe(int expexted, string integerAsString) => Assert.AreEqual(expexted, ConvertStringToInt.CustomIntParseUnsafe(integerAsString));
}
