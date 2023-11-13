using Modular.Core;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using static Modular.Core.Models.Entity.Contact;

namespace matthewpalmer.dev.Models.Contact
{
    public class ConfigurationViewModel
    {

        #region "  Properties  "

        public string Key { get; set; }

        public string Value { get; set; }

        #endregion

        #region "  Constructors  "

        public ConfigurationViewModel(Configuration configuration)
        {
            Key = configuration.Key;
            Value = configuration.Value;
        }

        #endregion

    }
}
