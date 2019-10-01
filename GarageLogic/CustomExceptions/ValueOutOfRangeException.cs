using System;

namespace Ex03.GarageLogic.CustomExceptions
{
    internal class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue, r_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) 
            : base(string.Format("Value is out of range: bounds are [{0} - {1}]:", i_MinValue,i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }
    }
}
