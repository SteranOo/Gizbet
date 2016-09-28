using System;
using System.ComponentModel.DataAnnotations;

namespace Gizbet.WEB.Attributes
{
    public class DateRangeValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var date = (DateTime)value;
            return date >= Convert.ToDateTime("1/1/1900") && date <= DateTime.Now;
        }
    }
}