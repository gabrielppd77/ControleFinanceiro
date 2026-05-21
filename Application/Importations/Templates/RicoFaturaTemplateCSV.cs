namespace Application.Importations.Templates;

public class RicoFaturaTemplateCSV
{
    public DateOnly Data { get; set; }
    public required string Estabelecimento { get; set; }
    public required string Portador { get; set; }
    public decimal Valor { get; set; }
    public required string Parcela { get; set; }
}
