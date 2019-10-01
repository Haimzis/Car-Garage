using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehiclesFactory
{
    public class ArgumentConsumer
    {
        private readonly string r_MessageForUser;
        private readonly string r_NameOfArgument;
        private readonly string[] r_OptionalValues;
        private readonly ArgumentBounds r_Bounds;
        private string m_ValueFromUser;

        public string GetMessage
        {
            get
            {
                return r_MessageForUser;
            }
        }

        public string GetNameOfArgument
        {
            get
            {
                return r_NameOfArgument;
            }
        }

        public ArgumentBounds GetBounds
        {
            get
            {
                return r_Bounds;
            }
        }

        public string[] GetOptionalValues
        {
            get
            {
                return r_OptionalValues;
            }
        }

        public string ValueFromUser
        {
            get
            {
                return m_ValueFromUser;
            }

            set
            {
                m_ValueFromUser = value;
            }
        }

        public ArgumentConsumer(string i_MessageForUser, string i_NameOfArgument, ArgumentBounds i_OptionalBounds, params string[] i_OptionalValues)
        {
            r_MessageForUser = i_MessageForUser;
            r_NameOfArgument = i_NameOfArgument;
            r_Bounds = i_OptionalBounds;
            r_OptionalValues = i_OptionalValues;
        }
    }
}
