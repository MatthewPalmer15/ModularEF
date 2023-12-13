using FluentValidation.Results;

namespace Modular.Core.Helpers
{
    public class ModelResult
    {

        private ModelResult() { }

        public bool IsValid { get; private set; }

        public List<ModelError> Errors { get; private set; }


        public static ModelResult Success()
        {
            ModelResult result = new ModelResult()
            {
                IsValid = true,
                Errors = new List<ModelError>()
            };
            return result;
        }

        public static ModelResult Failed(ModelError[] errors) 
        {
            ModelResult result = new ModelResult()
            {
                IsValid = false,
                Errors = errors.ToList()
            };
            return result;
        }

        public static ModelResult Failed(ValidationFailure[] errors) 
        {
            ModelResult result = new ModelResult()
            {
                IsValid = false,
                Errors = new List<ModelError>()
            };

            foreach(var error in errors)
            {
                result.Errors.Add(new ModelError { PropertyName = error.PropertyName, Description = error.ErrorMessage, Code = error.ErrorCode });
            }

            return result;
        }

    }


    public class ModelError
    {

        public ModelError() { }

        public string PropertyName { get; set; }

        public string Description { get; set; }

        public string? Code { get; set; }


    }
}
