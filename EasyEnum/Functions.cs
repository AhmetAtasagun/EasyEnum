using EasyEnum.Exceptions;

namespace EasyEnum
{
    public class Functions
    {
        public TEnum ParseOfEnumValueByMemberName<TEnum>(string enumMemberName) where TEnum : struct, Enum
        {
            var parsingDocumentType = Enum.Parse(typeof(TEnum), enumMemberName);
            if (parsingDocumentType == null)
                throw new EnumValueNotFoundException("Name is not exist in Enum Members!");
            return (TEnum)parsingDocumentType;
        }

        public TEnum ParseOfEnumValueOrDefaultByMemberName<TEnum>(string enumMemberName) where TEnum : struct, Enum
        {
            var parsingDocumentType = Enum.Parse(typeof(TEnum), enumMemberName);
            if (parsingDocumentType == null)
                throw default;
            return (TEnum)parsingDocumentType;
        }

        public TEnum ParseOfEnumByMemberType<TEnum>(Type typeOfEnumMemberName) where TEnum : struct, Enum
        {
            return ParseOfEnumByMemberName<TEnum>(typeOfEnumMemberName.Name);
        }

        public TEnum ParseOfEnumByMemberName<TEnum>(string enumMemberName) where TEnum : struct, Enum
        {
            var parsingDocumentType = Enum.Parse(typeof(TEnum), enumMemberName);
            if (parsingDocumentType == null)
                throw new TypeLoadException("member name is not exist in member names!");
            return (TEnum)parsingDocumentType;
        }
    }
}
