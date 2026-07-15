using Application.Importations.Templates;
using Application.Importations.Utils;
using CsvHelper.Configuration;

namespace Application.Importations.Maps;

public sealed class NubankFaturaMap : ClassMap<NubankFaturaTemplateCSV>
{
    public NubankFaturaMap()
    {
        Map(x => x.Date).Name("date").TypeConverterOption.Format("yyyy-MM-dd");
        Map(x => x.Title).Name("title");
        Map(x => x.Amount).Name("amount").TypeConverter<BrazilianCurrencyConverter>();
    }
}
