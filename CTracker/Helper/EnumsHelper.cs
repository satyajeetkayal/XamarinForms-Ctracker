using System;
using System.Collections.Generic;
using System.Text;

namespace CTracker.Helper
{
   public static class EnumsHelper
    {
        public static string ConvertToString(this Enum eff)
        {
            return Enum.GetName(eff.GetType(), eff);
        }

        public static EnumType ConvertToEnum<EnumType>(this string enumValue)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), enumValue);
        }

    }
}
