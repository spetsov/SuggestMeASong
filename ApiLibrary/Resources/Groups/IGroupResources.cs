using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Groups
{
    /// <summary>
    /// Defines the accessibility of the group resource.
    /// </summary>
    public interface IGroupResources : IEntityGet<Group>
    {
        /// <summary>
        /// Represents the endpoint for SoundCloud moderators.
        /// </summary>
        IEntitiesGet<User> Moderators { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud members.
        /// </summary>
        IEntitiesGet<User> Members { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud contributors.
        /// </summary>
        IEntitiesGet<User> Contributors { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud users.
        /// </summary>
        IEntitiesGet<User> Users { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud tracks.
        /// </summary>
        IEntitiesGet<Track> Tracks { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud pending tracks.
        /// </summary>
        IEntitiesResource<Track, IGroupPendingTrackResources> PendingTracks { get; }
    }
}