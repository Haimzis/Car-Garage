using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] i_Args)
        {
            GarageManagerUI garageManagerUi = new GarageManagerUI();
            garageManagerUi.StartManageGarage();
        }
    }
}
