using FastestWaysInCSharp.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FastestWaysInCSharp.Tests.StringManipulation;

[TestClass]
public class EmailAddressValidatorTests
{
    public static IEnumerable<object[]> Data
    {
        get
        {
            yield return new object[] { "Molly@jourrapide.com", true };
            yield return new object[] { "Molly@mail.co.uk", true };
            yield return new object[] { "Mollyjourrapide.com", false };
            yield return new object[] { "Molly@.jourrapide.com", false };
        }
    }

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
    public void Regex(string email, bool expextedResult)
    {
        // Arrange & Act
        bool isValid = EmailAddressValidator.Regex(email);

        // Assert
        Assert.AreEqual(expextedResult, isValid);
    }

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
    public void RegexCompiled(string email, bool expextedResult)
    {
        // Arrange & Act
        bool isValid = EmailAddressValidator.RegexCompiled(email);

        // Assert
        Assert.AreEqual(expextedResult, isValid);
    }

    [DataTestMethod]
    [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
    public void RegexSourceGen(string email, bool expextedResult)
    {
        // Arrange & Act
        bool isValid = EmailAddressValidator.RegexSourceGen(email);

        // Assert
        Assert.AreEqual(expextedResult, isValid);
    }
}
