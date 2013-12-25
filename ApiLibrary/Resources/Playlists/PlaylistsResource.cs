using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Playlists
{
    internal class PlaylistsResource : EntitiesResourceBase<Playlist, IPlaylistResources>
    {
        private const string RelativePathFormat = "/playlists";

        public PlaylistsResource(ISoundCloudClient soundCloudClient)
            : base(soundCloudClient, RelativePathFormat)
        {
        }

        public PlaylistsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<User,IUserResources>

        public override IPlaylistResources this[string id]
        {
            get { return new PlaylistResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}