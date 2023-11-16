using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Configuration
{
    public class ConfigurationEditModel
    {

        #region "  Properties  "

        public Guid Id { get; private set; }

        [Display(Name = "Key")]
        public string Key { get; set; }

        [Display(Name = "Value")]
        public string Value { get; set; }

        #endregion

        #region "  Constructors  "

        public ConfigurationEditModel()
        {
            Id = Guid.Empty;
            Key = string.Empty; 
            Value = string.Empty;
        }

        public ConfigurationEditModel(Models.Config.Configuration configuration)
        {
            Id = configuration.Id;
            Key = configuration.Key;
            Value = configuration.Value;
        }

        #endregion

        #region "  Public Methods  "

        public Models.Config.Configuration Convert()
        {
            return new Models.Config.Configuration
            {
                Key = Key,
                Value = Value
            };
        }

        #endregion

    }
}
