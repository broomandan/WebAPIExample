using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LakePuzzle.Business
{
    public class ModelValidator
    {
        public ModelValidator(object objectToValidate)
        {
            objectBeingValidated = objectToValidate;
        }

        private static object objectBeingValidated { get; set; }

        public List<ValidationResult> ValidationErrors { get; private set; }

        public bool IsValid()
        {
            if (objectBeingValidated != null)
            {
                ValidationErrors = new List<ValidationResult>();
                var context = new ValidationContext(objectBeingValidated,
                    null,
                    null);

                bool isValid = Validator.TryValidateObject(objectBeingValidated,
                    context,
                    ValidationErrors);

                if (!isValid)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }

}
