using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    internal class MeConnectionResources : EntityResourceBase<Connection>, IMeConnectionResources
    {
        public MeConnectionResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }

        #region Implementation of IEntityPost<Connection>

        public Connection Post(Connection entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Connection> PostAsync(Connection entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}