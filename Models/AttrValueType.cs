namespace CMS.Models
{
    using System;
    
    public enum AttrValueType : int
    {
        Text = 0,
        ShortText = 10,
        LongText = 20,
        Html = 30,
        DateTime = 40,
        Number = 50,
        Boolean = 60
    }
}
