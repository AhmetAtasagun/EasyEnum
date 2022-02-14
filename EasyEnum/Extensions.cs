namespace EasyEnum
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

            var enumAttributeValue = customAttribute.NamedArguments.FirstOrDefault().TypedValue.Value;
            return enumAttributeValue;
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

            var enumAttributeValue = customAttribute.NamedArguments.FirstOrDefault().TypedValue.Value;
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
            List<object> values = new List<object>();
            foreach (var customAttributeType in customAttributesTypes)
            {
                values.Add(@enum.GetEnumCustomAttributeValue(customAttributeType));
            }
            object[] array = values.ToArray();
            values.Clear();
            GC.Collect();
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
            if (enumMember == null) return default;

            var customAttributes = enumMember.GetCustomAttributesData();
            if (customAttributes == null) return default;
            if (customAttributes.Count <= 0) return default;

            var values = customAttributes.Select(s => s.NamedArguments.FirstOrDefault()).Select(s => s.TypedValue.Value).ToList();
            return values.ToArray();
        }

        /// <summary>
        /// <see href="EN"/> : Returns the names in the Enum as Key and the value of the Enum as Value (whatever the value type given to <see href="TValue"/> is) |
        /// <see href="TR"/> : Key olarak Enum içerisindeki isimleri, Value olarak da Enum'a ait değeri verir (<see href="TValue"/> ye verilen değer tipi ne ise o)
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, TValue>> GetEnumMemberNamesAndValues<TValue>(this Type enumType) /*where TEnum : IConvertible// for enum*/
        {
            var dict = new Dictionary<string, TValue>();
            foreach (TValue value in Enum.GetValues(enumType))
            {
                var name = Enum.GetName(enumType, value);
                dict.Add(name, value);
            }
            return dict.ToList();
        }

        /// <summary>
        /// <see href="EN"/> : Returns the names in the Enum as Key and the value of the Enum as Value. |
        /// <see href="TR"/> : Key olarak Enum içerisindeki isimleri, Value olarak da Enum'a ait değeri verir.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, int>> GetEnumMemberNamesAndIntValues(this Type enumType) /*where TEnum : IConvertible// for enum*/
        {
            var dict = new Dictionary<string, int>();
            foreach (int value in Enum.GetValues(enumType))
            {
                var name = Enum.GetName(enumType, value);
                dict.Add(name, value);
            }
            return dict.ToList();
        }
    }
}
