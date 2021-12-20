using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public class FreshwaterFish : Fish
    {
        private int size = 3;

        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            
        }

        public override void Eat()
        {
            Size += 3;
        }
    }
}
