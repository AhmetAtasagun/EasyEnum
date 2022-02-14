namespace EasyEnum.Exceptions
{
    public class EnumCustomAttributeNotFoundException : Exception
    {
        public EnumCustomAttributeNotFoundException() : base() { }
        public EnumCustomAttributeNotFoundException(string message) : base(message) { }
        public EnumCustomAttributeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
