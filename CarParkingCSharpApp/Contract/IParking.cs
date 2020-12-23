using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkingCSharpApp.Contract
{
    interface IParking
    {
        void RegisterCar();
        void Intro();
        void Yes_No();
        void SummaryInvoice();
        void RegisterParkingPlace();
        void CarInfo();
        void CarList();
    }
}
