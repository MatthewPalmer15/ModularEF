using Modular.Core.Models.Entity;

namespace matthewpalmer.dev.Models.Contact
{
    public class AllContactViewModel
    {

        #region "  Properties  "

        public List<Modular.Core.Models.Entity.Contact> contacts { get; set; }

        #endregion

        #region "  Constructors  "

        public AllContactViewModel()
        {
            contacts = new List<Modular.Core.Models.Entity.Contact>();
        }

        public AllContactViewModel(List<Modular.Core.Models.Entity.Contact> contacts)
        {
            this.contacts = contacts;
        }



        #endregion

    }
}
