namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity
    {
        internal virtual ISoundCloudClient SoundCloudClient { get; set; }
    }
}