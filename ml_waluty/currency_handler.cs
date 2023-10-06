using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ml_waluty
{
    public static class currency_handler
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string bankUrl = "https://api.nbp.pl/api/exchangerates/tables/C/";

        public static List<currencyClass> rates = new List<currencyClass>();

        public static async Task grabRates()
        {
            var response = await client.GetStringAsync(bankUrl);
            List<responseclass> r = JsonConvert.DeserializeObject<List<responseclass>>(response);
            rates = r[0].rates;
            rates.Insert(0,new currencyClass()
            {
                currency = "złotówka",
                code = "PLN",
                bid = 1,
                ask = 1
            });
        }
    }

    public class currencyClass
    {
        public string currency { get; set; }
        public string code { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
    }

    public class responseclass {
        public string table { get; set; }
        public string no { get; set; }
        public string tradingDate { get; set; }
        public string effectiveDate { get; set; }
        public List<currencyClass> rates { get; set; }
}

}
