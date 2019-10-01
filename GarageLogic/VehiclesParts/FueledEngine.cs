using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.CustomExceptions;

namespace Ex03.GarageLogic.VehiclesParts
{
    public class FueledEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FueledEngine(float i_RemainingFuel, float i_FuelTankCapacity, eFuelType i_FuelType)
            : base(i_RemainingFuel, i_FuelTankCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public void AddFuel(float i_FuelAmountToFill ,eFuelType i_FuelType)
        {
            const float k_MinimumFuelTankCapacity = 0;

            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException($"{i_FuelType} is not suitable for engine based on {r_FuelType} fuel");
            }

            if(i_FuelAmountToFill < k_MinimumFuelTankCapacity || RemainingEnergy + i_FuelAmountToFill > MaximumEnergyCapacity)
            {
                throw new ValueOutOfRangeException(k_MinimumFuelTankCapacity, MaximumEnergyCapacity - RemainingEnergy);
            }

            RemainingEnergy += i_FuelAmountToFill;
        }

        public override string GetEngineInformationAsString()
        {
            StringBuilder engineInformationStringBuilder = new StringBuilder();

            engineInformationStringBuilder.Append("Engine Type: Based on Fuel").Append(Environment.NewLine);
            engineInformationStringBuilder.Append(base.GetEngineInformationAsString());
            engineInformationStringBuilder.AppendFormat("Fuel Type: {0}{1}", FuelType, Environment.NewLine);
            
            return engineInformationStringBuilder.ToString();
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }
    }
}
