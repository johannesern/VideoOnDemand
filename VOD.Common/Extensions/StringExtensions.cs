using System.Data.SqlTypes;

namespace VOD.Common.Extensions;

public static class StringExtensions
{
    public static string Truncate(int length, string value)
    {
        if(string.IsNullOrEmpty(value)) return string.Empty;
        if (value.Length < length) return value;
        var result = value.Substring(0, length);
        return $"{result}..."; 
    }
}
