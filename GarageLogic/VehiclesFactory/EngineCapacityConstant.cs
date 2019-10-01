namespace Ex03.GarageLogic.VehiclesFactory
{
    class EngineCapacityConstant
    {
        private const float k_FueledCarEngineCapacity = 42;
        private const float k_ElectricCarEngineCapacity = 2.5f;
        private const float k_FueledTruckEngineCapacity = 120;
        private const float k_FueledMotorcycleEngineCapacity = 5.5f;
        private const float k_ElectricMotorcycleEngineCapacity = 1.6f;

        public static float ElectricMotorcycleEngineCapacity
        {
            get => k_ElectricMotorcycleEngineCapacity;
        }
        public static float FueledMotorcycleEngineCapacity
        {
            get => k_FueledMotorcycleEngineCapacity;
        }
        public static float FueledTruckEngineCapacity
        {
            get => k_FueledTruckEngineCapacity;
        }
        public static float ElectricCarEngineCapacity
        {
            get => k_ElectricCarEngineCapacity;
        }
        public static float FueledCarEngineCapacity
        {
            get => k_FueledCarEngineCapacity;
        }
    }
}
