namespace API_processor.Mappers
{
    public class WSwersionData
    {
        /// <summary>
        /// Gets or sets a value indicating ComputerName.
        /// </summary>
        required public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if file exists.
        /// </summary>
        public bool ІsFileWxists { get; set; }

        /// <summary>
        /// Gets or sets a value of file version.
        /// </summary>
        public string? FileVersion { get; set; }

        /// <summary>
        /// Gets or sets a value of checking date.
        /// </summary>
        public string? CkeckDate { get; set; }
    }
}