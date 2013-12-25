using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class MeConnectionsResource : EntitiesResourceBase<Connection, IMeConnectionResources>
    {
        private const string RelativePathFormat = "/connections";

        public MeConnectionsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<Connection,IMeConnectionResources>

        public override IMeConnectionResources this[string id]
        {
            get { return new MeConnectionResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}