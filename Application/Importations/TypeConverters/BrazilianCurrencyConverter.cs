using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Application.Importations.TypeConverters;

public class BrazilianCurrencyConverter : DecimalConverter
{
    private static readonly CultureInfo PtBr = CultureInfo.GetCultureInfo("pt-BR");

    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0m;

        var cleaned = text
            .Replace("R$", string.Empty)
            .Replace(" ", string.Empty)
            .Trim();

        return decimal.Parse(cleaned, NumberStyles.Number | NumberStyles.AllowLeadingSign, PtBr);
    }
}
