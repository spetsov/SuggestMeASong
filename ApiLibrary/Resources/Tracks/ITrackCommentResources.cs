using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    /// <summary>
    /// Defines the accessibility of the track comment resources.
    /// </summary>
    public interface ITrackCommentResources : IEntityGet<Comment>, IEntityPut<Comment>, IEntityDelete
    {
    }
}