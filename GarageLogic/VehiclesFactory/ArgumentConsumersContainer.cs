using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic.VehiclesFactory
{
    public class ArgumentConsumersContainer
    {
        private readonly Dictionary<string, ArgumentConsumer> r_ArgumentConsumersCollection = new Dictionary<string, ArgumentConsumer>();

        public Dictionary<string, ArgumentConsumer> GetConsumers
        {
            get
            {
                return r_ArgumentConsumersCollection;
            }
        }

        public void AddArgument(string i_ArgumentProperty, ArgumentConsumer i_ArgumentConsumer)
        {
            r_ArgumentConsumersCollection.Add(i_ArgumentProperty, i_ArgumentConsumer);
        }
    }
}
