namespace Application.Importations.Utils;

internal static class HeaderMatcher
{
    public static bool HasAll(string[] actual, string[] expected)
    {
        if (actual.Length == 0) return false;

        var normalized = actual
            .Select(h => h.Trim())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return expected.All(h => normalized.Contains(h));
    }
}
