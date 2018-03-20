﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nile
{
    /// <summary>Provides support for validating data.</summary>
    public static class ObjectValidator
    {
        /// <summary>Validates an object and all properties.</summary>
        /// <param name="value">The object to validate.</param>
        /// <returns>The validation results.</returns>
        public static IEnumerable<ValidationResult> Validate( object value )
        {
            var context = new ValidationContext(value);
            var errors = new Collection<ValidationResult>();
            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }
    }
}