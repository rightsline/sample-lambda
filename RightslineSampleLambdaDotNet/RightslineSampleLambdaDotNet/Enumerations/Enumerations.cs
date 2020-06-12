using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace RightslineSampleLambdaDotNet
{
    public enum CharTypeID
    {
        [Description("relationship")]
        Relationship,
        [Description("catalog-item")]
        CatalogItem,
        [Description("contact")]
        Contact,
        [Description("rightset")]
        Rightset,
        [Description("deal")]
        Deal,
        [Description("table-row")]
        Table,
        Company,
        [Description("financial-document")]
        Invoice,
        Report,
        Parameter,
        [Description("amount")]
        Amount,
        Period,
        Date,
        Royalty,
        [Description("file")]
        Document,
        Generic,
        [Description("job")]
        Job,
        [Description("project")]
        Project,
        [Description("inventory")]
        Inventory
    }

    public static class Enumerations
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
