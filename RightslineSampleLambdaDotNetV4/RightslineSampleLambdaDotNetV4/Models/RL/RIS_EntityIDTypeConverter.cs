using RightsLine.Contracts.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightsLine.Contracts.Converters
{
    public class RIS_EntityIDTypeConverter :TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                RIS_EntityID entityID = RIS_EntityID.Parse((string)value);
                if (entityID != RIS_EntityID.Empty || value.ToString() == RIS_EntityID.Empty.ToString())
                {
                    return entityID;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
