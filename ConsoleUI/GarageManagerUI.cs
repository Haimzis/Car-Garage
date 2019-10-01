using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.VehiclesFactory;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.ConsoleUI
{
    class GarageManagerUI
    {
        private bool m_IsManagerStillInTheGarage = true;
        private readonly Garage r_Garage =  new Garage();

        private enum eMessageToPrint
        {
            MenuHeadline,
            InvalidMenuKey,
            InvalidFuelType,
            InvalidFuelAmount,
            InvalidTimeOfCharge,
            InvalidLicenseNumber,
            InvalidName,
            InvalidPhoneNumber,
            InvalidYesOrNo,
            VehicleInformationHeadline,
            InvalidClientVehicleStatus,
            EnterLicenseNumber,
            EnterPhoneNumber,
            EnterName,
            EnterMenuKey,
            EnterFuelType,
            EnterTimeOfCharge,
            EnterAmountOfFuel,
            EnterNewVehicleStatus,
            EnterFilterStatus,
            CarHasEnteredTheGarage,
            CarIsAlreadyInTheGarage,
        }

        private enum eMenuKeyOption
        {
            AddVehicleToGarage = 1,
            ShowLicenseNumbersOfClientVehicles,
            ChangeClientVehicleStatus,
            InflateVehicleTiresToMaximum,
            RefuelVehicle,
            RechargeVehicle,
            ShowClientVehicleInformation,
            ExitMenu,
        }

        public void StartManageGarage()
        {
            while(m_IsManagerStillInTheGarage == true)
            {
                printMessageToConsole(eMessageToPrint.MenuHeadline);
                showMenu();
                eMenuKeyOption menuKeyOption = getKeyMenuInput();
                navigateToAction(menuKeyOption);
            }
        }

        private eMenuKeyOption getKeyMenuInput()
        {
            int optionAsInt = 0;
            bool isInputValid = false;
            int howManyMenuOptions = Enum.GetNames(typeof(eMenuKeyOption)).Length;
            while(isInputValid == false)
            {
                string optionSelectedAsString = Console.ReadLine();
                isInputValid = checkMenuOptionSelectedThenPrintCheckAndReturnAsInteger(
                        optionSelectedAsString,
                        howManyMenuOptions,
                        out optionAsInt);
            }

            eMenuKeyOption optionSelected = 0;
            foreach(eMenuKeyOption menuOption in Enum.GetValues(typeof(eMenuKeyOption)))
            {
                if((int)menuOption == optionAsInt)
                {
                    optionSelected = menuOption;
                }
            }

            return optionSelected;
        }

        private bool checkMenuOptionSelectedThenPrintCheckAndReturnAsInteger(string i_OptionSelectedAsString, int i_MaximumBounds, out int o_OptionAsInt)
        {
            bool result;
            bool parsingResult = int.TryParse(i_OptionSelectedAsString, out o_OptionAsInt);

            if(parsingResult == true && o_OptionAsInt <= i_MaximumBounds && o_OptionAsInt >= 0)
            {
                result = true;
            }
            else
            {
                result = false;
                printMessageToConsole(eMessageToPrint.InvalidMenuKey);
            }

            return result;
        }

        private string getLicenseNumberInput()
        {
            printMessageToConsole(eMessageToPrint.EnterLicenseNumber);
            string licenseNumber = Console.ReadLine();
            bool isValid = false;
            while(isValid == false)
            {
                isValid = checkIfStringIsOnlyDigits(licenseNumber);
                if(isValid == false)
                {
                    printMessageToConsole(eMessageToPrint.InvalidLicenseNumber);
                }
            }

            return licenseNumber;
        }

        private FueledEngine.eFuelType getFuelTypeInput()
        {
            int optionAsInt = 0;
            bool isInputValid = false;
            int howManyMenuOptions = Enum.GetNames(typeof(FueledEngine.eFuelType)).Length;
            while (isInputValid == false)
            {
                string optionSelectedAsString = Console.ReadLine();
                isInputValid = checkMenuOptionSelectedThenPrintCheckAndReturnAsInteger(
                    optionSelectedAsString,
                    howManyMenuOptions,
                    out optionAsInt);
            }

            FueledEngine.eFuelType optionSelected = 0;
            foreach (FueledEngine.eFuelType menuOption in Enum.GetValues(typeof(FueledEngine.eFuelType)))
            {
                if ((int)menuOption == optionAsInt)
                {
                    optionSelected = menuOption;
                }
            }

            return optionSelected;
        }

        private float getFuelAmountInput()
        {
            return getEnergyAmount(eMessageToPrint.EnterAmountOfFuel, eMessageToPrint.InvalidFuelAmount);
        }

        private float getTimeOfChargeInMinutesInput()
        {
            return getEnergyAmount(eMessageToPrint.EnterTimeOfCharge, eMessageToPrint.InvalidTimeOfCharge);
        }

        private float getEnergyAmount(eMessageToPrint i_InformationMessage, eMessageToPrint i_ErrorMessage)
        {
            printMessageToConsole(i_InformationMessage);
            string energyAsString = Console.ReadLine();
            bool isParsed = float.TryParse(energyAsString, out float energy);
            while (isParsed == false)
            {
                printMessageToConsole(i_ErrorMessage);
                energyAsString = Console.ReadLine();
                isParsed = float.TryParse(energyAsString, out energy);
            }

            return energy;
        }

        private void showMenu()
        {
            foreach(eMenuKeyOption keyMenuOption in Enum.GetValues(typeof(eMenuKeyOption)))
            {
                printMenuOptionToConsole(keyMenuOption);
            }
        }

        private void navigateToAction(eMenuKeyOption i_MenuKeyOption)
        {
            switch (i_MenuKeyOption)
            {
                case eMenuKeyOption.AddVehicleToGarage:
                    addVehicleToGarage(); //TODO: BIG PROBLEM!
                    break;
                case eMenuKeyOption.ShowLicenseNumbersOfClientVehicles:
                    showLicenseNumbersOfClientVehicles();
                    break;
                case eMenuKeyOption.ChangeClientVehicleStatus:
                    changeClientVehicleStatus();
                    break;
                case eMenuKeyOption.InflateVehicleTiresToMaximum:
                    inflateVehicleTiresToMaximum();
                    break;
                case eMenuKeyOption.RefuelVehicle:
                    refuelVehicle();
                    break;
                case eMenuKeyOption.RechargeVehicle:
                    rechargeVehicle();
                    break;
                case eMenuKeyOption.ShowClientVehicleInformation:
                    showClientVehicleInformation();
                    break;
                case eMenuKeyOption.ExitMenu:
                    exitMenu();
                    break;
            }
        }

        private void showLicenseNumbersOfClientVehicles()
        {
            List<string> arrayOfLicenseNumbers;
            Console.WriteLine("Do you wish to filter by status? Enter Y/N");
            string response = string.Empty;
            bool responseValid = false;
            while(responseValid == false)
            {
                response = Console.ReadLine();
                if(response != null)
                {
                    responseValid = response.Equals("Y") || response.Equals("N");
                }

                if(responseValid == false)
                {
                    printMessageToConsole(eMessageToPrint.InvalidYesOrNo);
                }
            }
            StringBuilder licenseBuilder = new StringBuilder();
            if(response.Equals("Y"))
            {
                ClientVehicle.eClientVehicleStatus filter = getStatusFromMenu();
                arrayOfLicenseNumbers = r_Garage.GetVehiclesLicenseNumbersCollection(filter);
            }
            else
            {
                arrayOfLicenseNumbers = r_Garage.GetVehiclesLicenseNumbersCollection();
            }

            foreach(string licenseNumber in arrayOfLicenseNumbers)
            {
                licenseBuilder.AppendLine(licenseNumber);
            }

            Console.WriteLine(licenseBuilder.ToString());
        }

        private ClientVehicle.eClientVehicleStatus getStatusFromMenu()
        {
            showStatuses();
            int optionAsInt = 0;
            bool isInputValid = false;
            while (isInputValid == false)
            {
                string statusAsString = Console.ReadLine();
                isInputValid = checkMenuOptionSelectedThenPrintCheckAndReturnAsInteger(statusAsString, Enum.GetValues(typeof(ClientVehicle.eClientVehicleStatus)).Length, out optionAsInt);
            }

            ClientVehicle.eClientVehicleStatus statusSelected = 0;
            foreach (ClientVehicle.eClientVehicleStatus menuOption in Enum.GetValues(typeof(ClientVehicle.eClientVehicleStatus)))
            {
                if ((int)menuOption == optionAsInt)
                {
                    statusSelected = menuOption;
                }
            }

            return statusSelected;
        }

        private void showStatuses()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Choose one of the following: ");
            foreach (ClientVehicle.eClientVehicleStatus status in Enum.GetValues(typeof(ClientVehicle.eClientVehicleStatus)))
            {
                builder.AppendFormat("{0}.{1}{2}", (int)status, status, Environment.NewLine);
            }

            Console.WriteLine(builder.ToString());
        }

        private void addVehicleToGarage()
        {
            showAvailableVehicles();
            VehiclesFactory.eVehicleType vehicleType = selectVehicleType();
            Client client = getClientInformation();
            ArgumentConsumersContainer vehicleArgumentsContainer = VehiclesFactory.GetVehicleArguments(vehicleType);
            fillVehicleArguments(vehicleArgumentsContainer, vehicleType);
            Vehicle vehicleToAdd = VehiclesFactory.GetVehicle(vehicleType, vehicleArgumentsContainer);
            ClientVehicle clientVehicle = new ClientVehicle(client, vehicleToAdd, ClientVehicle.eClientVehicleStatus.InRepair);
            bool didCarEnterTheGarage = r_Garage.AddVehicleToGarage(clientVehicle);
            printMessageToConsole(
                didCarEnterTheGarage == true
                    ? eMessageToPrint.CarHasEnteredTheGarage
                    : eMessageToPrint.CarIsAlreadyInTheGarage);
        }

        private void fillVehicleArguments(ArgumentConsumersContainer i_VehicleArgumentsContainer, VehiclesFactory.eVehicleType i_VehicleType)
        {
            Console.WriteLine("We are going to add {0} to garage, please enter the following information: ", i_VehicleType);

            foreach (KeyValuePair<string, ArgumentConsumer> argument in i_VehicleArgumentsContainer.GetConsumers)
            {
                StringBuilder menuBuilder = new StringBuilder();
                menuBuilder.AppendFormat("{0}{1}", argument.Value.GetMessage, Environment.NewLine);
                if (argument.Value.GetBounds != null)
                {
                    menuBuilder.AppendLine("Bounds are:");
                    int? minValueNullable = argument.Value.GetBounds.MinValue;
                    int? maxValueIntNullable = argument.Value.GetBounds.MaxValue;
                    float? maxValueFloatNullable = argument.Value.GetBounds.MaxValueFloat;
                    string maxValue = string.Empty;
                    if (minValueNullable != null)
                    {
                        string minValue = minValueNullable.ToString();
                        menuBuilder.AppendFormat("Minimum value: {0}, ", minValue);
                    }

                    if(maxValueFloatNullable != null)
                    {
                        maxValue = maxValueFloatNullable.ToString();
                    }

                    if(maxValueIntNullable != null)
                    {
                        maxValue = maxValueIntNullable.ToString();
                    }

                    menuBuilder.AppendFormat("Maximum value: {0}{1}", maxValue,Environment.NewLine);
                }

                if (argument.Value.GetOptionalValues.Length != 0)
                {
                    menuBuilder.AppendLine("Available values are:");
                    foreach (string optionalValue in argument.Value.GetOptionalValues)
                    {
                        menuBuilder.AppendLine(optionalValue);
                    }
                }
                Console.WriteLine(menuBuilder.ToString());
                string userInput = Console.ReadLine();
                //TryParseArgument(userInput, argument); //give each argument and user input and try to parse - success = put the new type after parse in argument.ValueOfUser/ fails = FormatException
            }
        }


        private Client getClientInformation()
        {
            string name = getAndValidateName();
            int phoneNumber = getAndValidatePhoneNumber();
            Client client = new Client(name, phoneNumber);
            return client;
        }

        private int getAndValidatePhoneNumber()
        {
            bool isInputValid = false;
            int phoneNumberAsInt = 0;
            while(isInputValid == false)
            {
                printMessageToConsole(eMessageToPrint.EnterPhoneNumber);
                string phoneNumberAsString = Console.ReadLine();
                bool parsingResult = int.TryParse(phoneNumberAsString, out phoneNumberAsInt);
                if(phoneNumberAsInt < 0)
                {
                    printMessageToConsole(eMessageToPrint.InvalidPhoneNumber);
                }
                else
                {
                    isInputValid = true;
                }
            }

            return phoneNumberAsInt;
        }

        private string getAndValidateName()
        {
            string name = string.Empty;
            bool isInputValid = false;
            while(isInputValid == false)
            {
                printMessageToConsole(eMessageToPrint.EnterName);
                name = Console.ReadLine();
                isInputValid = checkIfStringIsOnlyLetters(name);
                if(isInputValid == false)
                {
                    printMessageToConsole(eMessageToPrint.InvalidName);
                }
            }

            return name;
        }

        private bool checkIfStringIsOnlyLetters(string i_Input)
        {
            bool result = true;
            foreach(char letter in i_Input)
            {
                if(char.IsDigit(letter) == true)
                {
                    result = false;
                }
            }

            return result;
        }

        private bool checkIfStringIsOnlyDigits(string i_Input)
        {
            bool result = true;
            foreach (char digit in i_Input)
            {
                if (char.IsLetter(digit) == true)
                {
                    result = false;
                }
            }

            return result;
        }

        private VehiclesFactory.eVehicleType selectVehicleType()
        {
            int optionAsInt = 0;
            bool isInputValid = false;
            while (isInputValid == false)
            {
                string vehicleSelectedAsString = Console.ReadLine();
                isInputValid = checkMenuOptionSelectedThenPrintCheckAndReturnAsInteger(vehicleSelectedAsString, Enum.GetValues(typeof(VehiclesFactory.eVehicleType)).Length, out optionAsInt);
            }

            VehiclesFactory.eVehicleType vehicleSelected = 0;
            foreach (VehiclesFactory.eVehicleType menuOption in Enum.GetValues(typeof(VehiclesFactory.eVehicleType)))
            {
                if ((int)menuOption == optionAsInt)
                {
                    vehicleSelected = menuOption;
                }
            }

            return vehicleSelected;
        }

        private void showAvailableVehicles()
        {
            StringBuilder vehiclesStringBuilder = new StringBuilder();
            vehiclesStringBuilder.AppendLine("Choose one of the following: ");
            foreach(VehiclesFactory.eVehicleType vehicleType in Enum.GetValues(typeof(VehiclesFactory.eVehicleType)))
            {
                vehiclesStringBuilder.AppendFormat("{0}.{1}{2}", (int)vehicleType, vehicleType, Environment.NewLine);
            }

            Console.WriteLine(vehiclesStringBuilder.ToString());
        }

        private void changeClientVehicleStatus()
        {
            string licenseNumber = getLicenseNumberInput();
            ClientVehicle.eClientVehicleStatus newClientVehicleStatus = getStatusFromMenu();
            r_Garage.ChangeClientVehicleStatus(licenseNumber , newClientVehicleStatus);
        }

        private void inflateVehicleTiresToMaximum()
        {
            string licenseNumber = getLicenseNumberInput();

            r_Garage.InflateTiresOfClientVehicleToMaximum(licenseNumber);
        }

        private void rechargeVehicle()
        {
            string licenseNumber = getLicenseNumberInput();
            float timeOfChargeInMinutes = getTimeOfChargeInMinutesInput();

            r_Garage.RechargeClientVehicleByLicenseNumber(licenseNumber, timeOfChargeInMinutes);
        }

        private void refuelVehicle()
        {
            string licenseNumber = getLicenseNumberInput();
            FueledEngine.eFuelType fuelType = getFuelTypeInput();
            float amountOfFuel = getFuelAmountInput();

            r_Garage.RefuelClientVehicleByLicenseNumber(licenseNumber,fuelType,amountOfFuel);
        }

        private void showClientVehicleInformation()
        {
            string licenseNumber = getLicenseNumberInput();
            Console.WriteLine(r_Garage.GetClientVehicleInformation(licenseNumber));
        }

        private void exitMenu()
        {
            m_IsManagerStillInTheGarage = false;
        }

        private void printMenuOptionToConsole(eMenuKeyOption i_MenuOptionToPrint)
        {
            const string k_Format = "D";
            StringBuilder menuOptionToPrint = new StringBuilder();
            switch (i_MenuOptionToPrint)
            {
                case eMenuKeyOption.AddVehicleToGarage:
                    menuOptionToPrint.AppendFormat("{0}. Add Vehicle To Garage.", eMenuKeyOption.AddVehicleToGarage.ToString(k_Format));
                    break;
                case eMenuKeyOption.ShowLicenseNumbersOfClientVehicles:
                    menuOptionToPrint.AppendFormat("{0}. Show License Numbers Of Client Vehicles.", eMenuKeyOption.ShowLicenseNumbersOfClientVehicles.ToString(k_Format));
                    break;
                case eMenuKeyOption.ChangeClientVehicleStatus:
                    menuOptionToPrint.AppendFormat("{0}. Change Client Vehicle Status.", eMenuKeyOption.ChangeClientVehicleStatus.ToString(k_Format));
                    break;
                case eMenuKeyOption.InflateVehicleTiresToMaximum:
                    menuOptionToPrint.AppendFormat("{0}. Inflate Vehicle Tires To Maximum.", eMenuKeyOption.InflateVehicleTiresToMaximum.ToString(k_Format));
                    break;
                case eMenuKeyOption.RefuelVehicle:
                    menuOptionToPrint.AppendFormat("{0}. Refuel Vehicle.", eMenuKeyOption.RefuelVehicle.ToString(k_Format));
                    break;
                case eMenuKeyOption.RechargeVehicle:
                    menuOptionToPrint.AppendFormat("{0}. Recharge Vehicle.", eMenuKeyOption.RechargeVehicle.ToString(k_Format));
                    break;
                case eMenuKeyOption.ShowClientVehicleInformation:
                    menuOptionToPrint.AppendFormat("{0}. Show Client Vehicle Information.", eMenuKeyOption.ShowClientVehicleInformation.ToString(k_Format));
                    break;
                case eMenuKeyOption.ExitMenu:
                    menuOptionToPrint.AppendFormat("{0}. Exit Menu", eMenuKeyOption.ExitMenu.ToString(k_Format));
                    break;
                default:
                    printMessageToConsole(eMessageToPrint.InvalidMenuKey);
                    break;
            }

            Console.WriteLine(menuOptionToPrint);
        }

        private void printMessageToConsole(eMessageToPrint i_MessageToPrint)
        {
            StringBuilder messageToPrint = new StringBuilder();
            switch(i_MessageToPrint)
            {
                case eMessageToPrint.MenuHeadline:
                    messageToPrint.Append("Welcome To Ranush&Haimush Awesome Garage!");
                    break;
                case eMessageToPrint.InvalidName:
                    messageToPrint.Append("Invalid name format");
                    break;
                case eMessageToPrint.InvalidPhoneNumber:
                    messageToPrint.Append("Invalid phone number");
                    break;
                case eMessageToPrint.InvalidMenuKey:
                    messageToPrint.Append("Invalid menu option");
                    break;
                case eMessageToPrint.InvalidFuelType:
                    messageToPrint.Append("Invalid fuel type");
                    break;
                case eMessageToPrint.InvalidFuelAmount:
                    messageToPrint.Append("Invalid amount of fuel");
                    break;
                case eMessageToPrint.InvalidTimeOfCharge:
                    messageToPrint.Append("Can not charge for that amount of time");
                    break;
                case eMessageToPrint.InvalidLicenseNumber:
                    messageToPrint.Append("Invalid license number");
                    break;
                case eMessageToPrint.VehicleInformationHeadline:
                    messageToPrint.Append("Message");
                    break;
                case eMessageToPrint.InvalidClientVehicleStatus:
                    messageToPrint.Append("Status is not valid");
                    break;
                case eMessageToPrint.EnterLicenseNumber:
                    messageToPrint.Append("Enter license number");
                    break;
                case eMessageToPrint.EnterMenuKey:
                    messageToPrint.Append("message");
                    break;
                case eMessageToPrint.EnterFuelType:
                    messageToPrint.Append("Enter the fuel type");
                    break;
                case eMessageToPrint.EnterTimeOfCharge:
                    messageToPrint.Append("Enter how long to charge the battery");
                    break;
                case eMessageToPrint.EnterAmountOfFuel:
                    messageToPrint.Append("Enter how much fuel you wish to add");
                    break;
                case eMessageToPrint.EnterNewVehicleStatus:
                    messageToPrint.Append("Enter the vehicle status");
                    break;
                case eMessageToPrint.EnterPhoneNumber:
                    messageToPrint.Append("Enter your phone number");
                    break;
                case eMessageToPrint.EnterName:
                    messageToPrint.Append("Enter your name");
                    break;
                case eMessageToPrint.InvalidYesOrNo:
                    messageToPrint.Append("Invalid input, 'Y' or 'N' only.");
                    break;
                case eMessageToPrint.EnterFilterStatus:
                    messageToPrint.Append("Enter the status to filter the search with.");
                    break;
            }

            Console.WriteLine(messageToPrint);
        }
    }
}
