using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CinemaClient
{
    class RestService : IRestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        private static readonly string REST_URL = "https://localhost:5001/api";

        public List<ScreeningInfo> Screenings { get; private set; }
        public MovieInfo MovieInfo { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };


        }

        public async Task<List<ScreeningInfo>> RefreshScreeningsAsync()
        {
            Screenings = new List<ScreeningInfo>();

            Uri uri = new Uri(string.Format(REST_URL+"/screenings", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Screenings = JsonSerializer.Deserialize<List<ScreeningInfo>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Screenings;
        }

        public async Task<MovieInfo> RefreshMovieInfoAsync(int id)
        {
            MovieInfo = new MovieInfo();

            Uri uri = new Uri(string.Format(REST_URL + $"/movies/{id}", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    MovieInfo = JsonSerializer.Deserialize<MovieInfo>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return MovieInfo;
        }
    }
    public interface IRestService
    {
        public Task<List<ScreeningInfo>> RefreshScreeningsAsync();
    }
}
