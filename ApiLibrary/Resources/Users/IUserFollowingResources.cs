using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    /// <summary>
    /// Defines the accessibility of the user following resources.
    /// </summary>
    public interface IUserFollowingResources : IEntityGet<User>, IEntityPut<User>, IEntityDelete
    {
    }
}