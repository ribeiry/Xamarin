using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;

namespace GetApiJson.Services
{
    public class RestClient
    {
        public string Serialize()
        {
            var countries = new[] {
                new Country {Name="Brazil" },
                new Country { Name = "Mexico" } };
               
            string json = JsonConvert.SerializeObject(countries);

            Debug.WriteLine(json);

            return json;
        }
        public void Desearilize()
        {
            var json = Serialize();

            var parsedJson = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);

            foreach(Country item in parsedJson)
            {

                Debug.WriteLine(item.Name);

            }
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await GetAsJson();
        }

        protected string BaseUrl { get; set; } = "https://restcountries.eu/rest/v2/all";

        protected async Task<IEnumerable<Country>> GetAsJson()
        {
            var result = Enumerable.Empty<Country>();
            var httpCliente = new HttpClient();

            httpCliente.DefaultRequestHeaders.Accept.Clear();
            httpCliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpCliente.GetAsync(BaseUrl).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                
                if(!string.IsNullOrWhiteSpace(json))
                {
                    result = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                    }).ConfigureAwait(false);
                }
            }
            return result;
        }
    }
}
