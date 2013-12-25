using System;

namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents a comment.
    /// </summary>
    public class Comment : Entity
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        /// <example>123</example>
        public int id { get; set; }

        /// <summary>
        /// API resource URL
        /// </summary>
        /// <example>"http://api.soundcloud.com/comments/32562"</example>
        public string uri { get; set; }

        /// <summary>
        /// Timestamp of creation
        /// </summary>
        /// <example>"2009/08/13 18:30:10 +0000"</example>
        public string created_at { get; set; }

        /// <summary>
        /// HTML comment body
        /// </summary>
        /// <example>"i love this beat!"</example>
        public string body { get; set; }

        /// <summary>
        /// Associated timestamp in milliseconds
        /// </summary>
        /// <example>55593</example>
        public int? timestamp { get; set; }

        /// <summary>
        /// User id of the owner
        /// </summary>
        /// <example>343</example>
        public int user_id { get; set; }

        /// <summary>
        /// Mini user representation of the owner
        /// </summary>
        public MiniUser user { get; set; }

        /// <summary>
        /// The track id of the related track
        /// </summary>
        /// <example>54</example>
        public string track_id { get; set; }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representation of the created_at string.
        /// </summary>
        public DateTime? CreatedAtUtc
        {
            get
            {
                if (!_createdAtUtc.HasValue)
                {
                    var converter = new DateTimeConverter();
                    _createdAtUtc = converter.Convert(created_at);
                }

                return _createdAtUtc;
            }
        }
        private DateTime? _createdAtUtc;

        internal override ISoundCloudClient SoundCloudClient
        {
            get
            {
                return base.SoundCloudClient;
            }
            set
            {
                base.SoundCloudClient = value;
                if (user != null) user.SoundCloudClient = value;
            }
        }
    }
}