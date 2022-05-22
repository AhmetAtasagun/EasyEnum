using EasyEnum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyEnum.Core
{
    public class HtmlHelpers
    {
        /// <summary>
        /// <see href="EN"/> : Via Enum for html select element; Enum, Name and Value. |
        /// <see href="TR"/> : Html select elementi için Enum üzerinden; Enum, İsim ve Değeri verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<EnumMember> ForSelect<TEnum>() where TEnum : struct, Enum
        {
            Type enumType = typeof(TEnum);
            var members = Functions.GetEnumDeclaredMembers(enumType);
            var result = members.Select(s => new EnumMember
            {
                Member = (TEnum)Functions.ParseOfEnumByMemberName(enumType, s.Name),
                Name = s.Name,
                Value = ((TEnum)Functions.ParseOfEnumByMemberName(enumType, s.Name)).GetEnumIndex()
            }).ToList();
            return result;
        }

        /// <summary>
        /// <see href="EN"/> : For the html select element, over the Enum, taking into account the Attribute whose Type is given; Enum, Name, Value and Attribute Value. |
        /// <see href="TR"/> : Html select elementi için Enum üzerinden, Tipi verilen Özniteliğide dikkate alarak; Enum, İsim, Değer ve Öznitelik Değeri verir.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumMemberCustomValue<TValue>> ForSelectCustomValues<TEnum, TValue>(Type customAttributeType) where TEnum : struct, Enum
        {
            Type enumType = typeof(TEnum);
            var members = Functions.GetEnumDeclaredMembers(enumType);
            var result = members.Select(s => new EnumMemberCustomValue<TValue>
            {
                Member = Functions.ParseOfEnumByMemberName<TEnum>(s.Name),
                Name = s.Name,
                Value = ((TEnum)Functions.ParseOfEnumByMemberName(enumType, s.Name)).GetEnumIndex(),
                CustomValue = (TValue)((TEnum)Functions.ParseOfEnumByMemberName(enumType, s.Name)).GetEnumCustomAttributeValue(customAttributeType)
            }).ToList();
            return result;
        }
    }
}
