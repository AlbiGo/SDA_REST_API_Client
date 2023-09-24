using API_REST_SDA.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace API_REST_SDA.Services
{
    public class CountryService
    {
        private const string serverUrl = "https://restcountries.com/v3.1";


        public async Task<List<Country>> GetAll()
        {
            try
            {
                string url = serverUrl + "/all";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception("Error in getting data");
                }

                var content = await response.Content.ReadAsStringAsync();
                var countries = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<Country>>(content);

                return countries;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public void PrintAll(List<Country> countries)
        {
            foreach(var country in countries)
            {
                Console.WriteLine(country.name.common + "  |   " + country.name.official + "   |  " + country.status + "   |   " + (country.independent ? "Yes" : "No"));
            }
        }
        public async Task<List<Country>> GetByLanguage(string language)
        {
            try
            {
                var url = serverUrl + $"/lang/{language}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception("Error in getting data");
                }

                var content = await response.Content.ReadAsStringAsync();
                var countries = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<Country>>(content);

                return countries;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public async Task<Country> GetByName(string name)
        {
            try
            {
                var url = serverUrl + $"/name/{name}?fullText=true";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception("Error in getting data");
                }

                var content = await response.Content.ReadAsStringAsync();
                var country = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<Country>>(content);

                return country.FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
