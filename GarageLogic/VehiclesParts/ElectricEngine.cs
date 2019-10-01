using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.CustomExceptions;

namespace Ex03.GarageLogic.VehiclesParts
{
    internal class ElectricEngine: Engine
    {
        public ElectricEngine(float RemainingBatteryTime, float MaximumBatteryLife)
            : base(RemainingBatteryTime, MaximumBatteryLife)
        {
        }

        public void RechargeBatteryForHours(float i_HoursOfCharge)
        {
            const float k_MinimumHoursOfCharge = 0;

            if (i_HoursOfCharge < k_MinimumHoursOfCharge || i_HoursOfCharge + RemainingEnergy > MaximumEnergyCapacity)
            {
                
                throw new ValueOutOfRangeException(k_MinimumHoursOfCharge, MaximumEnergyCapacity - RemainingEnergy);
            }

            RemainingEnergy += i_HoursOfCharge;
        }
        public override string GetEngineInformationAsString()
        {
            StringBuilder engineInformationStringBuilder = new StringBuilder();

            engineInformationStringBuilder.Append("Engine Type: Electric Engine").Append(Environment.NewLine);
            engineInformationStringBuilder.Append(base.GetEngineInformationAsString());

            return engineInformationStringBuilder.ToString();
        }

        public void RechargeBatteryForMinutes(float i_MinutesOfCharge)
        {
            float hoursOfCharge = i_MinutesOfCharge / 60;
            RechargeBatteryForHours(hoursOfCharge);
        }
    }
}
