using Domain.FinancialEntries;

namespace Application.Importations;

public interface ICsvImporter
{
    bool Matches(string[] headers);

    string Delimiter { get; }

    List<FinancialEntry> Import(TextReader reader, DateOnly dateFinancialEntry, Guid userId);
}
