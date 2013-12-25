using System;
using System.Collections.Generic;
using Ewk.Extensions;
using Ewk.SoundCloud.ApiLibrary.Entities;
using Ewk.SoundCloud.ApiLibrary.Resources;
using Ewk.SoundCloud.ApiLibrary.Resources.Comments;
using Ewk.SoundCloud.ApiLibrary.Resources.Groups;
using Ewk.SoundCloud.ApiLibrary.Resources.Playlists;
using Ewk.SoundCloud.ApiLibrary.Resources.Tracks;
using Ewk.SoundCloud.ApiLibrary.Resources.Users;

namespace Ewk.SoundCloud.ApiLibrary
{
    /// <summary>
    /// Provides a fluent interface to the soundcloud api.
    /// </summary>
    public class SoundCloud
    {
        private readonly ISoundCloudClient _soundCloudClient;
        private const string ConnectUrl = "https://soundcloud.com/connect";

        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="clientId">The api key of your soundcloud app.</param>
        public SoundCloud(string clientId)
            : this(new SoundCloudClient(clientId), null)
        {
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="clientId">The api key of your soundcloud app.</param>
        /// <param name="accessToken">The token that can be used to access protected resources.</param>
        public SoundCloud(string clientId, string accessToken)
            : this(new SoundCloudClient(clientId), accessToken)
        {
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="soundCloudClient">A mocked soundcloud client.</param>
        internal SoundCloud(ISoundCloudClient soundCloudClient)
            : this(soundCloudClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="soundCloudClient">A mocked soundcloud client.</param>
        /// <param name="accessToken">The token that can be used to access protected resources.</param>
        internal SoundCloud(ISoundCloudClient soundCloudClient, string accessToken)
        {
            if (soundCloudClient == null) throw new ArgumentNullException("soundCloudClient");

            _soundCloudClient = soundCloudClient;

            if (string.IsNullOrEmpty(accessToken)) return;

            _soundCloudClient.OAuthToken = new OAuth2Token {access_token = accessToken};
        }

        #endregion

        /// <summary>
        /// Sets the number of entities that are returned when using paging.
        /// </summary>
        /// <param name="size">The page size for paging.</param>
        public void SetPageSize(int size)
        {
            _soundCloudClient.PageSize = size;
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the OAuth2 authorization endpoint.
        /// Your app redirects a user to this endpoint, allowing them to delegate access to their account.
        /// </summary>
        /// <param name="redirectUri">The redirect uri you have configured for your application.</param>
        /// <returns>The <see cref="Uri"/> of the OAuth2 authorization endpoint.</returns>
        public Uri GetAuthorizeUri(Uri redirectUri)
        {
            _soundCloudClient.RedirectUri = redirectUri;

            var queryParameters = new Dictionary<string, string>
                {
                    {"client_id", _soundCloudClient.ClientId},
                    {"redirect_uri", redirectUri.AbsoluteUri},
                    {"response_type", "code"},
                    {"scope", "non-expiring"}
                };

            return ConnectUrl.AddQueryStringParameters(queryParameters);
        }

        /// <summary>
        /// Requests an <see cref="OAuth2Token"/> using the <see cref="Uri"/> that was requested after the Authorization by the user.
        /// </summary>
        /// <param name="responseUri">The complete <see cref="Uri"/> of the request after Authorization.</param>
        /// <param name="clientSecret">The api secret of the app.</param>
        /// <returns>An <see cref="OAuth2Token"/> that can be used to access protected resources.</returns>
        public OAuth2Token RequestOAuthToken(Uri responseUri, string clientSecret)
        {
            if (responseUri == null) throw new ArgumentNullException("responseUri");

            if (_soundCloudClient.RedirectUri == null)
            {
                var baseUrl = new Uri(responseUri.GetLeftPart(UriPartial.Authority));
                _soundCloudClient.RedirectUri = new Uri(baseUrl, responseUri.AbsolutePath);
            }

            var queryPairs = responseUri.GetQueryParameters();
            if (queryPairs.ContainsKey("error"))
            {
                throw new ArgumentException(string.Format("Error: {0}, Description: {1}", queryPairs["error"], queryPairs["error_description"]));
            }

            return _soundCloudClient.OAuthToken = _soundCloudClient.RequestOAuthToken(queryPairs["code"], clientSecret);
        }

        /// <summary>
        /// Represents the endpoint for the authenticated SoundCloud user.
        /// </summary>
        public IMeResources Me
        {
            get { return _me ?? (_me = new MeResources(_soundCloudClient)); }
        }
        private IMeResources _me;

        /// <summary>
        /// Represents the endpoint for SoundCloud users.
        /// </summary>
        public IEntitiesResource<User, IUserResources<User>> Users
        {
            get { return _users ?? (_users = new UsersResource(_soundCloudClient)); }
        }
        private IEntitiesResource<User, IUserResources<User>> _users;

        /// <summary>
        /// Represents the endpoint for SoundCloud tracks.
        /// </summary>
        public IEntitiesResource<Track, ITrackResources> Tracks
        {
            get { return _tracks ?? (_tracks = new TracksResource(_soundCloudClient)); }
        }
        private IEntitiesResource<Track, ITrackResources> _tracks;

        /// <summary>
        /// Represents the endpoint for SoundCloud playlists.
        /// </summary>
        public IEntitiesResource<Playlist, IPlaylistResources> Playlists
        {
            get { return _playlists ?? (_playlists = new PlaylistsResource(_soundCloudClient)); }
        }
        private IEntitiesResource<Playlist, IPlaylistResources> _playlists;

        /// <summary>
        /// Represents the endpoint for SoundCloud comments.
        /// </summary>
        public IEntitiesResource<Comment, ICommentResources> Comments
        {
            get { return _comments ?? (_comments = new CommentsResource(_soundCloudClient)); }
        }
        private IEntitiesResource<Comment, ICommentResources> _comments;

        /// <summary>
        /// Represents the endpoint for SoundCloud groups.
        /// </summary>
        public IEntitiesResource<Group, IGroupResources> Groups
        {
            get { return _groups ?? (_groups = new GroupsResource(_soundCloudClient)); }
        }
        private IEntitiesResource<Group, IGroupResources> _groups;
    }
}