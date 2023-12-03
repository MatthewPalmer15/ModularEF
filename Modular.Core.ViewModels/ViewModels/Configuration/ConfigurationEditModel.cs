#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Configuration
{
    public class ConfigurationEditModel
    {

        public Guid Id { get; set; }


        [Display(Name = "Key")]
        public string Key { get; set; }

        [Display(Name = "Value")]
        public string Value { get; set; }

    }
}
