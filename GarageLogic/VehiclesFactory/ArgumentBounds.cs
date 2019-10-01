using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehiclesFactory
{
    public class ArgumentBounds
    {
        private Nullable<int> m_MinValue = null;
        private Nullable<int> m_MaxValue = null;
        private Nullable<float> m_MaxValueFloat = null;

        public ArgumentBounds(int? i_MinValue, int? i_MaxValue, float? i_MaxValueFloat)
        {
            if(i_MinValue != null)
            {
                m_MinValue  = i_MinValue;
            }

            if(i_MaxValue != null)
            {
                m_MaxValue = i_MaxValue;
            }

            if(i_MaxValueFloat != null)
            {
                m_MaxValueFloat = i_MaxValueFloat;
            }
        }


        public int? MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
            }
        }
        public int? MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
            }
        }

        public float? MaxValueFloat
        {
            get
            {
                return m_MaxValueFloat;
            }
        }
    }
}
