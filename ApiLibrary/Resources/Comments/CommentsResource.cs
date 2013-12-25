using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Comments
{
    internal class CommentsResource : EntitiesResourceBase<Comment, ICommentResources>
    {
        private const string RelativePathFormat = "/comments";

        public CommentsResource(ISoundCloudClient soundCloudClient)
            : base(soundCloudClient, RelativePathFormat)
        {
        }

        public CommentsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<User,IUserResources>

        public override ICommentResources this[string id]
        {
            get { return new CommentResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}