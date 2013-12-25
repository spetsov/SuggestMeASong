using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    internal class TrackResources : EntityResourceBase<Track>, ITrackResources
    {
        public TrackResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }

        #region Implementation of IEntityPut<Track>

        public Track Put(Track entity)
        {
            return PutEntityAsync(entity).Result;
        }

        public async Task<Track> PutAsync(Track entity)
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

        #region Implementation of ITrackResources

        public IEntitiesResource<Comment, ITrackCommentResources> Comments
        {
            get { return _comments ?? (_comments = new TrackCommentsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesResource<Comment, ITrackCommentResources> _comments;

        public IEntitiesResource<User, ITrackFavoriterResources> Favoriters
        {
            get { return _favoriters ?? (_favoriters = new TrackFavoritersResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesResource<User, ITrackFavoriterResources> _favoriters;

        #endregion
    }
}