using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public class SaltwaterFish : Fish
    {
        private int size = 5;
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            
        }

        public override void Eat()
        {
            Size += 2;
        }
    }
}
