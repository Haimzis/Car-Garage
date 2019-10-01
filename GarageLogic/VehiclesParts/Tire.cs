using System;
using System.Text;
using Ex03.GarageLogic.CustomExceptions;

namespace Ex03.GarageLogic.VehiclesParts
{
    public class Tire
    {
        private const float k_EmptyTireAirPressure = 0;
        private readonly string r_ManufacturerName;
        private readonly float r_MaximumAirPressure;
        private float m_CurrentAirPressure;

        public Tire(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            if(i_MaximumAirPressure < k_EmptyTireAirPressure)
            {
                throw new ValueOutOfRangeException(k_EmptyTireAirPressure, float.MaxValue);
            }

            if(i_CurrentAirPressure < k_EmptyTireAirPressure || i_CurrentAirPressure > i_MaximumAirPressure)
            {
                throw new ValueOutOfRangeException(k_EmptyTireAirPressure, i_MaximumAirPressure);
            }

            m_CurrentAirPressure = i_CurrentAirPressure;
            r_ManufacturerName = i_ManufacturerName;
            r_MaximumAirPressure = i_MaximumAirPressure;
        }

        public void InflateTire(float i_AirPressureAddition)
        {
            if(m_CurrentAirPressure + i_AirPressureAddition > r_MaximumAirPressure)
            {
                throw new ValueOutOfRangeException(k_EmptyTireAirPressure, r_MaximumAirPressure - m_CurrentAirPressure);
            }

            m_CurrentAirPressure += i_AirPressureAddition;
        }

        public void InflateTireToMaximum()
        {
            m_CurrentAirPressure = r_MaximumAirPressure;
        }

        public string GetTireInformationAsString()
        {
            StringBuilder tireInformationStringBuilder = new StringBuilder();

            tireInformationStringBuilder.AppendFormat("Manufacturer Name: {0}{1}", ManufacturerName, Environment.NewLine);
            tireInformationStringBuilder.AppendFormat("Maximum Air Pressure: {0}{1}", MaximumAirPressure, Environment.NewLine);
            tireInformationStringBuilder.AppendFormat("Current Air Pressure: {0}{1}", CurrentAirPressure, Environment.NewLine);

            return tireInformationStringBuilder.ToString();
        }
        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }
        public float MaximumAirPressure
        {
            get
            {
                return r_MaximumAirPressure;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
    }
}
