namespace EasyEnum.Exceptions
{
    public class EnumValueNotFoundException : Exception
    {
        public EnumValueNotFoundException() : base() { }
        public EnumValueNotFoundException(string message) : base(message) { }
        public EnumValueNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
