using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Comments
{
    /// <summary>
    /// Defines the accessibility of the comment resources.
    /// </summary>
    public interface ICommentResources : IEntityGet<Comment>, IEntityPut<Comment>, IEntityDelete
    {
    }
}