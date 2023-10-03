using System.Text.RegularExpressions;

namespace QuizzService.Core.Utils;

public static partial class RegularExpressions
{
    [GeneratedRegex("^[0-9a-fA-F]{24}$")]
    public static partial Regex IsValidMongoId();
}