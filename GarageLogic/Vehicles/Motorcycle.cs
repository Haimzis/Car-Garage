using System;
using System.Collections.ObjectModel;
using System.Text;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;
        private const int k_NumberOfTires = 2;

        public static int GetNumberOfTires
        {
            get
            {
                return k_NumberOfTires;
            }
        }

        public Motorcycle(string i_LicenseNumber, Collection<Tire> i_TiresCollection, Engine i_VehicleEngine, eLicenseType i_LicenseType, int i_EngineCapacity)
            : base(i_LicenseNumber, i_TiresCollection, i_VehicleEngine)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public override string GetVehicleInformationAsString()
        {
            StringBuilder vehicleInformationStringBuilder = new StringBuilder();

            vehicleInformationStringBuilder.Append("Vehicle Type: Motorcycle").Append(Environment.NewLine);
            vehicleInformationStringBuilder.Append(base.GetVehicleInformationAsString());
            vehicleInformationStringBuilder.AppendFormat("License Type: {0}{1}", LicenseType, Environment.NewLine);
            vehicleInformationStringBuilder.AppendFormat("Engine Capacity: {0}{1}", EngineCapacity, Environment.NewLine);

            return vehicleInformationStringBuilder.ToString();
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }
        public int EngineCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }

        public enum eLicenseType
        {
            A,
            A1,
            AB,
            B1
        }
    }
}
