using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient
{
    public static class HttpClientExtensions
    {
        public static async Task<TContent> GetJsonAsync<TContent>(this System.Net.Http.HttpClient client, string requestUri)
        {
            var responseMessage = await client.GetAsync(requestUri);
            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.ReadJsonAsync<TContent>();

            return default;
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(this System.Net.Http.HttpClient client, string requestUri, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new JsonStringContent(data)
            };

            return await client.SendAsync(request);
        }

        public static Task<HttpResponseMessage> PostAsyncWithParameters(this System.Net.Http.HttpClient client, string requestUri, object data, string contentType = "application/x-www-form-urlencoded")
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

        public static Task<HttpResponseMessage> PutJsonAsync(this System.Net.Http.HttpClient client, string requestUri, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new JsonStringContent(data)
            };

            return client.SendAsync(request);
        }

        public static Task<HttpResponseMessage> PatchJsonAsync(this System.Net.Http.HttpClient client, string requestUri, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, requestUri)
            {
                Content = new JsonStringContent(data)
            };

            return client.SendAsync(request);
        }

        public static Task<HttpResponseMessage> DeleteAsync<TContent>(this System.Net.Http.HttpClient client, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            return client.SendAsync(request);
        }

        public static Task<HttpResponseMessage> DeleteAsync<TContent>(this System.Net.Http.HttpClient client, string url, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = new JsonStringContent(data)
            };

            return client.SendAsync(request);
        }

        public static async Task<TContent> ReadJsonAsync<TContent>(this HttpResponseMessage httpResponseMessage)
        {
            var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            return Deserialize<TContent>(stream);
        }

        private static T Deserialize<T>(Stream s)
        {
            using (StreamReader reader = new StreamReader(s))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }

    public class JsonStringContent : StringContent
    {
        public JsonStringContent(object data)
            : this(data, Encoding.UTF8, "application/json")
        {
        }

        public JsonStringContent(object data, Encoding encoding)
            : this(data, encoding, "application/json")
        {
        }

        public JsonStringContent(object data, Encoding encoding, string contentType)
            : base(JsonConvert.SerializeObject(data), encoding, contentType)
        {
        }
    }
}
