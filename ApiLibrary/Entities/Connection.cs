using System;

namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents a connection.
    /// </summary>
    public class Connection : Entity
    {
        public int id { get; set; } // ": 310235,
        public string created_at { get; set; } // ": "2010/12/04 02:28:32 +0000",
        public string display_name { get; set; } // ": "mytwittername",
        public bool? post_favorite { get; set; } // ": false,
        public bool? post_publish { get; set; } // ": false,
        public string service { get; set; } // ": "twitter",
        public string type { get; set; } // ": "twitter",
        public string uri { get; set; } // ": "https://api.soundcloud.com/connections/310235"

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

    }
}