using System;

namespace SplitSample.Logging
{
    public class SplitLoggerOptions
    {
        private string _fileName = "logs-";

        /// <summary>
        /// Gets or sets the filename prefix to use for log files.
        /// Defaults to <c>logs-</c>.
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value));
                }
                _fileName = value;
            }
        }
    }
}