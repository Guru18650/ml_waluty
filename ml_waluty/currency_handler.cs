using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ml_waluty
{
    public static class currency_handler
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string bankUrl = "https://api.nbp.pl/api/exchangerates/tables/C/";

        public static async Task<List<currencyClass>> getCurrencies(){
            var response = await client.GetStringAsync(bankUrl);
            var r = JsonConvert.DeserializeObject<List<currencyClass>>(response);
            return r;
        }
    }

    public class currencyClass
    {
        string currency { get; set; }
        string code { get; set; }
        double bid { get; set; }
        double ask { get; set; }
    }
}
