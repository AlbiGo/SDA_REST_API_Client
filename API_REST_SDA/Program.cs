// See https://aka.ms/new-console-template for more information
using API_REST_SDA.Models;
using API_REST_SDA.Services;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        const string serverURL = "http://localhost:5000/games";
        //await GetAllGames();
        Console.WriteLine("----------------------------------------------");
        //await AddGame(new VideoGame()
        //{
        //    ID = 4,
        //    Name = "Assasins Creed",
        //    Size = 100,
        //    Studio = "Ubisoft"
        //});
        Console.WriteLine("----------------------------------------------");
        //var game = await GetGameByID(1);
        //Console.WriteLine(game.Name);
        Console.ReadLine();

        var countryService = new CountryService();

        //var countries = await countryService.GetAll();

        //var orderedCountries = countries.OrderBy(p => p.name.official)
        //    .ToList();

        //orderedCountries.ForEach(p =>
        //{
        //    Console.WriteLine(p.name.common + "  |   " + p.name.official + "   |  " + p.status + "   |   " + (p.independent ? "Yes" : "No"));
        //    Console.WriteLine("------------------------------------------------------------");
        //});

        var country = await countryService.GetByName("Albania");
        Console.WriteLine(country.name.common + "  |   " + country.name.official + "   |  " + country.status + "   |   " + (country.independent ? "Yes" : "No"));

        async Task GetAllGames()
        {
            try
            {
                HttpClient httpRequest = new HttpClient();
                var result = await httpRequest.GetAsync(serverURL);
                Console.WriteLine(await result.Content.ReadAsStringAsync());
                Console.WriteLine(result.StatusCode.ToString());
                string responseBody = await result.Content.ReadAsStringAsync();
                var games = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VideoGame>>(responseBody);
                games.ForEach(p =>
                {
                    Console.WriteLine(p.Name + "    " + p.Studio);
                });
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        async Task<VideoGame> GetGameByID(int id)
        {
            HttpClient httpRequest = new HttpClient();
            var url = serverURL + $"/{id}";
            HttpResponseMessage res = await httpRequest.GetAsync(url);
            var objectString = await res.Content.ReadAsStringAsync();
            var videoGame = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoGame>(objectString);
            return videoGame;
        }

        async Task AddGame(VideoGame videoGame)
        {
            try
            {
                HttpClient httpRequest = new HttpClient();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(videoGame);
                using HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await httpRequest.PostAsync(serverURL, content);
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}