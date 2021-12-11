using PolymorphismWildFarm.Animals;
using PolymorphismWildFarm.Food;
using System;
using System.Collections.Generic;

namespace PolymorphismWildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string animalType = inputInfo[0];
                string animalName = inputInfo[1];
                double animalWeight = double.Parse(inputInfo[2]);

                string foodType = foodInfo[0];
                int amount = int.Parse(foodInfo[1]);

                try
                {
                    IAnimal animal = null;

                    if (animalType == "Cat" || animalType == "Tiger" || animalType == "Mouse" || animalType == "Dog")
                    {
                        string region = inputInfo[3];

                        if (animalType == "Cat" || animalType == "Tiger")
                        {
                            string breed = inputInfo[4];

                            if (animalType == "Cat")
                            {
                                animal = new Cat(animalName, animalWeight, region, breed);
                            }
                            else if (animalType == "Tiger")
                            {
                                animal = new Tiger(animalName, animalWeight, region, breed);
                            }
                        }
                        else if (animalType == "Mouse")
                        {
                            animal = new Mouse(animalName, animalWeight, region);
                        }
                        else if (animalType == "Dog")
                        {
                            animal = new Dog(animalName, animalWeight, region);
                        }
                    }
                    else if (animalType == "Hen" || animalType == "Owl")
                    {
                        double wingSize = double.Parse(inputInfo[3]);
                        if (animalType == "Hen")
                        {
                            animal = new Hen(animalName, animalWeight, wingSize);
                        }
                        else if (animalType == "Owl")
                        {
                            animal = new Owl(animalName, animalWeight, wingSize);
                        }
                    }

                    Console.WriteLine(animal.ProduceSound());

                    animals.Add(animal);

                    IFood food = null;

                    if (foodType == "Meat")
                    {
                        food = new Meat(amount);
                    }
                    else if (foodType == "Vegetable")
                    {
                        food = new Vegetable(amount);
                    }
                    else if (foodType == "Fruit")
                    {
                        food = new Fruit(amount);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(amount);
                    }

                    animal.Eat(food);
                }
                catch (Exception ms)
                {
                    Console.WriteLine(ms.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
