using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    class TracksResource : EntitiesResourceBase<Track, ITrackResources>
    {
        private const string RelativePathFormat = "/tracks";

        public TracksResource(ISoundCloudClient soundCloudClient)
            : base(soundCloudClient, RelativePathFormat)
        {
        }

        public TracksResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<Track,ITrackResources>

        public override ITrackResources this[string id]
        {
            get { return new TrackResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}