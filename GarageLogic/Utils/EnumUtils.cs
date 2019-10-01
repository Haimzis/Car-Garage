using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Utils
{
    public class EnumUtils
    {
        public static T GetStringAsEnum<T>(string i_Input)
        {
            return (T)Enum.Parse(typeof(T), i_Input, true);
        }

        public static string GetEnumAsString(Enum i_Enum)
        {
            return i_Enum.ToString();
        }
    }
}
