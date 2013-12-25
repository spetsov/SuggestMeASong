using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Playlists
{
    /// <summary>
    /// Defines the accessibility of the playlist resources.
    /// </summary>
    public interface IPlaylistResources : IEntityGet<Playlist>, IEntityPut<Playlist>, IEntityDelete
    {
    }
}