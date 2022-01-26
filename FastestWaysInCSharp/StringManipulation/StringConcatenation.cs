using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace FastestWaysInCSharp.StringManipulation;

public static class StringConcatenation
{
    private static readonly ObjectPool<StringBuilder> _stringBuilderPool;

    static StringConcatenation()
    {
        var objectPoolProvider = new DefaultObjectPoolProvider();
        _stringBuilderPool = objectPoolProvider.CreateStringBuilderPool();
    }

    public static string PlusOperator(in string firstName, in string lastName, int number, DateOnly date)
    {
        string result = "Hello world at " + date + '.' + Environment.NewLine + "I'm " + firstName + ' ' + lastName + " and my favorite number is " + number + '.';
        return result;
    }

    public static string Interpolation(in string firstName, in string lastName, int number, DateOnly date)
        => $"Hello world at {date}.{Environment.NewLine}I'm {firstName} {lastName} and my favorite number is {number}.";

    public static string StringConcat(in string firstName, in string lastName, int number, DateOnly date)
        => string.Concat("Hello world at ", date, '.', Environment.NewLine, "I'm ", firstName, ' ', lastName, " and my favorite number is ", number, '.');

    public static string StringFormat(in string firstName, in string lastName, int number, DateOnly date)
        => string.Format("Hello world at {0}.{1}I'm {2} {3} and my favorite number is {4}.", date, Environment.NewLine, firstName, lastName, number);
    
    public static string StringBuilder(in string firstName, in string lastName, int number, DateOnly date)
    {
        var builder = new StringBuilder("Hello world at ");
        _ = builder.Append(date)
                   .Append('.').AppendLine()
                   .Append("I'm ")
                   .Append(firstName)
                   .Append(' ')
                   .Append(lastName)
                   .Append(" and my favorite number is ")
                   .Append(number)
                   .Append('.');
        return builder.ToString();
    }

    public static string StringBuilderPool(in string firstName, in string lastName, int number, DateOnly date)
    {
        var builder = _stringBuilderPool.Get();
        _ = builder.Append("Hello world at ")
                   .Append(date)
                   .Append('.').AppendLine()
                   .Append("I'm ")
                   .Append(firstName)
                   .Append(' ')
                   .Append(lastName)
                   .Append(" and my favorite number is ")
                   .Append(number)
                   .Append('.');

        string text = builder.ToString();
        _stringBuilderPool.Return(builder);
        return text;
    }

    public static string Zstring(in string firstName, in string lastName, int number, DateOnly date)
    {
        using var builder = Cysharp.Text.ZString.CreateStringBuilder();
        builder.Append("Hello world at ");
        builder.Append(date);
        builder.Append('.');
        builder.AppendLine();
        builder.Append("I'm ");
        builder.Append(firstName);
        builder.Append(' ');
        builder.Append(lastName);
        builder.Append(" and my favorite number is ");
        builder.Append(number);
        builder.Append('.');
        return builder.ToString();
    }
}
