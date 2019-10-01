using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ex03.GarageLogic.VehiclesParts;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private readonly string r_LicenseNumber;
        private Collection<Tire> m_TiresCollection;
        private Engine m_VehicleEngine;

        protected Vehicle(string i_LicenseNumber, Collection<Tire> i_TiresCollection, Engine i_VehicleEngine)
        {
            r_LicenseNumber = i_LicenseNumber;
            m_TiresCollection = i_TiresCollection;
            m_VehicleEngine = i_VehicleEngine;
        }

        public virtual string GetVehicleInformationAsString()
        {
            StringBuilder vehicleInformationStringBuilder = new StringBuilder();
            vehicleInformationStringBuilder.AppendFormat("License Number: {0}{1}", LicenseNumber, Environment.NewLine);
            vehicleInformationStringBuilder.AppendFormat("Remaining Energy Percentage: {0}{1}", RemainingEnergyPercentage, Environment.NewLine);
            vehicleInformationStringBuilder.AppendFormat("Tires Information:{0}{1}",Environment.NewLine, getTiresCollectionInformationAsString());
            vehicleInformationStringBuilder.AppendFormat("Engine Information:{0}{1}", Environment.NewLine, VehicleEngine.GetEngineInformationAsString());

            return vehicleInformationStringBuilder.ToString();
        }

        protected string getTiresCollectionInformationAsString()
        {
            StringBuilder tiresCollectionInformationStringBuilder = new StringBuilder();

            foreach (Tire tire in TiresCollection)
            {
                tiresCollectionInformationStringBuilder.Append(tire.GetTireInformationAsString()).Append(Environment.NewLine);
            }

            return tiresCollectionInformationStringBuilder.ToString();
        }

        public void InflateVehicleTiresToMaximum()
        {
            foreach(Tire tire in m_TiresCollection)
            {
                tire.InflateTireToMaximum();
            }
        }

        //public void AddTires(Collection<Tire> i_TiresCollection)
        //{
        //    foreach (Tire tire in i_TiresCollection)
        //    {
        //        m_TiresCollection.Add(tire);
        //    }
        //}

        public float RemainingEnergyPercentage
        {
            get
            {
                if(m_VehicleEngine == null)
                {
                    return 0;
                }

                return m_VehicleEngine.CalculateRemainingEnergyPercentage();
            }
        }
        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }
        public Engine VehicleEngine
        {
            get
            {
                return m_VehicleEngine;
            }
            set
            {
                m_VehicleEngine = value;
            }
        }
       
        public Collection<Tire> TiresCollection
        {
            get
            {
                return m_TiresCollection;
            }
            set
            {
                m_TiresCollection = value;
            }
        }
    }
}
