
using Modular.Core.Models.Location;
using System.ComponentModel.DataAnnotations;

namespace matthewpalmer.dev.Models.Country
{
    public class CountryEditModel
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

        public CountryEditModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            Code = string.Empty;
        }

        public CountryEditModel(Modular.Core.Models.Location.Country country)
        {
            Name = country.Name;
            Description = country.Description;
            Code = country.Code;
        }

        #endregion

    }
}
