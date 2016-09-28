using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Gizbet.WEB.Attributes
{
    public class FileSizeValidateAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FileSizeValidateAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            var httpPostedFileBase = value as HttpPostedFileBase;
            return httpPostedFileBase == null || httpPostedFileBase.ContentLength <= _maxSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Размер файла не должен превышать {_maxSize} байт;";
        }
    }
}