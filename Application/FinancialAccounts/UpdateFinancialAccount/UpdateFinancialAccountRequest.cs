namespace Application.FinancialAccounts.UpdateFinancialAccount;

public record UpdateFinancialAccountRequest(Guid Id, string Name, string? Color);
