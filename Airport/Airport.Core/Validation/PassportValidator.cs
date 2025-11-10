using System.Text.RegularExpressions;

namespace Airport.Core.Validation;

public static class PassportValidator
{
    private static readonly Regex _regex = new(@"^[PL][A-Z]\d{7}$", RegexOptions.Compiled);

    public static bool IsValid(string? passport)
    {
        if (string.IsNullOrWhiteSpace(passport))
            return false;

        return _regex.IsMatch(passport.ToUpper());
    }
}
