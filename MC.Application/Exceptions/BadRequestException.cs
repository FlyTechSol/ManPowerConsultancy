using FluentValidation.Results;

namespace MC.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]>? ValidationErrors { get; }

        public BadRequestException(string message, IDictionary<string, string[]>? errors = null)
            : base(message)
        {
            ValidationErrors = errors;
        }

        public BadRequestException(string message, ValidationResult validationResult)
            : base(message)
        {
            ValidationErrors = validationResult.Errors
                .GroupBy(e => ToCamelCase(e.PropertyName))
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );
        }

        private static string ToCamelCase(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            // If all characters are uppercase (like "ABCID"), convert the whole string to lowercase
            if (name.All(char.IsUpper))
                return name.ToLowerInvariant();

            // Only convert the first letter to lowercase
            return char.ToLowerInvariant(name[0]) + name.Substring(1);
        }
    }
}
