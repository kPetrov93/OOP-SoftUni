using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hat = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var scarf = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var sets = new List<int>();
            int mostExpensive = 0;

            while (hat.Count > 0 && scarf.Count > 0)
            {
                int currentHat = hat.Peek();
                int currentScarf = scarf.Peek();

                if (currentHat > currentScarf)
                {
                    int sum = currentHat + currentScarf;
                    sets.Add(sum);
                    hat.Pop();
                    scarf.Dequeue();

                    if (sum > mostExpensive)
                    {
                        mostExpensive = sum;
                    }
                }
                else if (currentScarf > currentHat)
                {
                    hat.Pop();
                }
                else
                {
                    scarf.Dequeue();
                    int currentNum = hat.Pop();
                    hat.Push(currentNum + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {mostExpensive}");

            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
