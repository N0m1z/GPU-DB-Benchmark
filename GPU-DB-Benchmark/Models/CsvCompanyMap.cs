using System.Globalization;
using CsvHelper.Configuration;

namespace GPU_DB_Benchmark.Models
{
    public class CsvCompanyMap : ClassMap<Company>
    {
        public CsvCompanyMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Address).Ignore();
        }
    }
}