using System.Globalization;
using Application.Importations.Templates;
using CsvHelper.Configuration;

namespace Application.Importations.Maps;

public sealed class NubankExtratoMap : ClassMap<NubankExtratoTemplateCSV>
{
    public NubankExtratoMap()
    {
        Map(x => x.Data).Name("Data").TypeConverterOption.Format("dd/MM/yyyy");
        Map(x => x.Valor).Name("Valor").TypeConverterOption.CultureInfo(CultureInfo.InvariantCulture);
        Map(x => x.Identificador).Name("Identificador");
        Map(x => x.Descricao).Name("Descrição");
    }
}
