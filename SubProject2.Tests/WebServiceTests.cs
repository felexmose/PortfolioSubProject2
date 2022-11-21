using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Assignment4.Tests
{
    public class WebServiceTests
    {
        private const string ActorsApi = "http://localhost:5001/api/actors";
        private const string MoviesApi = "http://localhost:5001/api/movies";
        private const string EpisodesApi = "http://localhost:5001/api/movies/episodes";
        private const string UsersApi = "http://localhost:5001/api/users";


        /* /api/actors */
        [Fact]
        public void ApiActors_GetWithNoArguments_OkAndAllActors()
        {
            var (data, statusCode) = GetArray(ActorsApi);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void ApiActors_GetWithValidActorId_OkAndActor()
        {
            var (actor, statusCode) = GetObject($"{ActorsApi}/nm0015623");

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal("1977", actor["birthyear"]);
        }

        /* /api/movies */
        [Fact]
        public void ApiMovies_GetWithNoArguments_OkAndAllMovies()
        {
            var (data, statusCode) = GetArray(MoviesApi);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void ApiMovies_GetWithValidMovieId_OkAndMovie()
        {
            var (movie, statusCode) = GetObject($"{MoviesApi}/tt8769260");

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal("2019", movie["endyear"]);
        }

        /* /api/episodes */
        [Fact]
        public void ApiEpisodes_GetWithNoArguments_OkAndAllEpisodes()
        {
            var (data, statusCode) = GetArray(EpisodesApi);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void ApiEpisodes_GetWithValidEpisodeId_OkAndEpisode()
        {
            var (episode, statusCode) = GetObject($"{EpisodesApi}/tt0583438");

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(1, episode["episodenumber"]);
        }

        /* /api/users */



        // Helpers

        (JArray, HttpStatusCode) GetArray(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) GetObject(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) PostData(string url, object content)
        {
            var client = new HttpClient();
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");
            var response = client.PostAsync(url, requestContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        HttpStatusCode PutData(string url, object content)
        {
            var client = new HttpClient();
            var response = client.PutAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(content),
                    Encoding.UTF8,
                    "application/json")).Result;
            return response.StatusCode;
        }

        HttpStatusCode DeleteData(string url)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync(url).Result;
            return response.StatusCode;
        }

    }
}
