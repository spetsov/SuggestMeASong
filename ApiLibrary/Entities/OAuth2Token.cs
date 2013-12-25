namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents an OAth2 access token.
    /// </summary>
    public class OAuth2Token
    {
        /// <summary>
        /// The access token.
        /// </summary>
        public string access_token { get; set; } // "04u7h-4cc355-70k3n",

        /// <summary>
        /// The scope of the token.
        /// </summary>
        public string scope { get; set; } // "non-expiring"
    }
}