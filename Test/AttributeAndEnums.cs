using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DescriptionTextAttribute : Attribute { public string Text { get; set; } }

    public class SortIndexAttribute : Attribute { public int Index { get; set; } }

    public class AuthorizeAttribute : Attribute { public bool Auth { get; set; } }

    public enum MailTypes
    {
        [DescriptionText(Text = "Gelen Kutusu")]
        [Authorize(Auth = true)]
        Inbox,

        [DescriptionText(Text = "Giden Kutusu")]
        Outbox,

        [DescriptionText(Text = "Okunmayanlar")]
        [SortIndex(Index = 1)]
        Unread,

        Spam
    }
}
