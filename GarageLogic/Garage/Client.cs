using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Garage
{
    public class Client
    {
        private string r_FullName;
        private int r_PhoneNumber;

        public Client(string i_FullName, int i_PhoneNumber)
        {
            r_FullName = i_FullName;
            r_PhoneNumber = i_PhoneNumber;
        }


        public string FullName
        {
            get
            {
                return r_FullName;
            }
            set
            {
                r_FullName = value;
            }
        }
        public int PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
            set
            {
                r_PhoneNumber = value;
            }
        }
    }
}
