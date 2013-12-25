using System;

namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents a web profile
    /// </summary>
    public class WebProfile : Entity
    {
        public int id { get; set; }
        public string service { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string username { get; set; }
        public string created_at { get; set; }

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