using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ewk.Extensions;
using Ewk.SoundCloud.ApiLibrary.Entities;
using Newtonsoft.Json;

namespace Ewk.SoundCloud.ApiLibrary
{
    class SoundCloudClient : ISoundCloudClient
    {
        private const string BaseUrl = "https://api.soundcloud.com";

        private readonly HttpClient _httpClient;

        #region Constructors

        public SoundCloudClient(string clientId)
        {
            if (clientId == null) throw new ArgumentNullException("clientId");

            ClientId = clientId;
            _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(BaseUrl),
                };

            PageSize = 32;
        }

        #endregion

        #region ISoundCloudClient Members

        public string ClientId { get; private set; }
        public OAuth2Token OAuthToken { get; set; }
        public Uri RedirectUri { get; set; }

        public int PageSize { get; set; }

        public OAuth2Token RequestOAuthToken(string code, string clientSecret)
        {
            var parameters = new Dictionary<string, string>
                {
                    {"client_id", ClientId},
                    {"client_secret", clientSecret},
                    {"redirect_uri", RedirectUri.AbsoluteUri},
                    {"grant_type", "authorization_code"}, // enumeration	(authorization_code, refresh_token, password, client_credentials, oauth1_token)
                    {"code", code}
                };

            return PostMessage<OAuth2Token>("/oauth2/token", parameters);
        }

        #region GetPage overloads

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path)
        {
            return await SendAsync<IEnumerable<TResponse>>(HttpMethod.Get, path);
        }

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order)
        {
            return await GetPageAsync<TResponse>(path, order, new Dictionary<string, string>());
        }

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, int page)
        {
            return await GetPageAsync<TResponse>(path, page, new Dictionary<string, string>());
        }

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order, int page)
        {
            return await GetPageAsync<TResponse>(path, order, page, new Dictionary<string, string>());
        }

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, IDictionary<string, string> parameters)
        {
            return await SendAsync<IEnumerable<TResponse>>(HttpMethod.Get, path, parameters);
        }

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order, IDictionary<string, string> parameters)
        {
            parameters.Add("order", order);

            return await SendAsync<IEnumerable<TResponse>>(HttpMethod.Get, path, parameters);
        }

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, int page, IDictionary<string, string> parameters)
        {
            parameters.Add("limit", PageSize.ToString(CultureInfo.InvariantCulture));
            parameters.Add("offset", (PageSize * page).ToString(CultureInfo.InvariantCulture));

            return await SendAsync<IEnumerable<TResponse>>(HttpMethod.Get, path, parameters);
        }

        public async Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order, int page, IDictionary<string, string> parameters)
        {
            parameters.Add("order", order);
            parameters.Add("limit", PageSize.ToString(CultureInfo.InvariantCulture));
            parameters.Add("offset", (PageSize * page).ToString(CultureInfo.InvariantCulture));

            return await SendAsync<IEnumerable<TResponse>>(HttpMethod.Get, path, parameters);
        }

        #endregion

        #region Methods on single instances

        public async Task<TResponse> GetAsync<TResponse>(string path)
        {
            return await SendAsync<TResponse>(HttpMethod.Get, path);
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request)
        {
            var requestUri = GetRequestUri(path);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync(requestUri.AbsolutePath, request);

            return await ReadResponseAsync<TResponse>(httpResponseMessage);
        }

        public async Task<TResponse> PutAsync<TResponse, TRequest>(string path, TRequest request)
        {
            var requestUri = GetRequestUri(path);
            var httpResponseMessage = await _httpClient.PutAsJsonAsync(requestUri.AbsolutePath, request);

            return await ReadResponseAsync<TResponse>(httpResponseMessage);
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string path)
        {
            return await SendAsync<TResponse>(HttpMethod.Delete, path);
        }

        #endregion

        #endregion

        private TResponse PostMessage<TResponse>(string path, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var stringContent = parameters.ComposeQueryString();
            var requestUri = new Uri(_httpClient.BaseAddress, path);

            using (var webClient = new WebClient())
            {
                var stringResponse = webClient.UploadString(requestUri, stringContent);

                return JsonConvert.DeserializeObject<TResponse>(stringResponse);
            }
/*            
            using (var httpContent = new StringContent(sringContent))
            {
                var httpResponseMessage = await _httpClient.PostAsync(requestUri, httpContent);

                return await httpResponseMessage.Content.ReadAsAsync<TResponse>();
            }
*/
        }

        private async Task<TResponse> SendAsync<TResponse>(HttpMethod httpMethod, string path)
        {
            return await SendAsync<TResponse>(httpMethod, path, new Dictionary<string, string>());
        }

        private async Task<TResponse> SendAsync<TResponse>(HttpMethod httpMethod, string path, ICollection<KeyValuePair<string, string>> queryParameters)
        {
            var requestUri = GetRequestUri(path, queryParameters);

            using (var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri))
            {
                var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
                return await ReadResponseAsync<TResponse>(httpResponseMessage);
            }
        }

        private static async Task<TResponse> ReadResponseAsync<TResponse>(HttpResponseMessage httpResponseMessage)
        {
            var response = await httpResponseMessage.Content.ReadAsAsync<dynamic>();

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.Accepted:
                case HttpStatusCode.Created:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.OK:
                case HttpStatusCode.PartialContent:
                    return JsonConvert.DeserializeObject<TResponse>(response.ToString());
                case HttpStatusCode.NoContent:
                    return default(TResponse);
//              case HttpStatusCode.Redirect:
//              case HttpStatusCode.MovedPermanently:
//                  httpResponseMessage.Headers.Location
                default:
                    {
                        if (response.errors == null)
                        {
                            throw new SoundCloudException(response.ToString());
                        }

                        throw new SoundCloudException(JsonConvert.DeserializeObject<Errors>(response.ToString()));
                    }
            }
        }

        private Uri GetRequestUri(string path)
        {
            return GetRequestUri(path, new Dictionary<string, string>());
        }

        private Uri GetRequestUri(string path, ICollection<KeyValuePair<string, string>> queryParameters)
        {
            queryParameters.Add(
                OAuthToken == null || OAuthToken.access_token == null
                    ? new KeyValuePair<string, string>("client_id", ClientId)
                    : new KeyValuePair<string, string>("oauth_token", OAuthToken.access_token)
                );

            var relativeUrl = string.Format("{0}.json", path);

            return new Uri(_httpClient.BaseAddress, relativeUrl)
                .AddQueryStringParameters(queryParameters);
        }
    }
}