using Microsoft.EntityFrameworkCore;
using Modular.Core;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using System.ComponentModel.DataAnnotations;

namespace matthewpalmer.dev.Models.Contact
{
    public class ConfigurationEditModel
    {

        #region "  Properties  "

        [Display(Name = "Key")]
        public string Key { get; set; }

        [Display(Name = "Value")]
        public string Value { get; set; }

        #endregion

        #region "  Constructors  "

        public ConfigurationEditModel()
        {
            Key = string.Empty; 
            Value = string.Empty;
        }

        public ConfigurationEditModel(Configuration configuration)
        {
            Key = configuration.Key;
            Value = configuration.Value;
        }

        #endregion

    }
}
