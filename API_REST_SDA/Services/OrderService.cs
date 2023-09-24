using API_REST_SDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_REST_SDA.Services
{
    public class OrderService
    {
        private const string serverUrl = "https://reqbin.com/echo/post/json";
        private HttpClient _httpClient;

        public OrderService()
        {
            _httpClient = new HttpClient();
        }

        public async Task AddOrder(Order order)
        {
            try
            {
                //Convert to string
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(order);
                
                //Creates a body for http request
                using HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                
                //Call Api and get response message
                HttpResponseMessage res = await _httpClient.PostAsync(serverUrl, content);
                
                //Check response Status code
                var statusCode = res.StatusCode;
                Console.WriteLine(statusCode);

                if (statusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("There has been an error on http requst");
                    Console.WriteLine($"The return status code is {statusCode}");
                    throw new Exception("There has been an error on http requst");
                }
                Console.WriteLine("Record was addedd succesfully");

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
