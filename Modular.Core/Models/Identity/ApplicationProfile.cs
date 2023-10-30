namespace Modular.Core.Identity
{
    public class ApplicationProfile : BaseEntity
    {

        #region "  Properties  "

        public string Name { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public string Colour { get; set; } = string.Empty;

        public byte[] Avatar { get; set; } = new byte[0];

        public byte[] BackgroundImage { get; set; } = new byte[0];

        #endregion

    }
}
