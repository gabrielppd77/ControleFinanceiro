using Application.Importations.Templates;
using Application.Importations.Utils;
using CsvHelper.Configuration;

namespace Application.Importations.Maps;

public sealed class RicoFaturaMap : ClassMap<RicoFaturaTemplateCSV>
{
    public RicoFaturaMap()
    {
        Map(x => x.Data).Name("Data").TypeConverterOption.Format("dd/MM/yyyy");
        Map(x => x.Estabelecimento).Name("Estabelecimento");
        Map(x => x.Portador).Name("Portador");
        Map(x => x.Valor).Name("Valor").TypeConverter<BrazilianCurrencyConverter>();
        Map(x => x.Parcela).Name("Parcela");
    }
}
