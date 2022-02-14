namespace EasyEnum
{
    public static class Extensions
    {
        public static int GetEnumIndex<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            Array values = typeof(TEnum).GetEnumValues();
            return Array.IndexOf(values, @enum);
        }

        public static string GetEnumName<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            var enumText = Enum.GetName(typeof(TEnum), @enum);
            return enumText;
        }

        public static object GetEnumCustomAttributeValue<TEnum>(this TEnum @enum, Type customAttributeType) where TEnum : struct, Enum
        {
            var enumMember = typeof(TEnum).GetMember(@enum.GetEnumName()).FirstOrDefault();
            if (enumMember == null) return default;

            var customAttribute = enumMember.GetCustomAttributesData().Where(w => w.AttributeType.Name == customAttributeType.Name).FirstOrDefault();
            if (customAttribute == null) return default;

            var enumAttributeValue = customAttribute.NamedArguments.FirstOrDefault().TypedValue.Value;
            return enumAttributeValue;
        }

        public static object GetEnumFirstCustomAttributeValue<TEnum>(this TEnum @enum) where TEnum : struct, Enum
        {
            var enumMember = typeof(TEnum).GetMember(@enum.GetEnumName()).FirstOrDefault();
            if (enumMember == null) return default;

            var customAttribute = enumMember.GetCustomAttributesData().FirstOrDefault();
            if (customAttribute == null) return default;

            var enumAttributeValue = customAttribute.NamedArguments.FirstOrDefault().TypedValue.Value;
            return enumAttributeValue;
        }

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

        /// Summary : Key olarak Enum içerisindeki isimleri, Value olarak da Enum'a ait değeri verir (<src name="TValue"/> ye verilen değer tipi ne ise o)
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

        /// Summary : Key olarak Enum içerisindeki isimleri, Value olarak da Enum'a ait değeri verir
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
