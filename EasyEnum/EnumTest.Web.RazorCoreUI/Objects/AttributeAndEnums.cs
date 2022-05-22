using System;
using static EnumTest.Web.RazorCoreUI.Objects.AttributeAndEnums;

namespace EnumTest.Web.RazorCoreUI.Objects
{
    public class AttributeAndEnums
    {
        public class ViewTextAttribute : Attribute
        {
            public string Text { get; set; }
        }
    }

    public enum Units
    {
        [ViewText(Text = "Parça")]
        Piece,
        [ViewText(Text = "Palet")]
        Pallet,
        [ViewText(Text = "Kutu")]
        Box
    }
}

