using System;

namespace EasyEnum.NetFramework.Models
{
    public class EnumValueMember<TValue>
    {
        public string Name { get; set; }
        public Enum Member { get; set; }
        public TValue Value { get; set; }
    }
}
