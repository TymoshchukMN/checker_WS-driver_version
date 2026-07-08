using System.ComponentModel.DataAnnotations;

namespace VersionStorage.Mappers
{
    public class WSwersionData
    {
        /// <summary>
        /// Gets or sets a value indicating ComputerName.
        /// </summary>
        [Key]
        required public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if file exists.
        /// </summary>
        public bool IsFileExists { get; set; }

        /// <summary>
        /// Gets or sets a value of file version.
        /// </summary>
        public string? FileVersion { get; set; }

        /// <summary>
        /// Gets or sets a value of checking date.
        /// </summary>
        public string? CheckDate { get; set; }
    }
}