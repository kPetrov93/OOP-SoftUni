using System;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] links = Console.ReadLine().Split();

            for (int i = 0; i < numbers.Length; i++)
            {
                string current = numbers[i];

                if (current.All(char.IsDigit))
                {
                    if (current.Length == 7)
                    {
                        Stationary stationary = new Stationary(current);
                        stationary.Dial(current);
                    }
                    else
                    {
                        Smart smart = new Smart(current, "");
                        smart.Call(current);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < links.Length; i++)
            {
                string current = links[i];

                if (current.Any(char.IsNumber))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Smart smart = new Smart("", current);
                    smart.Browse(current);
                }
            }
        }
    }
}
