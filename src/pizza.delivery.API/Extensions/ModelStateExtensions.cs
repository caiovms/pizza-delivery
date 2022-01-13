using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace pizza.delivery.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static string[] GetErrors(this ModelStateDictionary modelState)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            var errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors)
                .Select(modelError => modelError.ErrorMessage)
                .Where(errorMessage => !string.IsNullOrWhiteSpace(errorMessage))
                .ToArray();

            return errors;
        }
    }
}