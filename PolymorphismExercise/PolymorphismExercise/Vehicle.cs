using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }

        public virtual double FuelConsumption { 
            get => fuelConsumption; 
            set => fuelConsumption = value; 
        }

        public void Drive(double km)
        {
            FuelQuantity -= km * FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public bool CanDrive(double km)
        {
            if (FuelQuantity - (km * FuelConsumption) >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
