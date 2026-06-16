namespace Application.Importations.Templates;

public class NubankExtratoTemplateCSV
{
    public DateOnly Data { get; set; }
    public decimal Valor { get; set; }
    public required string Identificador { get; set; }
    public required string Descricao { get; set; }
}
