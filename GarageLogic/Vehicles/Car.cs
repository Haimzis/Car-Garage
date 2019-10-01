using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Car : Vehicle
    {
        private readonly eCarColor r_CarColor;
        private readonly eNumberOfDoors r_NumberOfDoors;
        private const int k_NumberOfTires = 4;
        private const int k_MaximumNumberOfDoors = 5;
        private const int k_MinimumNumberOfDoors = 2;

        public static int GetNumberOfTires
        {
            get
            {
                return k_NumberOfTires;
            }
        }

        public static int MinimumNumberOfDoors
        {
            get
            {
                return k_MinimumNumberOfDoors;
            }
        }

        public static int MaximumNumberOfDoors
        {
            get
            {
                return k_MaximumNumberOfDoors;
            }
        }

        public Car(string i_LicenseNumber, Collection<Tire> i_TiresCollection, Engine i_VehicleEngine, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
            : base(i_LicenseNumber, i_TiresCollection, i_VehicleEngine)
        {
            r_CarColor = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;
        }

        public override string GetVehicleInformationAsString()
        {
            StringBuilder vehicleInformationStringBuilder = new StringBuilder();

            vehicleInformationStringBuilder.Append("Vehicle Type: Car").Append(Environment.NewLine);
            vehicleInformationStringBuilder.Append(base.GetVehicleInformationAsString());
            vehicleInformationStringBuilder.AppendFormat("Car Color: {0}{1}", CarColor, Environment.NewLine);
            vehicleInformationStringBuilder.AppendFormat("Number Of Doors: {0}{1}", NumberOfDoors, Environment.NewLine);

            return vehicleInformationStringBuilder.ToString();
        }

        public eCarColor CarColor
        {
            get
            {
                return r_CarColor;
            }
        }
        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }

        public enum eCarColor
        {
            Yellow,
            White,
            Red,
            Black,
        }
        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five,
        }
    }
}
