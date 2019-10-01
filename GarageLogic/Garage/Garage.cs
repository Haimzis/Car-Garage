using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private readonly Dictionary<string,ClientVehicle> r_ClientVehiclesCollection;

        public Garage()
        {
            r_ClientVehiclesCollection = new Dictionary<string, ClientVehicle>();
        }

        public List<string> GetVehiclesLicenseNumbersCollection(params ClientVehicle.eClientVehicleStatus[] i_WantedClientVehicleStatus)
        {
            List<string> wantedVehiclesLicenseNumbersCollection = new List<string>();

            foreach(KeyValuePair<string, ClientVehicle> clientVehicle in r_ClientVehiclesCollection)
            {
                if(i_WantedClientVehicleStatus.Length == 0)
                {
                    wantedVehiclesLicenseNumbersCollection.Add(clientVehicle.Value.GetVehicleLicenseCode());
                }

                else
                {
                    foreach(ClientVehicle.eClientVehicleStatus clientVehicleStatus in i_WantedClientVehicleStatus)
                    {
                        if(clientVehicle.Value.ClientVehicleStatus == clientVehicleStatus)
                        {
                            wantedVehiclesLicenseNumbersCollection.Add(clientVehicle.Value.GetVehicleLicenseCode());
                            break;
                        }
                    }
                }
            }
            
            return wantedVehiclesLicenseNumbersCollection;
        }

        public string GetClientVehicleInformation(string i_LicenseNumber)
        {
           ClientVehicle clientVehicle = findClientVehicleInGarageByLicenseNumber(i_LicenseNumber);
           return clientVehicle.GetClientVehicleInformation();
        }
        public void ChangeClientVehicleStatus(string i_LicenseNumber, ClientVehicle.eClientVehicleStatus i_NewClientVehicleStatus)
        {
            ClientVehicle clientVehiclesToChange = findClientVehicleInGarageByLicenseNumber(i_LicenseNumber);
            clientVehiclesToChange.ClientVehicleStatus = i_NewClientVehicleStatus;
        }

        public void InflateTiresOfClientVehicleToMaximum(string i_LicenseNumber)
        {
            ClientVehicle clientVehicleToInflate = findClientVehicleInGarageByLicenseNumber(i_LicenseNumber);
            clientVehicleToInflate.InflateVehicleTiresToMaximum();
        }

        public bool AddVehicleToGarage(ClientVehicle i_NewClientVehicle)
        {
            bool isNewClientVehicleHasAdded = true;

            if (r_ClientVehiclesCollection.ContainsKey(i_NewClientVehicle.GetVehicleLicenseCode()) == false)
            {
                addClientVehicleToGarageCollection(i_NewClientVehicle);
            }
            else
            {
                ChangeClientVehicleStatus(i_NewClientVehicle.GetVehicleLicenseCode(), ClientVehicle.eClientVehicleStatus.InRepair);
                isNewClientVehicleHasAdded = false;
            }

            return isNewClientVehicleHasAdded;
        }

        public void RefuelClientVehicleByLicenseNumber(string i_LicenseNumber, FueledEngine.eFuelType i_WantedFuelType, float i_AmountOfFuel)
        {
            ClientVehicle clientVehiclesToRefuel = findClientVehicleInGarageByLicenseNumber(i_LicenseNumber);
            clientVehiclesToRefuel.RefuelVehicle(i_AmountOfFuel, i_WantedFuelType);
        }

        public void RechargeClientVehicleByLicenseNumber(string i_LicenseNumber, float i_AmountOfMinutes)
        {
            ClientVehicle clientVehiclesToCharge = findClientVehicleInGarageByLicenseNumber(i_LicenseNumber);
            clientVehiclesToCharge.RechargeVehicle(i_AmountOfMinutes);
        }

        public bool IsVehicleExistInTheGarage(string i_LicenseNumber)
        {
            bool isVehicleExist = true;

            try
            {
                findClientVehicleInGarageByLicenseNumber(i_LicenseNumber);
            }
            catch(ArgumentException)
            {
                isVehicleExist = false;
            }

            return isVehicleExist;
        }

        private ClientVehicle findClientVehicleInGarageByLicenseNumber(string i_LicenseNumber)
        {
            ClientVehicle WantedClientVehicle = r_ClientVehiclesCollection[i_LicenseNumber];

            if (WantedClientVehicle == null)
            {
                throw new ArgumentException(string.Format("License Number: {0}, don't exist in the garage.", i_LicenseNumber));
            }

            return WantedClientVehicle;
        }

        private void addClientVehicleToGarageCollection(ClientVehicle i_NewClientVehicle)
        {
            r_ClientVehiclesCollection.Add(i_NewClientVehicle.GetVehicleLicenseCode(), i_NewClientVehicle);
        }
    }
}
