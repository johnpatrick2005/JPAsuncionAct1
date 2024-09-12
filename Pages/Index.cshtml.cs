using JPAsuncionAct1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPAsuncionAct1.Pages
{
    public class IndexModel(ILogger<IndexModel> logger) : PageModel
    {
        private static readonly List<ShowResponse> shows = [];

        // This will store the shows fetched from the API
        public List<ShowResponse> Shows { get; set; } = shows;

        public List<ShowResponse> GetShows()
        {
            return Shows;
        }

        public async Task OnGetAsync()
        {
            using var client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri("https://api.tvmaze.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "YourAppName/1.0");

                var response = await client.GetAsync("search/shows?q=golden");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the response into a list of ShowResponse objects
                    Shows = JsonConvert.DeserializeObject<List<ShowResponse>>(content) ?? shows;
                }
                else
                {
                    logger.LogError("Failed to fetch show data. Status code: {StatusCode}", response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                logger.LogError(e, "Error fetching show data.");
            }
        }
    }
}
