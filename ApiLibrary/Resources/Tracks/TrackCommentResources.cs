using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    internal class TrackCommentResources : EntityResourceBase<Comment>, ITrackCommentResources
    {
        public TrackCommentResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }

        #region Implementation of IEntityPut<Comment>

        public Comment Put(Comment entity)
        {
            return PutEntityAsync(entity).Result;
        }

        public async Task<Comment> PutAsync(Comment entity)
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