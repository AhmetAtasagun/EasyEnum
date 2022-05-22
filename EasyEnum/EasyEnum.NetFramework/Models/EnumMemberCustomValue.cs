using System;

namespace EasyEnum.NetFramework.Models
{
    public class EnumMemberCustomValue<TValue>
    {
        public string Name { get; set; }
        public Enum Member { get; set; }
        public int Value { get; set; }
        public TValue CustomValue { get; set; }
    }
}
