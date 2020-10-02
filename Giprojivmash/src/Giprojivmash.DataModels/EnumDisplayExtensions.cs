using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Giprojivmash.DataModels
{
    public static class EnumDisplayExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue is null)
            {
                throw new ArgumentNullException(nameof(enumValue));
            }

            MemberInfo[] memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            Type attributeType = typeof(DisplayAttribute);
            object[] attributes = memberInfo[0].GetCustomAttributes(attributeType, false);
            if (attributes == null || attributes.Length != 1)
            {
                throw new ArgumentOutOfRangeException($"Невозможно найти атрибут по имени '{nameof(DisplayAttribute)}'");
            }

            var attribute = attributes.SingleOrDefault() as DisplayAttribute;
            return attribute?.Name;
        }
    }
}
