using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lib.Exceptions
{
    public class ValidationExeption : Exception
    {
        public Dictionary<string, string> ValidationErrors { get; set; }

        public Type VmType { get; set; }

        public ValidationExeption(Type vmType, Dictionary<string, string> validationErrors, Exception innerException = null)
            : base($"Failed to validate entity of type \"{vmType.Name}\"\n{JsonConvert.SerializeObject(validationErrors, Formatting.Indented)}", innerException)
        {
            ValidationErrors = validationErrors;
            VmType = vmType;
        }
    }
}
