
using HttpClient;

namespace Web.API.HttpClient.Base
{
    public class BaseClient
    {
        private readonly System.Net.Http.HttpClient client = null;
        private readonly IConfiguration _configuration;
        private string token = "";

        public string Token
        {
            get
            {
                return token;
            }
            set
            {
                token = value;
                if (client != null)
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }
                }
            }
        }

        public BaseClient(IConfiguration configuration, string Token = "")
        {
            _configuration = configuration;
            client = new System.Net.Http.HttpClient();
            string address = _configuration["HttpClientSetting:Adress"].ToString();
            client.BaseAddress = new Uri(address);
        }

        public async Task<TContent> GetJsonAsync<TContent>(string requestUri)
        {
            var responseMessage = await client.GetAsync(requestUri);
            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.ReadJsonAsync<TContent>();
            return default;
        }

        public async Task<HttpResponseMessage> PostJsonAsync(string requestUri, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new JsonStringContent(data)
            };

            return await client.SendAsync(request);
        }

        public Task<HttpResponseMessage> PostAsyncWithParameters(string requestUri, object data, string contentType = "application/x-www-form-urlencoded")
        {
            string jsonObject = JsonConvert.SerializeObject(data);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonObject))
            };
            client.DefaultRequestHeaders.Clear();
            request.Headers.Add("contentType", contentType);
            return client.SendAsync(request);
        }

        public Task<HttpResponseMessage> PutJsonAsync(string requestUri, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new JsonStringContent(data)
            };

            return client.SendAsync(request);
        }

        public Task<HttpResponseMessage> PatchJsonAsync(string requestUri, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, requestUri)
            {
                Content = new JsonStringContent(data)
            };

            return client.SendAsync(request);
        }

        public Task<HttpResponseMessage> DeleteAsync<TContent>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            return client.SendAsync(request);
        }

        public Task<HttpResponseMessage> DeleteAsync<TContent>(string url, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = new JsonStringContent(data)
            };

            return client.SendAsync(request);
        }

        public async Task<TContent> ReadJsonAsync<TContent>(HttpResponseMessage httpResponseMessage)
        {
            var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            return Deserialize<TContent>(stream);
        }

        private T Deserialize<T>(Stream s)
        {
            using (StreamReader reader = new StreamReader(s))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
