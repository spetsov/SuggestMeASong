using System;
using System.Collections.Generic;
using System.Linq;

namespace Ewk.SoundCloud.ApiLibrary
{
    /// <summary>
    /// Represents an error that was returned by the soundcloud API.
    /// </summary>
    /// <example>
    /// {"errors": [{"error_message": "401 - Unauthorized"}]}
    /// </example>
    public class Errors
    {
        /// <summary>
        /// A list of errors that occurred.
        /// </summary>
        public IEnumerable<Error> errors { get; set; }

        public override string ToString()
        {
            if (errors == null) return string.Empty;

            return errors
                .Select(error =>
                        error.error_message)
                .Aggregate(string.Empty,
                           ((error1, error2) =>
                            string.Format("{0}{1}{2}", error1, Environment.NewLine, error2)));
        }
    }

    /// <summary>
    /// Represents an error that was returned by the soundcloud API.
    /// </summary>
    /// <example>
    /// {"error_message": "401 - Unauthorized"}
    /// </example>
    public class Error
    {
        /// <summary>
        /// The message of the error.
        /// </summary>
        public string error_message { get; set; }
    }
}