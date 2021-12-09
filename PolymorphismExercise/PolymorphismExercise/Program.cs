using System;

namespace PolymorphismExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            double carFuelAmount = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            double truckFuelAmount = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            Vehicle car = new Car(carFuelAmount, carFuelConsumption);
            Vehicle truck = new Truck(truckFuelAmount, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string vehicle = input[1];
                double value = double.Parse(input[2]);

                if (command == "Drive")
                {
                    if (vehicle=="Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (vehicle=="Truck")
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
