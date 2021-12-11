using PolymorphismWildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismWildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat || food is Vegetable)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.30;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
