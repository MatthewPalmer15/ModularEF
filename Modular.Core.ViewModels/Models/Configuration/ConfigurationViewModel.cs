using Modular.Core.Models.Config;

namespace Modular.Core.ViewModels.Configuration
{
    public class ConfigurationViewModel
    {

        #region "  Properties  "

        public string Key { get; set; }

        public string Value { get; set; }

        #endregion

        #region "  Constructors  "

        public ConfigurationViewModel(Models.Config.Configuration configuration)
        {
            Key = configuration.Key;
            Value = configuration.Value;
        }

        #endregion

    }
}
