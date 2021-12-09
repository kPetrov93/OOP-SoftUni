using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }

        public  double FuelConsumption { get; set; }

        void Drive(double km);

        void Refuel(double liters);
    }
}
