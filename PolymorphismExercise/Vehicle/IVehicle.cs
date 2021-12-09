using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public bool IsEmpty { get; set; }

        public double TankCapacity { get; set; }

        public void Drive(double km);

        public void Refuel(double liters);
    }
}
