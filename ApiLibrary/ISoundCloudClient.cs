using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary
{
    /// <summary>
    /// Provides access to the soundcloud api.
    /// </summary>
    public interface ISoundCloudClient
    {
        /// <summary>
        /// The api key of the application.
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// The OAuth token that is used for accessing resources that need authorization.
        /// </summary>
        OAuth2Token OAuthToken { get; set; }

        /// <summary>
        /// The Uri that is redirected to after the user has authorized the app.
        /// </summary>
        Uri RedirectUri { get; set; }

        /// <summary>
        /// The number of items that are returned when multiple instances on a resource are requested.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Requests an OAuth token from the soundcloud api that can be used by the application with the <see cref="OAuthToken"/>.
        /// </summary>
        /// <param name="code">The code that was returned by soundcloud after the user authorized the application.</param>
        /// <param name="clientSecret">The api secret of the application.</param>
        OAuth2Token RequestOAuthToken(string code, string clientSecret);

        /// <summary>
        /// Gets the first page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path);

        /// <summary>
        /// Gets the first page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <param name="order">The property to order the available items by.<example>created_at</example></param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order);

        /// <summary>
        /// Gets the i-th page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <param name="page">The page number.</param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, int page);

        /// <summary>
        /// Gets the i-th page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <param name="order">The property to order the available items by.<example>created_at</example></param>
        /// <param name="page">The page number.</param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order, int page);

        /// <summary>
        /// Gets the first page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <param name="parameters">
        /// Filter parameters.
        /// <example>
        /// order => 'created_at'
        /// limit => page_size, :
        /// offset => page_size, :
        /// tags => tags, :
        /// q => search_term, :
        /// streamable => streamable(true/false)
        /// </example>
        /// </param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the first page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <param name="order">The property to order the available items by.<example>created_at</example></param>
        /// <param name="parameters">
        /// Filter parameters.
        /// <example>
        /// order => 'created_at'
        /// limit => page_size, :
        /// offset => page_size, :
        /// tags => tags, :
        /// q => search_term, :
        /// streamable => streamable(true/false)
        /// </example>
        /// </param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the i-th page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <param name="page">The page number.</param>
        /// <param name="parameters">
        /// Filter parameters.
        /// <example>
        /// order => 'created_at'
        /// limit => page_size, :
        /// offset => page_size, :
        /// tags => tags, :
        /// q => search_term, :
        /// streamable => streamable(true/false)
        /// </example>
        /// </param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, int page, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the i-th page of the list resource.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource items.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <param name="page">The page number.</param>
        /// <param name="order">The property to order the available items by.<example>created_at</example></param>
        /// <param name="parameters">
        /// Filter parameters.
        /// <example>
        /// order => 'created_at'
        /// limit => page_size, :
        /// offset => page_size, :
        /// tags => tags, :
        /// q => search_term, :
        /// streamable => streamable(true/false)
        /// </example>
        /// </param>
        /// <returns>A list of instances of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<IEnumerable<TResponse>> GetPageAsync<TResponse>(string path, string order, int page, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the resource of <see cref="Type"/> <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> of the resource item.</typeparam>
        /// <param name="path">The relative path of the resource.</param>
        /// <returns>An instance of <typeparamref name="TResponse"/></returns>
        /// <exception cref="SoundCloudException">The exception that is thrown if the soundcloud API returns errors.</exception>
        Task<TResponse> GetAsync<TResponse>(string path);

        Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request);

        Task<TResponse> PutAsync<TResponse, TRequest>(string path, TRequest request);

        Task<TResponse> DeleteAsync<TResponse>(string path);
    }
}