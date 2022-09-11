using BackgroundUpdater.Models;
using Newtonsoft.Json;

namespace BackgroundUpdater.Services
{
    public class NasaService : INasaService
    {
        public async Task<Nasa> GetAPOD(DateTime date)
        {
            string s_date = date.ToString("yyyy-MM-dd");
            Nasa apod = new Nasa();

            var url = $"https://api.nasa.gov/planetary/apod";
            var parameters = $"?api_key={Consts.NASA_API_KEY}&date=" + s_date;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

            if(response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var APOD = JsonConvert.DeserializeObject<Nasa>(jsonString);

                if(APOD != null)
                {
                    apod = APOD;
                }
            }
            return apod;
        }
    }
}
