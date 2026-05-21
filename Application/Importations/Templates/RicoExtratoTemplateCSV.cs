namespace Application.Importations.Templates;

public class RicoExtratoTemplateCSV
{
    public DateOnly Data { get; set; }
    public TimeSpan Hora { get; set; }
    public required string Descricao { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
}
