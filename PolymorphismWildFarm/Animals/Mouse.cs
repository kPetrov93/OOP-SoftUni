using PolymorphismWildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismWildFarm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Fruit || food is Vegetable)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.10;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
