using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.String;

namespace Gizbet.WEB.Attributes
{
    public class FileTypesValidateAttribute : ValidationAttribute
    {
        private readonly List<string> _types;

        public FileTypesValidateAttribute(string types)
        {
            _types = types.Split(',').ToList();
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            var httpPostedFileBase = value as HttpPostedFileBase;
            var extension = System.IO.Path.GetExtension(httpPostedFileBase?.FileName);
            if (extension != null)
            {
                var fileExt = extension.Substring(1);
                return _types.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Неподдерживаемый формат файла. Поддерживаются только типы: {Join(", ", _types)};";
        }
    }
}