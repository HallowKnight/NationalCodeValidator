namespace NationalCodeValidation.Extensions;

public class NationalCodeValidator
{
    public static bool ValidNationalCode(string nationalCode)
    {
        return nationalCode is { Length: 10 } && Regexes.NumberPatternRegex().IsMatch(nationalCode) && ValidateNationalCodeIntegrity(nationalCode);
    }

    private static bool ValidateNationalCodeIntegrity(string nationalCode)
    {
        List<char> codeChars = nationalCode.Reverse().ToList();
        int control = int.Parse(char.ToString(codeChars.First()));
        codeChars.RemoveAt(0);
        
        Dictionary<int, int> charsDictionary = codeChars
            .Select((@char, index) => new { Key = index + 2, Value = int.Parse(char.ToString(@char)) })
            .ToDictionary(x => x.Key, x => x.Value);

        int remaining = charsDictionary.Sum(pair => pair.Key * pair.Value) % 11;
        return remaining <= 2
            ? remaining == control
            : 11 - remaining == control;
    }
}