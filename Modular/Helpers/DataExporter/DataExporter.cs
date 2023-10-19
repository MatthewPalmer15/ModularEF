using Modular.Core.Entities.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Entities.DataExporter
{
    public static class DataExporter
    {

        public static DirectoryInfo ScriptFolder
        {
            get
            {
                using (ModularCoreDbContext context = new ModularCoreDbContext())
                {
                    Configuration config = context.Configurations.SingleOrDefault(x => x.Key == "ScriptFolder");

                    if (config != null)
                    {
                        return new DirectoryInfo(config.Value);
                    }
                    else
                    {
                        throw Exception("ScriptFolder configuration not found.");
                    }
                }
            }
        }

        public static DirectoryInfo ExportFolder
        {
            get
            {
                using (ModularCoreDbContext context = new ModularCoreDbContext())
                {
                    Configuration config = context.Configurations.SingleOrDefault(x => x.Key == "ExportFolder");

                    if (config != null)
                    {
                        return new DirectoryInfo(config.Value);
                    }
                    else
                    {
                        throw Exception("ExportFolder configuration not found.");
                    }
                }
            }
        }

        public static


    }
}
