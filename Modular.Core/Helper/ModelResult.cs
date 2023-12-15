using FluentValidation.Results;

namespace Modular.Core.Helpers
{
    public class ModelResult
    {

        private ModelResult(bool isValid, List<ModelError>? errors = null)
        {
            this.IsValid = isValid;
            this.Errors = errors ?? new List<ModelError>();
        }

        public bool IsValid { get; private set; }

        public List<ModelError> Errors { get; private set; }


        public static ModelResult Success()
        {
            return new ModelResult(true);
        }

        public static ModelResult Failed(IList<ModelError> errors)
        {
            return new ModelResult(false, errors.ToList());
        }

        public static ModelResult Failed(IList<ValidationFailure> errors)
        {
            ModelResult result = new ModelResult(false);
            foreach (var error in errors)
            {
                result.Errors.Add(new ModelError { PropertyName = error.PropertyName, Description = error.ErrorMessage, Code = error.ErrorCode });
            }

            return result;
        }

    }


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
