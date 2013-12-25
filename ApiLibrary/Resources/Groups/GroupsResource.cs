using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Groups
{
    class GroupsResource : EntitiesResourceBase<Group, IGroupResources>
    {
        private const string RelativePathFormat = "/groups";

        public GroupsResource(ISoundCloudClient soundCloudClient)
            : base(soundCloudClient, RelativePathFormat)
        {
        }

        public GroupsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<Group,IGroupResources>

        public override IGroupResources this[string id]
        {
            get { return new GroupResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}