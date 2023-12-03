#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Country
{
    public class CountryEditModel
    {

        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

    }
}
