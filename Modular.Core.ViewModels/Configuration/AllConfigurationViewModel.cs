using Modular.Core.Models.Entity;

namespace matthewpalmer.dev.Models.Contact
{
    public class AllConfigurationViewModel
    {

        #region "  Properties  "

        public List<Modular.Core.Models.Config.Configuration> Configurations { get; set; }

        #endregion

        #region "  Constructors  "

        public AllConfigurationViewModel()
        {
            Configurations = new List<Modular.Core.Models.Config.Configuration>();
        }

        public AllConfigurationViewModel(List<Modular.Core.Models.Config.Configuration> configurations)
        {
            this.Configurations = configurations;
        }



        #endregion

    }
}
