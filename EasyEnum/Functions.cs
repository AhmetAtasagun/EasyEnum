using EasyEnum.Exceptions;

namespace EasyEnum
{
    public class Functions
    {
        #region Temporarily disabled.
        /// <summary>
        /// <see href="EN"/> : Returns the member of the given Enum, based on the Enum name. | 
        /// <see href="TR"/> : Enum ismine göre, verilen Enum'un üyesini verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMemberName"></param>
        /// <returns></returns>
        /// <exception cref="EnumValueNotFoundException"></exception>
        //public TEnum ParseOfEnumValueByMemberName<TEnum>(string enumMemberName) where TEnum : struct, Enum
        //{
        //    var parsingDocumentType = Enum.Parse(typeof(TEnum), enumMemberName);
        //    if (parsingDocumentType == null)
        //        throw new EnumValueNotFoundException("Name is not exist in Enum Members!");
        //    return (TEnum)parsingDocumentType;
        //}

        /// <summary>
        /// <see href="EN"/> : Returns the member of the given Enum, by the name of the Enum, or a null value. | 
        /// <see href="TR"/> : Enum ismine göre, verilen Enum'un üyesini, yoksa boş değer verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMemberName"></param>
        /// <returns></returns>
        //public TEnum ParseOfEnumValueOrDefaultByMemberName<TEnum>(string enumMemberName) where TEnum : struct, Enum
        //{
        //    var parsingDocumentType = Enum.Parse(typeof(TEnum), enumMemberName);
        //    if (parsingDocumentType == null)
        //        throw default;
        //    return (TEnum)parsingDocumentType;
        //} 
        #endregion

        /// <summary>
        /// <see href="EN"/> : Returns the assigned value of the first found Attribute of the Enum. | 
        /// <see href="TR"/> : Enum'a ait, ilk bulduğu Özniteliğin atanan değerini verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="typeOfEnumMemberName"></param>
        /// <returns></returns>
        public TEnum ParseOfEnumByMemberType<TEnum>(Type typeOfEnumMemberName) where TEnum : struct, Enum
        {
            return ParseOfEnumByMemberName<TEnum>(typeOfEnumMemberName.Name);
        }

        /// <summary>
        /// <see href="EN"/> : Returns the assigned value of the first found Attribute of the Enum. | 
        /// <see href="TR"/> : Enum'a ait, ilk bulduğu Özniteliğin atanan değerini verir.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMemberName"></param>
        /// <returns></returns>
        /// <exception cref="TypeLoadException"></exception>
        public TEnum ParseOfEnumByMemberName<TEnum>(string enumMemberName) where TEnum : struct, Enum
        {
            var parsingDocumentType = Enum.Parse(typeof(TEnum), enumMemberName);
            if (parsingDocumentType == null)
                throw new TypeLoadException("member name is not exist in member names!");
            return (TEnum)parsingDocumentType;
        }
    }
}
