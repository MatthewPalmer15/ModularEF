using Modular.Core.Models.Entity;

namespace matthewpalmer.dev.Models.Country
{
    public class AllCountryViewModel
    {

        #region "  Properties  "

        public List<Modular.Core.Models.Location.Country> Countries { get; set; }

        #endregion

        #region "  Constructors  "

        public AllCountryViewModel()
        {
            Countries = new List<Modular.Core.Models.Location.Country>();
        }

        public AllCountryViewModel(List<Modular.Core.Models.Location.Country> configurations)
        {
            this.Countries = configurations;
        }



        #endregion

    }
}
