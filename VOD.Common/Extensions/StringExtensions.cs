using System.Data.SqlTypes;

namespace VOD.Common.Extensions;

public static class StringExtensions
{
    public static string Truncate(string toTruncate)
    {
        if(toTruncate == null || toTruncate == string.Empty)
        {
            return string.Empty;
        }
        else if (toTruncate.Length > 0 && toTruncate.Length < 50) 
        {
            return toTruncate;
        }
        else if(toTruncate.Length > 50)
        {
            return toTruncate.Substring(0, 47) + "...";
        }
        else
        {
            return "Something is wrong with the string";
        }
    }
}
