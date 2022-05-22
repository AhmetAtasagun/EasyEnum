using EasyEnum.NetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasyEnum.NetFramework
{
    public class Functions
    {
        /// <summary>
        /// <see href="EN"/> : Returns an Enum with the given name parameter of the specified Enum. | 
        /// <see href="TR"/> : Tipi belirtilen Enum'a ait, verilen isim parametreli bir Enum değeri verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="typeOfEnumMemberName"></param>
        /// <returns></returns>
        public static TEnum ParseOfEnumByMemberType<TEnum>(Type typeOfEnumMemberName) where TEnum : struct, Enum
        {
            return ParseOfEnumByMemberName<TEnum>(typeOfEnumMemberName.Name);
        }

        /// <summary>
        /// <see href="EN"/> : Returns an Enum with the given name parameter of the specified Enum. | 
        /// <see href="TR"/> : Tipi belirtilen Enum'a ait, verilen isim parametreli bir Enum değeri verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMemberName"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static TEnum ParseOfEnumByMemberName<TEnum>(string enumMemberName) where TEnum : struct, Enum
        {
            var parsingDocumentType = Enum.Parse(typeof(TEnum), enumMemberName);
            if (parsingDocumentType == null)
                throw new NullReferenceException("member name is not exist in member names!");
            return (TEnum)parsingDocumentType;
        }

        /// <summary>
        /// <see href="EN"/> : Returns an Enum with the given name parameter of the specified Enum. | 
        /// <see href="TR"/> : Tipi belirtilen Enum'a ait, verilen isim parametreli bir Enum değeri verir.
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="enumMemberName"></param>
        /// <returns>object</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static object ParseOfEnumByMemberName(Type enumType, string enumMemberName)
        {
            var parsingDocumentType = Enum.Parse(enumType, enumMemberName);
            if (parsingDocumentType == null)
                throw new NullReferenceException("member name is not exist in member names!");
            return parsingDocumentType;
        }

        /// <summary>
        /// <see href="EN"/> : Returns the names in the Enum as Key and the value of the Enum as Value (whatever the value type given to <see href="TValue"/> is) |
        /// <see href="TR"/> : Key olarak Enum içerisindeki isimleri, Value olarak da Enum'a ait değeri verir (<see href="TValue"/> ye verilen değer tipi ne ise o)
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumValueMember<TValue>> GetEnumMemberNamesAndValues<TEnum, TValue>() where TEnum : struct, Enum where TValue : struct
        {
            var members = GetEnumDeclaredMembers<TEnum>();
            List<int> values = (List<int>)Enum.GetValues(typeof(TEnum)).GetEnumerator();
            var result = members.Select(s => new EnumValueMember<TValue>
            {
                Member = ParseOfEnumByMemberName<TEnum>(s.Name),
                Name = s.Name,
                Value = (TValue)ParseOfEnumByMemberName<TEnum>(s.Name).GetEnumValue()
            }).ToList();
            return result;
        }

        /// <summary>
        /// <see href="EN"/> : Returns the names in the Enum as Key and the value of the Enum as Value. |
        /// <see href="TR"/> : Key olarak Enum içerisindeki isimleri, Value olarak da Enum'a ait değeri verir.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumMember> GetEnumMemberNamesAndIntValues<TEnum>() where TEnum : struct, Enum
        {
            var members = GetEnumDeclaredMembers<TEnum>();
            var result = members.Select(s => new EnumMember
            {
                Member = ParseOfEnumByMemberName<TEnum>(s.Name),
                Name = s.Name,
                Value = ParseOfEnumByMemberName<TEnum>(s.Name).GetEnumIndex()
            }).ToList();
            return result;
        }




        #region Private Helpers
        public static string[] DefaultFieldMemberNameKeys = new string[] { "_", "Int32", "int32" };
        internal static List<MemberInfo> GetEnumDeclaredMembers<TEnum>()
        {
            return typeof(TEnum).GetMembers()
                .Where(w => w.MemberType == MemberTypes.Field && !DefaultFieldMemberNameKeys.Any(a => w.Name.Contains(a)))
                .ToList();
        }

        internal static List<MemberInfo> GetEnumDeclaredMembers(Type enumType)
        {
            return enumType.GetMembers()
                .Where(w => w.MemberType == MemberTypes.Field && !DefaultFieldMemberNameKeys.Any(a => w.Name.Contains(a)))
                .ToList();
        }
        #endregion
    }
}
