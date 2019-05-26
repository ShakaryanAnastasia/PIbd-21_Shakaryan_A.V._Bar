using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BarWeb
{
    public static class APIClient
    {
        private static HttpClient client = new HttpClient();

        public static void Connect()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T GetRequest<T>(string requestUrl)
        {
            var response = client.GetAsync("http://localhost:50392/" + requestUrl);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }
            throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
        }

        public static U PostRequest<T, U>(string requestUrl, T model)
        {
            var response = client.PostAsJsonAsync("http://localhost:50392/" + requestUrl, model);
            if (response.Result.IsSuccessStatusCode)
            {
                if (typeof(U) == typeof(bool))
                {
                    return default(U);
                }
                return response.Result.Content.ReadAsAsync<U>().Result;
            }
            throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
        }
    }
}