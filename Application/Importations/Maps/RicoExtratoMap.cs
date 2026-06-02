using Application.Importations.Templates;
using Application.Importations.Utils;
using CsvHelper.Configuration;

namespace Application.Importations.Maps;

public sealed class RicoExtratoMap : ClassMap<RicoExtratoTemplateCSV>
{
    public RicoExtratoMap()
    {
        Map(x => x.Data).Name("Data").TypeConverterOption.Format("dd/MM/yy");
        Map(x => x.Hora).Name("Hora").TypeConverterOption.Format(@"hh\:mm\:ss");
        Map(x => x.Descricao).Name("Descricao");
        Map(x => x.Valor).Name("Valor").TypeConverter<BrazilianCurrencyConverter>();
        Map(x => x.Saldo).Name("Saldo").TypeConverter<BrazilianCurrencyConverter>();
    }
}
