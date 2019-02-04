// ReSharper disable once CheckNamespace
namespace X12ResourceTool
{
    [System.AttributeUsage(System.AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MapAttribute : System.Attribute
    {
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// Interchange Control Version Number (ISA12)
        /// </summary>
        public string icvn { get; set; }
        /// <summary>
        /// Version / Release / Industry Identifier Code (GS08)
        /// </summary>
        public string vriic { get; set; }
        /// <summary>
        /// Functional Identifier Code (GS01)
        /// </summary>
        public string fic { get; set; }
        public string tspc { get; set; }
        public string abbr { get; set; }
        /// <summary>
        /// The map XML file name.
        /// </summary>
        public string map { get; set; }
        /// <summary>
        /// The comma-separated list of segments.
        /// </summary>
        public string segmentsCsv { get; set; }
    }
}
