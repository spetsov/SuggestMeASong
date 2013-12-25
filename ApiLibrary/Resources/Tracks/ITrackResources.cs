using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    /// <summary>
    /// Defines the accessibility of the track resource.
    /// </summary>
    public interface ITrackResources : IEntityGet<Track>, IEntityPut<Track>, IEntityDelete
    {
        /// <summary>
        /// Represents the endpoint for SoundCloud comments on tracks.
        /// </summary>
        IEntitiesResource<Comment, ITrackCommentResources> Comments { get; }

        /// <summary>
        /// Represents the endpoint for SoundCloud favoriters on tracks.
        /// </summary>
        IEntitiesResource<User, ITrackFavoriterResources> Favoriters { get; }
    }
}