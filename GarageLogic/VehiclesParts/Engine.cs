using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.CustomExceptions;

namespace Ex03.GarageLogic.VehiclesParts
{
    public abstract class Engine
    {
        public enum eEngineType
        {
            CombustionEngine,
            ElectricEngine
        }

        private const float k_MinimumEnergyCapacity = 0;
        private readonly float r_MaximumEnergyCapacity;
        private float m_RemainingEnergy;

        protected Engine(float i_RemainingEnergy, float i_MaximumEnergy)
        {
            if(i_MaximumEnergy < k_MinimumEnergyCapacity)
            {
                throw new ValueOutOfRangeException(k_MinimumEnergyCapacity, float.MaxValue);
            }

            if(RemainingEnergy < k_MinimumEnergyCapacity || i_RemainingEnergy > i_MaximumEnergy)
            {
                throw new ValueOutOfRangeException(k_MinimumEnergyCapacity, i_MaximumEnergy);
            }

            m_RemainingEnergy = i_RemainingEnergy;
            r_MaximumEnergyCapacity = i_MaximumEnergy;
        }

        public float CalculateRemainingEnergyPercentage()
        {
            return (m_RemainingEnergy / r_MaximumEnergyCapacity) * 100;
        }

        public virtual string GetEngineInformationAsString()
        {
            StringBuilder engineInformationStringBuilder = new StringBuilder();

            engineInformationStringBuilder.AppendFormat("Maximum Energy Capacity:{0}{1}", MaximumEnergyCapacity, Environment.NewLine);
            engineInformationStringBuilder.AppendFormat("Remaining Energy:{0}{1}", RemainingEnergy, Environment.NewLine);

            return engineInformationStringBuilder.ToString();
        }

        protected float MaximumEnergyCapacity
        {
            get
            {
                return r_MaximumEnergyCapacity;
            }
        }
        protected float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }
            set
            {
                m_RemainingEnergy = value;
            }
        }

        public float MinimumEnergyCapacity
        {
            get
            {
                return k_MinimumEnergyCapacity;
            }
        }

    }
}
