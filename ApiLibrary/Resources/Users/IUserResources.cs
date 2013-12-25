using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    /// <summary>
    /// Defines the accessibility of the user resources.
    /// </summary>
    public interface IUserResources<T> : IEntityGet<T>
        where T : User
    {
        /// <summary>
        /// Represents the endpoint for SoundCloud tracks.
        /// </summary>
        IEntitiesGet<Track> Tracks { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud groups.
        /// </summary>
        IEntitiesGet<Group> Groups { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud comments.
        /// </summary>
        IEntitiesGet<Comment> Comments { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud playlists.
        /// </summary>
        IEntitiesGet<Playlist> Playlists { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud followers.
        /// </summary>
        IEntitiesResource<User, IUserFollowerResources> Followers { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud followings.
        /// </summary>
        IEntitiesResource<User, IUserFollowingResources> Followings { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud favorites.
        /// </summary>
        IEntitiesResource<Track, IUserFavoriteResources> Favorites { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud web-profiles.
        /// </summary>
        IEntitiesGet<WebProfile> WebProfiles { get; }
    }
}