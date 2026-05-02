namespace Domain.FinancialEntries;

public enum ClassificationEnum
{
    Expense,
    Revenue
}

public static class ClassificationEnumExtensions
{
    public static string GetName(this ClassificationEnum classification)
    {
        return classification switch
        {
            ClassificationEnum.Expense => "Despesa",
            ClassificationEnum.Revenue => "Receita",
            _ => throw new ArgumentOutOfRangeException(nameof(classification), classification, null)
        };
    }

    public static string GetColor(this ClassificationEnum classification)
    {
        return classification switch
        {
            ClassificationEnum.Expense => "Red",
            ClassificationEnum.Revenue => "Green",
            _ => throw new ArgumentOutOfRangeException(nameof(classification), classification, null)
        };
    }
}