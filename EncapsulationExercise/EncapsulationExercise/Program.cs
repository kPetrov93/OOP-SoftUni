using System;

namespace EncapsulationExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();
                string input = Console.ReadLine();

                string pizzaName = pizzaInfo[1];
                string doughType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while (input != "END")
                {
                    string[] toppingInfo = input.Split();
                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType,toppingWeight);

                    pizza.AddToppings(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
