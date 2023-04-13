using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace _0_Framework.Application
{
    public class FileExtentionLimitationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _validExtention;

        public FileExtentionLimitationAttribute(string[] validExtention)
        {
            _validExtention = validExtention;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;
            
            var fileExtention = Path.GetExtension(file.FileName);

            //if (!_validExtention.Contains(fileExtention))
            //    return false;
            //return true;
            return _validExtention.Contains(fileExtention);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-fileExtentionLimit", ErrorMessage);

        }
    }
}
