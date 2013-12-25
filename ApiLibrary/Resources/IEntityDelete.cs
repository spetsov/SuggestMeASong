using System.Threading.Tasks;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    /// <summary>
    /// Provides methods to delete entities from soundcloud.
    /// </summary>
    public interface IEntityDelete
    {
        /// <summary>
        /// Deletes the current èntity from soundcloud.
        /// </summary>
        void Delete();

        /// <summary>
        /// Deletes the current èntity from soundcloud.
        /// </summary>
        Task DeleteAsync();
    }
}