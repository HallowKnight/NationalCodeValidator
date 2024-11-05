using System.Text.RegularExpressions;

namespace NationalCodeValidation.Extensions;

public static partial class Regexes
{
    private const string NumberRegex = @"^[0-9]*$";

    
    [GeneratedRegex(NumberRegex)]
    public static partial Regex NumberPatternRegex();  
}