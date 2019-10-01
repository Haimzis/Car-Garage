using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ex03.GarageLogic.GarageUtils;
using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.VehiclesFactory
{
    public static class VehiclesFactory
    {
        public enum eVehicleType
        {
            Car = 1,
            ElectricCar,
            Motorcycle,
            ElectricMotorcycle,
            Truck,
        }

        public static Vehicle GetVehicle(eVehicleType i_VehicleType, ArgumentConsumersContainer i_VehicleArgumentConsumersContainer)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    return getFueledCar(i_VehicleArgumentConsumersContainer);
                case eVehicleType.Motorcycle:
                    return getMotorcycle(i_VehicleArgumentConsumersContainer);
                case eVehicleType.ElectricCar:
                    return getElectricCar(i_VehicleArgumentConsumersContainer);
                case eVehicleType.ElectricMotorcycle:
                    return getElectricMotorcycle(i_VehicleArgumentConsumersContainer);
                case eVehicleType.Truck:
                    return getTruck(i_VehicleArgumentConsumersContainer);
                default:
                    return null;
            }
        }

        public static ArgumentConsumersContainer GetVehicleArguments(eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    return getFueledCarArguments();
                case eVehicleType.Motorcycle:
                    return getMotorcycleArguments();
                case eVehicleType.ElectricCar:
                    return getElectricCarArguments();
                case eVehicleType.ElectricMotorcycle:
                    return getElectricMotorcycleArguments();
                case eVehicleType.Truck:
                    return getTruckArguments();
                default:
                    return null;
            }
        }

        private static ArgumentConsumersContainer getTruckArguments()
        {
            ArgumentConsumersContainer argumentContainer = new ArgumentConsumersContainer();
            argumentContainer.AddArgument(Keys.LicenseNumber, new ArgumentConsumer("Enter the License number of the car:", "License Number", null));
            argumentContainer.AddArgument(Keys.HazardousCargo, new ArgumentConsumer("Enter Y/N for hazardous cargo", "Hazardous Cargo", null));
            argumentContainer.AddArgument(Keys.CargoVolume, new ArgumentConsumer("Enter Cargo Volume:", "Cargo Volume", null));
            argumentContainer.AddArgument(Keys.RemainingFuel, new ArgumentConsumer("Enter remaining fuel:", "Remaining Fuel", new ArgumentBounds(0, null, EngineCapacityConstant.FueledTruckEngineCapacity)));
            addTireArguments(ref argumentContainer, Truck.GetNumberOfTires, 26f);

            return argumentContainer;
        }

        private static ArgumentConsumersContainer getElectricMotorcycleArguments()
        {
            ArgumentConsumersContainer argumentContainer = new ArgumentConsumersContainer();
            argumentContainer.AddArgument(Keys.RemainingCharge, new ArgumentConsumer("Enter remaining charge:", "Remaining Charge", new ArgumentBounds(0, null, EngineCapacityConstant.ElectricMotorcycleEngineCapacity)));
            fillMotorcycleArguments(ref argumentContainer);
            addTireArguments(ref argumentContainer, Motorcycle.GetNumberOfTires, 28f);
            return argumentContainer;
        }


        private static ArgumentConsumersContainer getMotorcycleArguments()
        {
            ArgumentConsumersContainer argumentContainer = new ArgumentConsumersContainer();
            argumentContainer.AddArgument(Keys.RemainingFuel, new ArgumentConsumer("Enter remaining fuel:", "Remaining Fuel", new ArgumentBounds(0, null, EngineCapacityConstant.FueledMotorcycleEngineCapacity)));
            fillMotorcycleArguments(ref argumentContainer);
            addTireArguments(ref argumentContainer, Motorcycle.GetNumberOfTires, 28f);

            return argumentContainer;
        }

        private static ArgumentConsumersContainer getElectricCarArguments()
        {
            ArgumentConsumersContainer argumentContainer = new ArgumentConsumersContainer();
            argumentContainer.AddArgument(Keys.RemainingFuel, new ArgumentConsumer("Enter remaining charge:", "Remaining Charge", new ArgumentBounds(0, null, EngineCapacityConstant.ElectricCarEngineCapacity)));
            fillCarArguments(ref argumentContainer);
            addTireArguments(ref argumentContainer, Car.GetNumberOfTires, 30f);
            return argumentContainer;
        }

        private static ArgumentConsumersContainer getFueledCarArguments()
        {
            ArgumentConsumersContainer argumentContainer = new ArgumentConsumersContainer();
            argumentContainer.AddArgument(Keys.RemainingFuel, new ArgumentConsumer("Enter remaining fuel:", "Remaining Energy", new ArgumentBounds(0, null , EngineCapacityConstant.ElectricCarEngineCapacity)));
            fillCarArguments(ref argumentContainer);
            addTireArguments(ref argumentContainer, Car.GetNumberOfTires, 30f);

            return argumentContainer;
        }
        private static void fillMotorcycleArguments(ref ArgumentConsumersContainer i_ArgumentsContainer)
        {
            string[] licenseTypes = Enum.GetNames(typeof(Motorcycle.eLicenseType));
            i_ArgumentsContainer.AddArgument(Keys.LicenseNumber, new ArgumentConsumer("Enter the License number of the car:", "License Number", null));
            i_ArgumentsContainer.AddArgument(Keys.LicenseType, new ArgumentConsumer("Enter License type:", "License Type", null, licenseTypes));
            i_ArgumentsContainer.AddArgument(Keys.EngineVolume, new ArgumentConsumer("Enter Engine volume:", "License Type", new ArgumentBounds(0, null, null), licenseTypes));
        }

        private static void fillCarArguments(ref ArgumentConsumersContainer i_ArgumentsContainer)
        {
            string[] carColor = Enum.GetNames(typeof(Car.eCarColor));
            i_ArgumentsContainer.AddArgument(Keys.LicenseNumber, new ArgumentConsumer("Enter the License number of the car:", "License Number", null));
            i_ArgumentsContainer.AddArgument(Keys.Color, new ArgumentConsumer("Select an color:", "Color", null, carColor));
            i_ArgumentsContainer.AddArgument(Keys.NumberOfDoors, new ArgumentConsumer("Select how many doors (between 2 - 5):", "Number Of Doors", new ArgumentBounds(Car.MinimumNumberOfDoors, Car.MaximumNumberOfDoors, null)));
        }

        private static void addTireArguments(ref ArgumentConsumersContainer i_ArgumentContainer, int i_HowManyArguments, float i_MaxAirPressure)
        {
            for(int i = 1; i <= i_HowManyArguments; i++)
            {
                i_ArgumentContainer.AddArgument(
                    string.Format(Keys.TireAirPressure, i),
                    new ArgumentConsumer("Enter air pressure", "Air Pressure", new ArgumentBounds(0, null, i_MaxAirPressure)));
                i_ArgumentContainer.AddArgument(
                    string.Format(Keys.TireManufacturer, i),
                    new ArgumentConsumer("Enter Manufacturer", "Manufacturer", null));
            }
        }


        private static Car getFueledCar(ArgumentConsumersContainer i_VehicleArgumentConsumersContainer)
        {
            Dictionary<string, ArgumentConsumer> carArguments = i_VehicleArgumentConsumersContainer.GetConsumers;
            float remainingFuel = float.Parse(carArguments[Keys.RemainingFuel].ValueFromUser);
            FueledEngine.eFuelType fuelType = FueledEngine.eFuelType.Octan96;
            Engine engine = new FueledEngine(remainingFuel, EngineCapacityConstant.FueledCarEngineCapacity, fuelType);
            Car car = getCar(carArguments, engine);
            return car;
        }


        private static Car getElectricCar(ArgumentConsumersContainer i_VehicleArgumentConsumersContainer)
        {
            Dictionary<string, ArgumentConsumer> carArguments = i_VehicleArgumentConsumersContainer.GetConsumers;
            float remainingFuel = float.Parse(carArguments[Keys.RemainingCharge].ValueFromUser);
            Engine engine = new ElectricEngine(remainingFuel, EngineCapacityConstant.ElectricCarEngineCapacity);
            Car car = getCar(carArguments, engine);
            return car;
        }

        private static Motorcycle getMotorcycle(ArgumentConsumersContainer i_VehicleArgumentConsumersContainer)
        {
            Dictionary<string, ArgumentConsumer> motorcycleArguments = i_VehicleArgumentConsumersContainer.GetConsumers;
            float remainingFuel = float.Parse(motorcycleArguments[Keys.RemainingFuel].ValueFromUser);
            FueledEngine.eFuelType fuelType = FueledEngine.eFuelType.Octan95;
            Engine engine = new FueledEngine(remainingFuel, EngineCapacityConstant.ElectricMotorcycleEngineCapacity, fuelType);
            Motorcycle motorcycle = getMotorcycle(motorcycleArguments, engine);
            return motorcycle;
        }

        private static Motorcycle getElectricMotorcycle(ArgumentConsumersContainer i_VehicleArgumentConsumersContainer)
        {
            Dictionary<string, ArgumentConsumer> motorcycleArguments = i_VehicleArgumentConsumersContainer.GetConsumers;
            float remainingCharge = float.Parse(motorcycleArguments[Keys.RemainingCharge].ValueFromUser);
            Engine engine = new ElectricEngine(remainingCharge, EngineCapacityConstant.ElectricMotorcycleEngineCapacity);
            Motorcycle motorcycle = getMotorcycle(motorcycleArguments, engine);
            return motorcycle;
        }

        private static Truck getTruck(ArgumentConsumersContainer i_VehicleArgumentConsumersContainer)
        {
            Dictionary<string, ArgumentConsumer> truckArguments = i_VehicleArgumentConsumersContainer.GetConsumers;
            float remainingFuel = float.Parse(truckArguments[Keys.RemainingFuel].ValueFromUser);
            FueledEngine.eFuelType fuelType = FueledEngine.eFuelType.Soler;
            Engine engine = new FueledEngine(remainingFuel, EngineCapacityConstant.FueledTruckEngineCapacity, fuelType);
            Truck truck = getTruck(truckArguments, engine);
            return truck;
        }

        private static Collection<Tire> makeTiresCollection(Dictionary<string, ArgumentConsumer> i_Arguments, int i_HowManyTires)
        {
            Collection<Tire> tires = new Collection<Tire>();
            for(int i = 1; i <= i_HowManyTires; i++)
            {
                float maximumAirPressure = 0;
                string manufacturer = i_Arguments[string.Format(Keys.TireManufacturer, i)].ValueFromUser;
                float? boundsMaxValue = i_Arguments[string.Format(Keys.TireAirPressure, i)].GetBounds.MaxValueFloat;
                float currentAirPressure = float.Parse(i_Arguments[string.Format(Keys.TireAirPressure, i)].ValueFromUser);
                if(boundsMaxValue != null)
                {
                     maximumAirPressure = boundsMaxValue.Value;
                }

                Tire tire = new Tire(manufacturer, currentAirPressure, maximumAirPressure);
                tires.Add(tire);
            }

            return tires;
        }

        private static Car getCar(Dictionary<string, ArgumentConsumer> i_CarArguments, Engine i_Engine)
        {
            Car.eCarColor color = EnumUtils.GetStringAsEnum<Car.eCarColor>(i_CarArguments[Keys.Color].ValueFromUser);
            Car.eNumberOfDoors numberOfDoors = EnumUtils.GetStringAsEnum<Car.eNumberOfDoors>(i_CarArguments[Keys.NumberOfDoors].ValueFromUser);
            string licenseNumber = i_CarArguments[Keys.LicenseNumber].ValueFromUser;
            Collection<Tire> tires = makeTiresCollection(i_CarArguments, Car.GetNumberOfTires);
            Car newCar = new Car(licenseNumber, tires, i_Engine, color, numberOfDoors);
            return newCar;
        }

        private static Motorcycle getMotorcycle(Dictionary<string, ArgumentConsumer> i_MotorcycleArguments, Engine i_Engine)
        {
            Motorcycle.eLicenseType licenseType =
                EnumUtils.GetStringAsEnum<Motorcycle.eLicenseType>(
                    i_MotorcycleArguments[Keys.LicenseType].ValueFromUser);
            int engineVolume = int.Parse(i_MotorcycleArguments[Keys.EngineVolume].ValueFromUser);
            string licenseNumber = i_MotorcycleArguments[Keys.LicenseNumber].ValueFromUser;
            Collection<Tire> tires = makeTiresCollection(i_MotorcycleArguments, Motorcycle.GetNumberOfTires);
            Motorcycle motorcycle = new Motorcycle(licenseNumber, tires, i_Engine, licenseType, engineVolume);
            return motorcycle;
        }

        private static Truck getTruck(Dictionary<string, ArgumentConsumer> i_TruckArguments, Engine i_Engine)
        {
            bool isHazardous = bool.Parse(i_TruckArguments[Keys.HazardousCargo].ValueFromUser);
            float cargoVolume = float.Parse(i_TruckArguments[Keys.CargoVolume].ValueFromUser);
            string licenseNumber = i_TruckArguments[Keys.LicenseNumber].ValueFromUser;
            Collection<Tire> tires = makeTiresCollection(i_TruckArguments, Truck.GetNumberOfTires);
            Truck truck = new Truck(licenseNumber, tires, i_Engine, cargoVolume , isHazardous);
            return truck;
        }
    }
}
