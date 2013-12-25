using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Playlists
{
    internal class PlaylistResources : EntityResourceBase<Playlist>, IPlaylistResources
    {
        public PlaylistResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }

        #region Implementation of IEntityPut<Playlist>

        public Playlist Put(Playlist entity)
        {
            return PutEntityAsync(entity).Result;
        }

        public async Task<Playlist> PutAsync(Playlist entity)
        {
            return await PutEntityAsync(entity);
        }

        #endregion

        #region Implementation of IEntityDelete

        public void Delete()
        {
            DeleteEntityAsync();
        }

        public async Task DeleteAsync()
        {
            await DeleteEntityAsync();
        }

        #endregion
    }
}