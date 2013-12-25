using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    /// <summary>
    /// Defines the accessibility of the me resources.
    /// </summary>
    public interface IMeResources : IUserResources<UserMe>
    {
        /// <summary>
        /// Represents the endpoint for SoundCloud connections.
        /// </summary>
        IEntitiesResource<Connection, IMeConnectionResources> Connections { get; }
    }
}