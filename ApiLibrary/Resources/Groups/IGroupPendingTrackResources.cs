using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Groups
{
    /// <summary>
    /// Defines the accessibility of the group pending track resources.
    /// </summary>
    public interface IGroupPendingTrackResources : IEntityGet<Track>, IEntityPut<Track>, IEntityDelete
    {
    }
}