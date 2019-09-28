using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Repository.Rest
{
    public class RestClient: IDisposable
    {
        public string BaseUri { get; set; }

        public string Path { get; set; }

        public HttpMethod Method { get; set; } = HttpMethod.Get;

        public Dictionary<string, string> Queries { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        public StringContent Content { get; set; }

        public Dictionary<string, string> Contents { get; set; } = new Dictionary<string, string>();


        public RestClient()
        {

        }

        public RestClient(string baseUri)
        {
            BaseUri = baseUri;
        }

        public RestClient(string baseUri, HttpMethod method)
        {
            BaseUri = baseUri;
            Method = method;
        }

        public RestClient(string baseUri, string path)
        {
            BaseUri = baseUri;
            Path = path;
        }

        public RestClient(string baseUri, string path, HttpMethod method)
        {
            BaseUri = baseUri;
            Path = path;
            Method = method;
        }


        public RestClient AppendPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return this;
            }
            if (string.IsNullOrEmpty(Path))
            {
                Path = path;
                return this;
            }
            Path = Path.TrimEnd('/') + "/" + path.TrimStart('/');
            return this;
        }

        public RestClient AddQueries(Dictionary<string, string> parameters)
        {
            if (parameters == null) return this;
            foreach (var parameter in parameters)
            {
                this.Queries[parameter.Key] = parameter.Value;
            }
            return this;
        }

        public RestClient AddQuery(string key, string value)
        {
            Queries[key] = value;
            return this;
        }

        public RestClient AddParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null) return this;
            foreach (var parameter in parameters)
            {
                this.Contents[parameter.Key] = parameter.Value;
            }
            return this;
        }

        public RestClient AddParameter(string key, string value)
        {
            Contents[key] = value;
            return this;
        }

        public RestClient AddHeader(string key, string value)
        {
            Headers[key] = value;
            return this;
        }

        public RestClient AddHeaders(Dictionary<string, string> headers)
        {
            foreach (var item in headers)
            {
                AddHeader(item.Key, item.Value);
            }
            return this;
        }

        public RestClient SetContents(Dictionary<string, string> data)
        {
            if (data != null)
                this.Contents = data;
            return this;
        }

        public RestClient SetBody(StringContent body)
        {
            Method = HttpMethod.Post;
            Content = body;
            return this;
        }

        public RestClient SetBody(JsonStringContent body)
        {
            return SetBody(body as StringContent);
        }

        public RestClient SetBody(JContainer body)
        {
            return SetBody(new JsonStringContent(body.ToString()));
        }

        public async Task<T> ExecuteAsync<T>(Action<HttpException> action)
        {
            return await ExecuteAsync<T>(null, async res =>
            {
                if (res == null)
                {
                    action?.Invoke(new HttpException());
                    return;
                }
                var content = await res.Content.ReadAsStringAsync();
                if (content.IndexOf("code") <= 0)
                {
                    action?.Invoke(new HttpException((int)res.StatusCode, content));
                    return;
                }
                action?.Invoke(JsonConvert.DeserializeObject<HttpException>(content));
            });
        }

        public async Task<T> ExecuteAsync<T>(Action<HttpResponseMessage> succes = null, Action<HttpResponseMessage> failure = null)
        {
            var content = await ExecuteAsync(succes, failure);
            Debug.WriteLine("Info: " + content);
            //if (typeof(T) == typeof(string))
            //{
            //    return (T)(object)content;
            //}
            //if (typeof(T) == typeof(JObject))
            //{
            //    return (T)(object)JObject.Parse(content);
            //}
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<string> ExecuteAsync(Action<HttpResponseMessage> succes = null, Action<HttpResponseMessage> failure = null)
        {
            if (string.IsNullOrEmpty(BaseUri)) return string.Empty;
            var httpClient = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                Method = Method
            };

            var uri = new Uri(BaseUri, UriKind.Absolute);
            if (Method != HttpMethod.Get && Method != HttpMethod.Delete)
            {
                if (Content != null)
                {
                    //Headers.Add("Content-type", "application/x-www-form-urlencoded"); 自己设
                    requestMessage.Content = Content;
                }
                else if (Contents != null && Contents.Any())
                {
                    requestMessage.Content = new JsonStringContent(BuildJson());
                }
            }
            ExtractHeaders(requestMessage);
            requestMessage.RequestUri = new Uri(uri, AddQeuryString());
            try
            {
                Debug.WriteLine("Info: " + requestMessage.RequestUri.ToString());
                var responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

                if (responseMessage == null)
                {
                    failure?.Invoke(null);
                    return string.Empty;
                }

                if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    Debug.WriteLine($"status code:{responseMessage.StatusCode}; {content}");
                    failure?.Invoke(responseMessage);
                    return string.Empty;
                }
                succes?.Invoke(responseMessage);
                return await responseMessage.Content.ReadAsStringAsync();
            }
            catch
            {
                failure?.Invoke(null);
            }
            return string.Empty;
        }

        private string AddQeuryString()
        {
            var query = BuildQuery();
            if (string.IsNullOrEmpty(query))
            {
                return Path;
            }
            if (Path.Contains("?"))
            {
                return Path + "&" + query;
            }
            return Path + "?" + query;
        }

        private void ExtractHeaders(HttpRequestMessage httpClient)
        {
            if (Headers != null && Headers.Any())
            {
                foreach (var header in Headers)
                {
                    if (header.Key == "Content-Type" && httpClient.Content != null)
                    {
                        httpClient.Content.Headers.ContentType = new MediaTypeHeaderValue(header.Value);
                    }
                    else
                    {
                        httpClient.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }
            }
        }

        private string BuildQuery()
        {
            if (Queries == null || !Queries.Any()) return string.Empty;
            var builder = new StringBuilder();
            foreach (var content in Queries)
            {
                builder.Append($"{ System.Net.WebUtility.UrlEncode(content.Key)}={ System.Net.WebUtility.UrlEncode(content.Value)}&");
            }
            var data = builder.ToString();
            return data.Substring(0, data.Length - 1);
        }

        private string BuildJson()
        {
            var jsonObject = new JObject(); ;
            foreach (var item in Contents)
            {
                jsonObject.Add(new JProperty(item.Key, item.Value));
            }
            return jsonObject.ToString();
        }

        public void Dispose()
        {
            Queries.Clear();
            Headers.Clear();
            Contents.Clear();
        }
    }

    public class JsonStringContent : StringContent
    {
        /// <summary>
        /// Creates <see cref="StringContent"/> formatted as UTF8 application/json.
        /// </summary>
        public JsonStringContent(object obj)
            : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }
}
