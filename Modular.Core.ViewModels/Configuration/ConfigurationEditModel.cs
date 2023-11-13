using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Configuration
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

        public ConfigurationEditModel(Models.Config.Configuration configuration)
        {
            Key = configuration.Key;
            Value = configuration.Value;
        }

        #endregion

    }
}
