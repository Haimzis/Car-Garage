using System;
using System.Collections.ObjectModel;
using System.Text;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        private readonly float r_CargoVolume;
        private bool m_IsCarryingHazardousMaterials;
        private const int k_NumberOfTires = 16;

        public static int GetNumberOfTires
        {
            get
            {
                return k_NumberOfTires;
            }
        }

        public Truck(string i_LicenseNumber, Collection<Tire> i_TiresCollection, Engine i_VehicleEngine, float i_CargoVolume, bool i_IsCarryingHazardousMaterials)
            : base(i_LicenseNumber, i_TiresCollection, i_VehicleEngine)
        {
            r_CargoVolume = i_CargoVolume;
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
        }

        public override string GetVehicleInformationAsString()
        {
            StringBuilder vehicleInformationStringBuilder = new StringBuilder();

            vehicleInformationStringBuilder.Append("Vehicle Type: Truck").Append(Environment.NewLine);
            vehicleInformationStringBuilder.Append(base.GetVehicleInformationAsString());
            vehicleInformationStringBuilder.AppendFormat("Cargo Volume: {0}{1}", CargoVolume, Environment.NewLine);
            vehicleInformationStringBuilder.AppendFormat("Is Carrying Hazardous Materials: {0}{1}", IsCarryingHazardousMaterials, Environment.NewLine);

            return vehicleInformationStringBuilder.ToString();
        }

        public float CargoVolume
        {
            get
            {
                return r_CargoVolume;
            }
        }
        public bool IsCarryingHazardousMaterials
        {
            get
            {
                return m_IsCarryingHazardousMaterials;
            }
            set
            {
                m_IsCarryingHazardousMaterials = value;
            }
        }
    }
}
