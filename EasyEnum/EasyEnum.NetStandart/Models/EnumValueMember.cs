using System;

namespace EasyEnum.NetStandart.Models
{
    public class EnumValueMember<TValue>
    {
        public string Name { get; set; }
        public Enum Member { get; set; }
        public TValue Value { get; set; }
    }
}
