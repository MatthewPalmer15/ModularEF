
using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Country
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

        public CountryEditModel(Models.Location.Country country)
        {
            Name = country.Name;
            Description = country.Description;
            Code = country.Code;
        }

        #endregion

        #region "  Public Methods  "

        public Models.Location.Country Convert()
        {
            return new Models.Location.Country
            {
                Name = Name,
                Description = Description,
                Code = Code
            };
        }

        #endregion

    }
}
