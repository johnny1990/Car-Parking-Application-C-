using CarParkingCSharpApp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkingCSharpApp.Implementation
{
    public class Parking : IParking
    {
        public int i = 0, j = 0, k = 0;
        public string[] ParkingPlaces = new string[11];
        public DateTime[] ArrivalHour = new DateTime[11];

        public void CarInfo()
        {
            Console.WriteLine("Do you want to find info  for registered cars or invoicing? Respond with I for informations, " +
                           "B for invoices or anything key to go to intro");
            string result = Console.ReadLine();

            if (result == "I")
            {
                CarList();
            }

            if (result == "B")
            {
                SummaryInvoice();
            }

            else
            {
                Intro();
            }
        }

        public void CarList()
        {
            Console.WriteLine("Parking has " + (10 - j) + " parking places available");
            Console.WriteLine("Cars parked are: ");

            if (ParkingPlaces.Length != 0)
            {
                foreach (var item in ParkingPlaces ?? Enumerable.Empty<string>())
                {
                    if (item != null)
                    {
                        Console.WriteLine("[" + item + "]");
                    }
                    else
                    {
                        Console.WriteLine("[ ]");
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no parked carse");
            }

            Intro();
        }

        public void Intro()
        {
            Console.WriteLine("Parking has " + (10 - j) + " parking places available");
            Console.WriteLine("Do you want to register car in parking? Answer with YES or NO.");
            {
                Yes_No();
            }
        }

        public void RegisterCar()
        {
            Console.WriteLine("Type your car register number!");

            ParkingPlaces[k] = Console.ReadLine();
            {
                RegisterParkingPlace();
            }
        }

        public void RegisterParkingPlace()
        {
            i = i + 1;
            j = j + 1;
            k = k + 1;

            Console.WriteLine("Type arrival hour (hh:mm)");
            ArrivalHour[i] = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Car saved succesfully!");
            Console.WriteLine(" ");
            Console.WriteLine("Type YES for register a new car or NO to find more details about car!");

            Yes_No();
        }

        public void SummaryInvoice()
        {
            Console.WriteLine("Please enter your registered car number to invoice");
            string Number = Console.ReadLine();

            if (ParkingPlaces.Contains(Number) == false)
            {
                throw new System.ArgumentException("Car with this number is not registered!", "Number");
            }

            Console.WriteLine("Type Depaerture hour(hh:mm)");
            DateTime DepartHour = DateTime.Parse(Console.ReadLine());
            TimeSpan DurataStationare = (DepartHour - ArrivalHour[i]);
            Console.WriteLine("------------------------Billing & Summary Car Parking-------------------");
            Console.WriteLine("Car was parked:" + DurataStationare +" hours");
            Console.WriteLine("Place:" + (i));

            int chargeHours = (int)DurataStationare.TotalHours;
            int chargeMinutes = (int)DurataStationare.TotalMinutes;


            if (chargeMinutes > chargeHours * 60)
            {
                Console.WriteLine("You need to pay:" + (10 + (chargeHours - 1) * 5 + 5) + " $");
            }

            else if (chargeHours > 1 && (chargeMinutes / 60) == chargeHours)
            {
                Console.WriteLine("You need to pay:" + (10 + (chargeHours - 1) * 5) + " $");
            }

            else if (chargeHours > 1)
            {
                Console.WriteLine("You need to pay:" + (10 + (chargeHours - 1) * 5) + " $");
            }

            else if (chargeHours <= 1)
            {
                Console.WriteLine("You need to pay:" + 10 + " $");
            }

            Console.WriteLine("------------------------------------------------------------------");

            if (ParkingPlaces.Contains(Number))
            {
                ParkingPlaces[Array.IndexOf(ParkingPlaces, Number)] = null;
            }


            ArrivalHour[(i - 1)] = DateTime.Parse("1 / 1 / 0001 12:00:00 AM");//default value

            k = 0;
            j = j - 1;
            i = i - 1;

            Console.WriteLine("Type enter to add a new car or to find another information about other cars");
            Console.ReadLine();

            Intro();
        }

        public void Yes_No()
        {
            string raspuns = Console.ReadLine();
            if (raspuns == "YES")
            {
                RegisterCar();
            }
            else
            {
                CarInfo();
            }
        }
    }
}
