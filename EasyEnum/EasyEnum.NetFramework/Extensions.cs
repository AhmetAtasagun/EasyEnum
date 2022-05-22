using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyEnum.NetFramework
{
    public static class Extensions
    {
        /// <summary>
        /// <see href="EN"/> : Returns the enum's index number. | 
        /// <see href="TR"/> : Enum'un indis numarasını verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static int GetEnumIndex<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            Array values = typeof(TEnum).GetEnumValues();
            return Array.IndexOf(values, @enum);
        }

        /// <summary>
        /// <see href="EN"/> : Returns the index number of the enum's object type. | 
        /// <see href="TR"/> : Enum'un obje türünde indis numarasını verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static object GetEnumValue<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            object obj = @enum.GetEnumIndex();
            return obj;
        }

        /// <summary>
        /// <see href="EN"/> : Returns the name of the enum. | 
        /// <see href="TR"/> : Enum'un adını verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetEnumName<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            var enumText = Enum.GetName(typeof(TEnum), @enum);
            return enumText;
        }

        /// <summary>
        /// <see href="EN"/> : Returns the assigned value of the first found Attribute of the Enum. | 
        /// <see href="TR"/> : Enum'a ait, ilk bulduğu Özniteliğin atanan değerini verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static object GetEnumFirstCustomAttributeValue<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            var enumMember = typeof(TEnum).GetMember(@enum.GetEnumName()).FirstOrDefault();
            if (enumMember == null) return default;

            var customAttribute = enumMember.GetCustomAttributesData().FirstOrDefault();
            if (customAttribute == null) return default;

            object enumAttributeValue;
            if (customAttribute.ConstructorArguments.Any())
                enumAttributeValue = customAttribute.ConstructorArguments.FirstOrDefault().Value;
            else
                enumAttributeValue = customAttribute.NamedArguments.FirstOrDefault().TypedValue.Value;
            return enumAttributeValue;
        }

        /// <summary>
        /// <see href="EN"/> : Returns the assigned value of the Attribute of the Enum, whose Type is given. | 
        /// <see href="TR"/> : Enum'a ait, Tipi verilen Özniteliğin atanan değerini verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <param name="customAttributeType"></param>
        /// <returns></returns>
        public static object GetEnumCustomAttributeValue<TEnum>(this TEnum @enum, Type customAttributeType) where TEnum : struct, Enum
        {
            var enumMember = typeof(TEnum).GetMember(@enum.GetEnumName()).FirstOrDefault();
            if (enumMember == null) return default;

            var customAttribute = enumMember.GetCustomAttributesData().Where(w => w.AttributeType.Name == customAttributeType.Name).FirstOrDefault();
            if (customAttribute == null) return default;

            object enumAttributeValue;
            if (customAttribute.ConstructorArguments.Any())
                enumAttributeValue = customAttribute.ConstructorArguments.FirstOrDefault().Value;
            else
                enumAttributeValue = customAttribute.NamedArguments.FirstOrDefault().TypedValue.Value;
            return enumAttributeValue;
        }

        /// <summary>
        /// <see href="EN"/> : Returns a string of assigned values ​​of all given Attributes belonging to the Enum. | 
        /// <see href="TR"/> : Enum'a ait, verilen tüm Özniteliklerin atanan değerleri dizesini verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <param name="customAttributesTypes"></param>
        /// <returns></returns>
        public static object[] GetEnumCustomAttributesValues<TEnum>(this TEnum @enum, params Type[] customAttributesTypes) where TEnum : struct, Enum
        {
            object[] array = customAttributesTypes.Select(s => @enum.GetEnumCustomAttributeValue(s)).ToArray();
            return array;
        }

        /// <summary>
        /// <see href="EN"/> : Returns the string of values of all Attributes belonging to the Enum. | 
        /// <see href="TR"/> : Enum'a ait tüm Özniteliklerin değerleri dizesini verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static object[] GetEnumAllCustomAttributesValues<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            var enumMember = typeof(TEnum).GetMember(@enum.GetEnumName()).FirstOrDefault();
            if (enumMember == null) return Array.Empty<object>();

            var customAttributes = enumMember.GetCustomAttributesData();
            if (customAttributes == null) return Array.Empty<object>();
            if (customAttributes.Count <= 0) return Array.Empty<object>();

            List<object> values = new List<object>();
            foreach (var customAttribute in customAttributes)
            {
                if (customAttribute.ConstructorArguments.Any())
                    values.Add(customAttribute.ConstructorArguments.FirstOrDefault().Value ?? new object());
                else
                    values.Add(customAttribute.NamedArguments.FirstOrDefault().TypedValue.Value ?? new object());
            }
            return values.ToArray();
        }

        /// <summary>
        /// <see href="EN"/> : Returns the desired Attribute that the Enum has. | 
        /// <see href="TR"/> : Enum'un sahip olduğu, istenen Özniteliği verir.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static TAttribute GetMemberCustomAttribute<TAttribute>(this Enum @enum) where TAttribute : Attribute
        {
            if (!(@enum is Enum)) throw new NotSupportedException("value, is not enum!");
            var enumType = @enum.GetType();
            var name = Enum.GetName(enumType, @enum);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }
}
