using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {

                    value = 0;
                }
                
                fuelQuantity = value;
                
            }
        }

        public virtual double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public bool IsEmpty { get ; set ; }

        public void Drive(double km)
        {
            FuelQuantity -= km * FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
            if (liters<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;

        }

        public bool CanDrive(double km)
        {
            if (FuelQuantity - FuelConsumption * km >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
