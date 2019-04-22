using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

namespace BarView
{
    public static class APIClient
    {
        private static HttpClient habitue = new HttpClient();
        public static void Connect()
        {
            habitue.BaseAddress = new Uri(ConfigurationManager.AppSettings["IPAddress"]);
            habitue.DefaultRequestHeaders.Accept.Clear();
            habitue.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static T GetRequest<T>(string requestUrl)
        {
            var response = habitue.GetAsync(requestUrl);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }
            throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
           
        }
        public static U PostRequest<T, U>(string requestUrl, T model)
        {
            var response = habitue.PostAsJsonAsync(requestUrl, model);
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
