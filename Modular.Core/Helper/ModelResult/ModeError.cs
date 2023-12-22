namespace Modular.Core
{

    public class ModelError
    {

        public ModelError()
        {
            this.PropertyName = string.Empty;
            this.Description = string.Empty;
            this.Code = string.Empty;
        }

        public ModelError(string propertyName, string description, string? code)
        {
            this.PropertyName = propertyName;
            this.Description = description;
            this.Code = code;
        }

        public string PropertyName { get; set; }

        public string Description { get; set; }

        public string? Code { get; set; }


    }
}
