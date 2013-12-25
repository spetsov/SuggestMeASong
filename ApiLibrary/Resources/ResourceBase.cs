namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    abstract class ResourceBase
    {
        private readonly ISoundCloudClient _soundCloudClient;
        private readonly string _relativePath;

        #region Constructors

        protected ResourceBase(ISoundCloudClient soundCloudClient, string relativePath)
        {
            _soundCloudClient = soundCloudClient;
            _relativePath = relativePath;
        }

        #endregion

        protected ISoundCloudClient SoundCloudClient
        {
            get { return _soundCloudClient; }
        }

        protected string RelativePath
        {
            get { return _relativePath; }
        }
    }
}