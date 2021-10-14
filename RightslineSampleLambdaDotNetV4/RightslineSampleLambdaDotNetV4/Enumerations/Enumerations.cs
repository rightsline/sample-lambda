﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace RightslineSampleLambdaDotNetV4
{
    public enum CharTypeID
    {
        [Description("catalog-item")]
        CatalogItem = 1,
        [Description("right")]
        Right = 3,
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
