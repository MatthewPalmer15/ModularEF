using System.ComponentModel.DataAnnotations;

namespace Modular.Core.Helpers.Types
{

    public enum ResponseType
    {
        [Display(Name = "Unknown")]
        Unknown = 0,

        [Display(Name = "Yes")]
        Yes = 1,

        [Display(Name = "No")]
        No = 2,

        [Display(Name = "Maybw")]
        Maybe = 3,

        [Display(Name = "Not Applicable")]
        NotApplicable = 4,

        [Display(Name = "Not Selected")]
        NotSelected = 5
    }

}
