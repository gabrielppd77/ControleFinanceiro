namespace Application.Importations;

public record ImportationCSVRequest(DateOnly DateFinancialEntry, Stream File, Guid? AccountId);
