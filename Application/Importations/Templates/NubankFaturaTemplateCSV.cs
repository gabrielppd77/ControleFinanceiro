namespace Application.Importations.Templates;

public class NubankFaturaTemplateCSV
{
    public DateOnly Date { get; set; }
    public required string Title { get; set; }
    public decimal Amount { get; set; }
}
