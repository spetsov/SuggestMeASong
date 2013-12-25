using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    /// <summary>
    /// Defines the accessibility of the user favorite resources.
    /// </summary>
    public interface IUserFavoriteResources : IEntityGet<Track>, IEntityPut<Track>, IEntityDelete
    {
    }
}