using Modular.Core.Models.Entity;

namespace matthewpalmer.dev.Models
{
    public class AllOrganisationViewModel
    {

        #region "  Properties  "

        public List<Modular.Core.Models.Entity.Organisation> Organisations { get; set; }

        #endregion

        #region "  Constructors  "

        public AllOrganisationViewModel()
        {
            Organisations = new List<Modular.Core.Models.Entity.Organisation>();
        }

        public AllOrganisationViewModel(List<Modular.Core.Models.Entity.Organisation> Organisations)
        {
            this.Organisations = Organisations;
        }



        #endregion

    }
}
