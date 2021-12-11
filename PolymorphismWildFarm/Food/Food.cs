using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismWildFarm.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }

    }
}
