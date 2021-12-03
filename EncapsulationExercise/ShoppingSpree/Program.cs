using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var people = new Dictionary<string, Person>();
                var products = new Dictionary<string, Product>();

                string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var currentPerson in inputPeople)
                {
                    string[] currentSplit = currentPerson.Split("=");
                    string name = currentSplit[0];
                    int money = int.Parse(currentSplit[1]);

                    Person person = new Person(name, money);
                    people.Add(person.Name, person);
                }

                foreach (var currentProduct in inputProducts)
                {
                    string[] currentSplit = currentProduct.Split("=");
                    string name = currentSplit[0];
                    int cost = int.Parse(currentSplit[1]);

                    Product product = new Product(name, cost);
                    products.Add(product.Name, product);
                }

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] inputSplitted = input.Split();

                    Person person = people[inputSplitted[0]];
                    Product product = products[inputSplitted[1]];

                    if (person.Money - product.Cost < 0)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        input = Console.ReadLine();
                        continue;
                    }

                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");

                    input = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    if (person.Value.Products.Count == 0)
                    {
                        Console.WriteLine($"{person.Key} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Key} - {string.Join(", ", person.Value.Products.Select(x => x.Name))}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
