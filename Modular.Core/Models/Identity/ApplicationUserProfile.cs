
#nullable disable

namespace Modular.Core.Identity
{
    public class ApplicationUserProfile : BaseEntity<Guid>
    {

        public string Bio { get; set; }

        public byte[] Avatar { get; set; }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public string TwitterLink { get; set; }

        public string LinkedInLink { get; set; }

        public string WebsiteLink { get; set; }

    }
}
