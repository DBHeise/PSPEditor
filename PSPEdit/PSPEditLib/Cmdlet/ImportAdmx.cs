// 
// GetAdmx.cs
// 

namespace PSPEdit.Cmdlet
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// <para type="synopsis">Parses ADMX file</para>
    /// <para type="description">Parses the ADMX file</para>
    /// </summary>
    /// <example>
    /// <code>Import-AdmxFile -File C:\ADMX\Policy.admx</code>
    /// <para>
    /// Parses the given ADMX file in the language of the current UI culture
    /// </para>
    /// </example>
    /// <example>
    /// <code>Get-ChildItems C:\ADMX -Include *.admx | Import-AdmxFile</code>
    /// <para>
    /// Parses all the given ADMX files in the language of the current UI culture
    /// </para>
    /// </example>
    /// <example>
    /// <code>Import-AdmxFile -File C:\ADMX\Policy.admx -Language en-ES</code>
    /// <para>
    /// Parses the given ADMX file in the specified language
    /// </para>
    /// </example>
    [Cmdlet(VerbsData.Import, "AdmxFile", SupportsShouldProcess = true)]
    public class ImportAdmxFile : PSCmdlet
    {
        /// <summary>
        /// default cTor
        /// </summary>
        public ImportAdmxFile()
        {
            this.Language = System.Globalization.CultureInfo.CurrentUICulture.Name;
        }

        /// <summary>
        /// <para type="description">The ADMX file to parse</para>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public FileInfo File { get; set; }

        /// <summary>
        /// <para type="description">Language Tag (as definied in RFC5646)</para>
        /// </summary>
        [Parameter(Mandatory = false)]
        public String Language { get; set; }

        /// <summary>
        /// Powershell cmdlet processing
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject(new AdmxParse(this.File.FullName, this.Language));
        }
    }
}
