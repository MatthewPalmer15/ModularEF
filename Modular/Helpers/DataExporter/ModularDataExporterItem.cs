using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Helpers.Exporter
{
    public class DataExporterItem
    {

        #region "  Constructors  "

        private DataExporterItem()
        {
            this.File = new FileInfo(string.Empty);
        }

        public DataExporterItem(FileInfo File)
        {
            this.File = File;

            using (StreamReader streamReader = new StreamReader(File.FullName))
            {
                this.Script = streamReader.ReadToEnd();

                do
                {
                    string? scriptLine = streamReader.ReadLine();
                    if (scriptLine != null && scriptLine.StartsWith("-- "))
                    {
                        string[] SplitScriptLine = scriptLine.Split(new string[] { "-- " }, StringSplitOptions.None);
                        if (SplitScriptLine.Length > 1)
                        {
                            string[] SplitScriptLine2 = SplitScriptLine[1].Split(new string[] { ": " }, StringSplitOptions.None);
                            if (SplitScriptLine2.Length > 1)
                            {
                                switch (SplitScriptLine2[0].ToUpper())
                                {
                                    case "NAME":
                                        this.Name = SplitScriptLine2[1];
                                        break;

                                    case "DESCRIPTION":
                                        this.Description = SplitScriptLine2[1];
                                        break;

                                    case "CATEGORY":
                                        this.Category = SplitScriptLine2[1];
                                        break;
                                }
                            }
                        }
                    }
                } while (!streamReader.EndOfStream);
            }
        }

         #endregion

        #region "  Properties  "

        public FileInfo File { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Category { get; private set; } = string.Empty;

        public string Script { get; private set; } = string.Empty;

        #endregion

    }
}
