# EasyEnum

Make things easy with enum extensions
&nbsp;<br>
&nbsp;<br>
&nbsp;<br>
&nbsp;<br>
&nbsp;<br>

---
### **Add to Project**
---

Nuget Package Manager > Search : "EasyEnum"<br>
Select EasyEnum library and install right side
&nbsp;<br>
&nbsp;<br>
Note : Not Avaible, Incoming...
&nbsp;<br>
&nbsp;<br>
- Test Objects
```csharp
public class DescriptionTextAttribute : Attribute
{ public string Text { get; set; } }

public class SortIndexAttribute : Attribute
{ public int Index { get; set; } }

public class AuthorizeAttribute : Attribute
{ public bool Auth { get; set; } }

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
    [DescriptionText(Text = "Spamlar")]
    Spam
}
```

&nbsp;<br>
&nbsp;<br>
&nbsp;<br>

---
### **Extensions**
---

- `int GetEnumIndex<TEnum>(this TEnum @enum)`
```csharp
var myEnum = MailTypes.Unread;
var index = myEnum.GetEnumIndex();
Console.Write(index); // 2
```
- `object GetEnumValue<TEnum>(this TEnum @enum)`
```csharp
var myEnum = MailTypes.Unread;
var index = myEnum.GetEnumValue();
Console.Write(index); // 2 (object)
```
- `string GetEnumName<TEnum>(this TEnum @enum)`
```csharp
var myEnum = MailTypes.Unread;
var name = myEnum.GetEnumName();
Console.Write(name); // "Unread"
```
- `object GetEnumFirstCustomAttributeValue<TEnum>(this TEnum @enum)`
```csharp
var myEnum = MailTypes.Unread;
var value = myEnum.GetEnumFirstCustomAttributeValue();
// value => "Okunmayanlar" (DescriptionText)
```
- `object GetEnumCustomAttributeValue<TEnum>(this TEnum @enum, Type customAttributeType)`
```csharp
var myEnum = MailTypes.Unread;
var value = myEnum.GetEnumCustomAttributeValue(typeof(SortIndex));
// value => 1
var value = myEnum.GetEnumCustomAttributeValue(typeof(DescriptionText));
// value => "Okunmayanlar"
var value = myEnum.GetEnumCustomAttributeValue(typeof(Authorize));
// value => Object.Empty
```
- `object[] GetEnumCustomAttributesValues<TEnum>(this TEnum @enum, params Type[] customAttributesTypes)`
```csharp
var myEnum = MailTypes.Unread;
var value = myEnum.GetEnumCustomAttributesValues(typeof(SortIndex), typeof(DescriptionText));
// value => [ 1, "Okunmayanlar" ]
```
- `object[] GetEnumAllCustomAttributesValues<TEnum>(this TEnum @enum)`
```csharp
var myEnum = MailTypes.Unread;
var value = myEnum.GetEnumAllCustomAttributesValues();
// value => [ 1, "Okunmayanlar", Object.Empty ]
```
&nbsp;<br>
&nbsp;<br>

---
### **Functions**
---

- `TEnum ParseOfEnumByMemberType<TEnum>(Type typeOfEnumMemberName)`
```csharp
var value = Functions.ParseOfEnumByMemberType<MailTypes>(typeof(MailTypes.Unread))
// value => Unread (enum)
```
- `TEnum ParseOfEnumByMemberName<TEnum>(string enumMemberName)`
```csharp
var value = Functions.ParseOfEnumByMemberName<MailTypes>("Unread")
// value => Unread (enum)
```
- `object ParseOfEnumByMemberName(Type enumType, string enumMemberName)`
```csharp
var value = Functions.ParseOfEnumByMemberName(typeof(MailTypes), "Unread");
// value => Unread (enum-object)
```
- `List<EnumValueMember<TValue>> GetEnumMemberNamesAndValues<TEnum, TValue>()`
```csharp
var value = Functions.GetEnumMemberNamesAndValues<MailTypes, int>();
/*
value => [ 
    EnumValueMember { Name : "Inbox", Member : Inbox (enum), Value : 0 }, 
    EnumValueMember { Name : "Outbox", Member : Outbox (enum), Value : 1  }, 
    EnumValueMember { Name : "Unread", Member : Unread (enum), Value : 2 }, 
    EnumValueMember { Name : "Spam", Member : Spam (enum), Value : 3 }
]
*/
var value = Functions.GetEnumMemberNamesAndValues<MailTypes, string>();
/*
value => [ 
    EnumValueMember { Name : "Inbox", Member : Inbox (enum), Value : "0" }, 
    EnumValueMember { Name : "Outbox", Member : Outbox (enum), Value : "1"  }, 
    EnumValueMember { Name : "Unread", Member : Unread (enum), Value : "2" }, 
    EnumValueMember { Name : "Spam", Member : Spam (enum), Value : "3" }
]
*/
```
- `List<EnumMember> GetEnumMemberNamesAndIntValues<TEnum>()`
```csharp
var value = Functions.GetEnumMemberNamesAndIntValues<MailTypes>();
/*
value => [ 
    EnumMember { Name : "Inbox", Member : Inbox (enum), Value : 0 }, 
    EnumMember { Name : "Outbox", Member : Outbox (enum), Value : 1  },
    EnumMember { Name : "Unread", Member : Unread (enum), Value : 2 }, 
    EnumMember { Name : "Spam", Member : Spam (enum), Value : 3 }
]
*/
```
&nbsp;<br>
&nbsp;<br>

---
### **HtmlHelpers** (under development)
---

- `List<EnumMember> ForSelect<TEnum>()`
```html
<select class="form-control">
    @foreach (var item in HtmlHelpers.ForSelect<MailTypes>()
    {
        <option value="@item.Value">@item.Name</option>
    }
</select>)
<!--
    <select class="form-control">
        <option value="0">Inbox</option>
        <option value="1">Outbox</option>
        <option value="2">Unread</option>
        <option value="3">Spam</option>
    </select>
-->
```
```html
<select class="form-control" asp-items="HtmlHelpers.ForSelect<Units>().Select(s => new SelectListItem(s.Name, s.Value.ToString()))"></select>
<!--
    <select class="form-control">
        <option value="0">Inbox</option>
        <option value="1">Outbox</option>
        <option value="2">Unread</option>
        <option value="3">Spam</option>
    </select>
-->
```
- `List<EnumMemberCustomValue<TValue>> ForSelectCustomValues<TEnum, TValue>(Type customAttributeType)`
```html
<select class="form-control">
    @foreach (var item in HtmlHelpers.ForSelectCustomValues<MailTypes, string>(typeof(DescriptionTextAttribute))
    {
        <option value="@item.Value" data-name="@item.Name">@item.CustomValue</option>
    }
</select>)
<!--
    <select class="form-control">
        <option value="0" data-name="Inbox">Gelen Kutusu</option>
        <option value="1" data-name="Outbox">Giden Kutusu</option>
        <option value="2" data-name="Unread">Okunmayanlar</option>
        <option value="3" data-name="Spam">Spamlar</option>
    </select>
-->
```
```html
<select class="form-control" asp-items="HtmlHelpers.ForSelectCustomValues<MailTypes, string>(typeof(DescriptionTextAttribute)).Select(s => new SelectListItem(s.CustomValue, s.Value.ToString()))"></select>
<!--
    <select class="form-control">
        <option value="0">Gelen Kutusu</option>
        <option value="1">Giden Kutusu</option>
        <option value="2">Okunmayanlar</option>
        <option value="3">Spamlar</option>
    </select>
-->
```