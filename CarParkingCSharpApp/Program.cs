using CarParkingCSharpApp.Implementation;
using System;

namespace CarParkingCSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------Welcome to Car Parking !-----------------------------");
            Parking p = new Parking();
            p.Intro();
        }
    }
}
