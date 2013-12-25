using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    internal class TrackFavoriterResources : EntityResourceBase<User>, ITrackFavoriterResources
    {
        public TrackFavoriterResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }
    }
}