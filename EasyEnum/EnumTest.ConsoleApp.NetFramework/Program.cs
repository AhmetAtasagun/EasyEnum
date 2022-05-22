using EasyEnum.NetFramework;
using System;
using System.Threading;
using static EnumTest.ConsoleApp.NetFramework.AttributeAndEnums;

namespace EnumTest.ConsoleApp.NetFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test1(MailTypes.Outbox, typeof(DescriptionTextAttribute));
            Test2(MailTypes.Spam, typeof(DescriptionTextAttribute));
            Test3(MailTypes.Unread, typeof(SortIndexAttribute));
            Test4(MailTypes.Inbox, typeof(SortIndexAttribute));
            Test5(MailTypes.Outbox, typeof(AuthorizeAttribute));
            Test6(MailTypes.Inbox, typeof(AuthorizeAttribute));
            Test7(MailTypes.Outbox, typeof(DescriptionTextAttribute));

            Test8(MailTypes.Inbox, typeof(DescriptionTextAttribute), typeof(SortIndexAttribute), typeof(AuthorizeAttribute));
            Test9(MailTypes.Outbox, typeof(DescriptionTextAttribute), typeof(SortIndexAttribute), typeof(AuthorizeAttribute));
            Test10(MailTypes.Unread, typeof(DescriptionTextAttribute), typeof(SortIndexAttribute), typeof(AuthorizeAttribute));
            Test11(MailTypes.Spam, typeof(DescriptionTextAttribute), typeof(SortIndexAttribute), typeof(AuthorizeAttribute));

            var attribute = MailTypes.Inbox.GetMemberCustomAttribute<DescriptionTextAttribute>();
            Console.ReadKey();
        }

        private static void Test1(MailTypes enumValue, Type attributeType)
        {
            WriteLine("Test 1 Başlıyor...");
            var selectEnumValue = enumValue;
            var index = selectEnumValue.GetEnumIndex();
            var name = selectEnumValue.GetEnumName();
            var customText = selectEnumValue.GetEnumCustomAttributeValue(attributeType);
            Console.WriteLine($"EnumIndex : {index} | EnumName : {name} | {attributeType.Name} : {customText}");
            WriteLine("Test 1 Tamamlandı");
        }

        private static void Test2(MailTypes enumValue, Type attributeType)
        {
            var selectEnumValue = enumValue;
            var index = selectEnumValue.GetEnumIndex();
            var name = selectEnumValue.GetEnumName();
            var customText = selectEnumValue.GetEnumCustomAttributeValue(attributeType);
            Console.WriteLine($"EnumIndex : {index} | EnumName : {name} | {attributeType.Name} : {customText}");
        }

        private static void Test3(MailTypes enumValue, Type attributeType)
        {
            var selectEnumValue = enumValue;
            var index = selectEnumValue.GetEnumIndex();
            var name = selectEnumValue.GetEnumName();
            var customText = selectEnumValue.GetEnumCustomAttributeValue(attributeType);
            Console.WriteLine($"EnumIndex : {index} | EnumName : {name} | {attributeType.Name} : {customText}");
        }

        private static void Test4(MailTypes enumValue, Type attributeType)
        {
            var selectEnumValue = enumValue;
            var index = selectEnumValue.GetEnumIndex();
            var name = selectEnumValue.GetEnumName();
            var customText = selectEnumValue.GetEnumCustomAttributeValue(attributeType);
            Console.WriteLine($"EnumIndex : {index} | EnumName : {name} | {attributeType.Name} : {customText}");
        }

        private static void Test5(MailTypes enumValue, Type attributeType)
        {
            var selectEnumValue = enumValue;
            var index = selectEnumValue.GetEnumIndex();
            var name = selectEnumValue.GetEnumName();
            var customText = selectEnumValue.GetEnumCustomAttributeValue(attributeType);
            Console.WriteLine($"EnumIndex : {index} | EnumName : {name} | {attributeType.Name} : {customText}");
        }

        private static void Test6(MailTypes enumValue, Type attributeType)
        {
            var selectEnumValue = enumValue;
            var index = selectEnumValue.GetEnumIndex();
            var name = selectEnumValue.GetEnumName();
            var customText = selectEnumValue.GetEnumCustomAttributeValue(attributeType);
            Console.WriteLine($"EnumIndex : {index} | EnumName : {name} | {attributeType.Name} : {customText}");
        }

        private static void Test7(MailTypes enumValue, Type attributeType)
        {
            var selectEnumValue = enumValue;
            var index = selectEnumValue.GetEnumIndex();
            var name = selectEnumValue.GetEnumName();
            var customText = selectEnumValue.GetEnumCustomAttributeValue(attributeType);
            Console.WriteLine($"EnumIndex : {index} | EnumName : {name} | {attributeType.Name} : {customText}");
        }

        private static void Test8(MailTypes enumValue, params Type[] attributeTypes)
        {
            var selectEnumValue = enumValue;

            var values = selectEnumValue.GetEnumCustomAttributesValues(attributeTypes);
            var values3 = selectEnumValue.GetEnumFirstCustomAttributeValue();
            var values2 = selectEnumValue.GetEnumAllCustomAttributesValues();
            Console.WriteLine($"GetEnumCustomAttributesValues : {string.Join(", ", values)} | GetEnumFirstCustomAttributeValue : {string.Join(", ", values2)} | GetEnumAllCustomAttributesValues : {string.Join(", ", values3)}");
        }

        private static void Test9(MailTypes enumValue, params Type[] attributeTypes)
        {
            var selectEnumValue = enumValue;

            var values = selectEnumValue.GetEnumCustomAttributesValues(attributeTypes);
            var values3 = selectEnumValue.GetEnumFirstCustomAttributeValue();
            var values2 = selectEnumValue.GetEnumAllCustomAttributesValues();
            Console.WriteLine($"GetEnumCustomAttributesValues : {string.Join(", ", values)} | GetEnumFirstCustomAttributeValue : {string.Join(", ", values2)} | GetEnumAllCustomAttributesValues : {string.Join(", ", values3)}");
        }

        private static void Test10(MailTypes enumValue, params Type[] attributeTypes)
        {
            var selectEnumValue = enumValue;

            var values = selectEnumValue.GetEnumCustomAttributesValues(attributeTypes);
            var values3 = selectEnumValue.GetEnumFirstCustomAttributeValue();
            var values2 = selectEnumValue.GetEnumAllCustomAttributesValues();
            Console.WriteLine($"GetEnumCustomAttributesValues : {string.Join(", ", values)} | GetEnumFirstCustomAttributeValue : {string.Join(", ", values2)} | GetEnumAllCustomAttributesValues : {string.Join(", ", values3)}");
        }

        private static void Test11(MailTypes enumValue, params Type[] attributeTypes)
        {
            var selectEnumValue = enumValue;

            var values = selectEnumValue.GetEnumCustomAttributesValues(attributeTypes);
            var values3 = selectEnumValue.GetEnumFirstCustomAttributeValue();
            var values2 = selectEnumValue.GetEnumAllCustomAttributesValues();
            Console.WriteLine($"GetEnumCustomAttributesValues : {string.Join(", ", values)} | GetEnumFirstCustomAttributeValue : {string.Join(", ", values2 ?? new string[] { })} | GetEnumAllCustomAttributesValues : {string.Join(", ", values3 ?? new string[] { })}");
        }

        // Delegate ile her fonksiyon çalıştığında bu tetiklensin
        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
            Thread.Sleep(500);
        }
    }
}
