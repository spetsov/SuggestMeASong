using System;

namespace Ewk.SoundCloud.ApiLibrary
{
    /// <summary>
    /// The <see cref="Exception"/> that is thrown when an error was returned by SoundCloud.
    /// </summary>
    public class SoundCloudException : Exception
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message">The error message.</param>
        internal SoundCloudException(string message)
            :base(message)
        {}

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="errors">The errors that where returned by SoundCloud.</param>
        internal SoundCloudException(Errors errors)
            : base(errors.ToString())
        {
            Errors = errors;
        }

        /// <summary>
        /// The errors that where returned by SoundCloud.
        /// </summary>
        public Errors Errors { get; private set; }
    }
}