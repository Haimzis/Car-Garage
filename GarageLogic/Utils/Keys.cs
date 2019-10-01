using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.GarageUtils
{
    public class Keys
    {
        private const string k_LicenseNumber = "LicenseNumber";
        private const string k_Color = "Color";
        private const string k_NumberOfDoors = "NumberOfDoors";
        private const string k_RemainingFuel = "RemainingFuel";
        private const string k_RemainingCharge = "RemainingCharge";
        private const string k_TireAirPressure = "Tire{0}AirPressure";
        private const string k_TireManufacturer = "Tire{0}Manufacturer";
        private const string k_HazardousCargo = "HazardousCargo";
        private const string k_CargoVolume = "CargoVolume";
        private const string k_LicenseType = "LicenseType";
        private const string k_EngineVolume = "EngineVolume";

        public static string LicenseNumber
        {
            get
            {
                return k_LicenseNumber;
            }
        }

        public static string Color
        {
            get
            {
                return k_Color;
            }
        }

        public static string NumberOfDoors
        {
            get
            {
                return k_NumberOfDoors;
            }
        }

        public static string RemainingFuel
        {
            get
            {
                return k_RemainingFuel;
            }
        }

        public static string RemainingCharge
        {
            get
            {
                return k_RemainingCharge;
            }
        }

        public static string TireAirPressure
        {
            get
            {
                return k_TireAirPressure;
            }
        }

        public static string TireManufacturer
        {
            get
            {
                return k_TireManufacturer;
            }
        }

        public static string HazardousCargo
        {
            get
            {
                return k_HazardousCargo;
            }
        }

        public static string CargoVolume
        {
            get
            {
                return k_CargoVolume;
            }
        }
        public static string LicenseType
        {
            get => k_LicenseType;
        }
        public static string EngineVolume
        {
            get => k_EngineVolume;
        }
    }
}
