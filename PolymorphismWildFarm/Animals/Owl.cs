using PolymorphismWildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismWildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.25;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
