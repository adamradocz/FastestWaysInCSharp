using System.Text.Json.Serialization;

namespace FastestWaysInCSharp.FileProcessing.Model;

public class FakeName
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public bool IsVip { get; set; }

    /// <summary>
    /// 'f' or 'm'
    /// </summary>
    public char Gender { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }

    public DateOnly? Birthday { get; set; }
    public int Height { get; set; }
    public float Weight { get; set; }
    public long CreditCardNumber { get; set; }
}
