using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.Garage
{
    public class ClientVehicle
    {
        private readonly Client r_VehicleOwner;
        private readonly Vehicle r_VehicleOfClient;
        private eClientVehicleStatus m_ClientVehicleStatus;

        public ClientVehicle(Client i_VehicleOwner, Vehicle i_VehicleOfClient, eClientVehicleStatus i_ClientVehicleStatus)
        {
            r_VehicleOwner = i_VehicleOwner;
            r_VehicleOfClient = i_VehicleOfClient;
            m_ClientVehicleStatus = i_ClientVehicleStatus;
        }

        public void RefuelVehicle(float i_AmountOfFuel, FueledEngine.eFuelType i_WantedFuelType)
        {
            FueledEngine clientVehicleEngine = r_VehicleOfClient.VehicleEngine as FueledEngine;

            if(clientVehicleEngine == null)
            {
                throw new ArgumentException("Client vehicle engine can't be filled with fuel");
            }
            
            clientVehicleEngine.AddFuel(i_AmountOfFuel, i_WantedFuelType);
        }

        public void RechargeVehicle(float i_AmountOfMinutesToCharge)
        {
            ElectricEngine clientVehicleEngine = r_VehicleOfClient.VehicleEngine as ElectricEngine;

            if (clientVehicleEngine == null)
            {
                throw new ArgumentException("Client vehicle engine can't be charged");
            }

            clientVehicleEngine.RechargeBatteryForMinutes(i_AmountOfMinutesToCharge);
        }

        public string GetVehicleLicenseCode()
        {
            return r_VehicleOfClient.LicenseNumber;
        }

        public void InflateVehicleTiresToMaximum()
        {
            VehicleOfClient.InflateVehicleTiresToMaximum();
        }

        public enum eClientVehicleStatus
        {
            InRepair = 1,
            Repaired,
            Paid,
        }

        public Vehicle VehicleOfClient
        {
            get
            {
                return r_VehicleOfClient;
            }
        }
        public eClientVehicleStatus ClientVehicleStatus
        {
            get
            {
                return m_ClientVehicleStatus;
            }
            set
            {
                m_ClientVehicleStatus = value;
            }
        }
        public Client VehicleOwner
        {
            get
            {
                return r_VehicleOwner;
            }
        }

        public string GetClientVehicleInformation()
        {
            return VehicleOfClient.GetVehicleInformationAsString();
        }
    }
}
