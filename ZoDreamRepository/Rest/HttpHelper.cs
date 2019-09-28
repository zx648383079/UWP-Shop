using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Repository.Rest
{
    public class HttpHelper
    {


        /// <summary>           
        /// The Base URL for the API.
        /// /// </summary>
        private readonly string _baseUrl;

        public HttpHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Makes an HTTP GET request to the given controller and returns the deserialized response content.
        /// </summary>
        public async Task<TResult> GetAsync<TResult>(string controller, Action<HttpException> action)
        {
            using (var client = CreateHttp())
            {
                var obj = await client.AppendPath(controller).ExecuteAsync<TResult>(action);
                return obj;
            }
        }

        public async Task<TResult> GetAsync<TResult>(string controller, string key, object value, Action<HttpException> action)
        {
            using (var client = CreateHttp())
            {
                var obj = await client.AppendPath(controller).AddQuery(key, value.ToString()).ExecuteAsync<TResult>(action);
                return obj;
            }
        }

        public async Task<TResult> GetAsync<TResult>(string controller, Dictionary<string, string> parameters, Action<HttpException> action)
        {
            using (var client = CreateHttp())
            {
                var obj = await client.AppendPath(controller).AddQueries(parameters).ExecuteAsync<TResult>(action);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP POST request to the given controller with the given object as the body.
        /// Returns the deserialized response content.
        /// </summary>
        public async Task<TResult> PostAsync<TRequest, TResult>(string controller, TRequest body, Action<HttpException> action)
        {
            using (var client = CreatePostHttp())
            {
                var obj = await client.AppendPath(controller).SetBody(new JsonStringContent(body)).ExecuteAsync<TResult>(action);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP DELETE request to the given controller and includes all the given
        /// object's properties as URL parameters. Returns the deserialized response content.
        /// </summary>
        public async Task<TResult> DeleteAsync<TRequest, TResult>(string controller, uint objectId, Action<HttpException> action)
        {
            using (var client = CreateHttp())
            {
                client.Method = HttpMethod.Delete;
                return await client.AppendPath($"{controller}/{objectId}").ExecuteAsync<TResult>(action);
            }
        }

        /// <summary>
        /// Constructs the base HTTP client, including correct authorization and API version headers.
        /// </summary>
        public RestClient CreateHttp()
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var headers = new Dictionary<string, string>
            {
                { "Date", timestamp },
                { "Content-Type", "application/vnd.api+json" },
                { "Accept", "application/json" }
            };
            if (!string.IsNullOrEmpty(Constants.Token))
            {
                headers.Add("Authorization", "Bearer " + Constants.Token);
            }
            return new RestClient(_baseUrl)
                .AddQuery("appid", Constants.AppId).AddQuery("timestamp", timestamp)
                .AddQuery("sign", EncryptWithMD5(Constants.AppId + timestamp + Constants.Secret)).AddHeaders(headers);
        }

        public RestClient CreatePostHttp()
        {
            var client = CreateHttp();
            client.Method = HttpMethod.Post;
            return client;
        }

        public static string ToBase64String(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        public static string UnBase64String(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            var bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string EncryptWithMD5(string source)
        {
            var sor = Encoding.UTF8.GetBytes(source);
            var md5 = MD5.Create();
            var result = md5.ComputeHash(sor);
            md5.Dispose();
            var strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

            }
            return strbul.ToString();
        }
    }
}
