using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class MeResources : UserResourcesBase<UserMe>, IMeResources
    {
        private const string RelativePathFormat = "/me";

        #region Constructors

        public MeResources(ISoundCloudClient soundCloudClient)
            : base(soundCloudClient, RelativePathFormat)
        {
        }

        #endregion

        #region Implementation of IMeResources

        public IEntitiesResource<Connection, IMeConnectionResources> Connections
        {
            get { return _connections ?? (_connections = new MeConnectionsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesResource<Connection, IMeConnectionResources> _connections;

        #endregion
    }
}