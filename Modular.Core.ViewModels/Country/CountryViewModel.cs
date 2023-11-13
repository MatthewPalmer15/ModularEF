using Modular.Core;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using System.ComponentModel.DataAnnotations;
using static Modular.Core.Models.Entity.Contact;

namespace matthewpalmer.dev.Models.Country
{
    public class CountryViewModel
    {

        #region "  Properties  "

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        #endregion

        #region "  Constructors  "

        public CountryViewModel(Modular.Core.Models.Location.Country country)
        {
            Name = country.Name;
            Description = country.Description;
            Code = country.Code;
        }

        #endregion

    }
}
