using System;
using System.Collections.Generic;

namespace PolymorphismRaiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> raiders = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());
            long total = 0;
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string classType = Console.ReadLine();

                BaseHero hero = null;

                if (classType == "Druid")
                {
                    hero = new Druid(name,80);
                }
                else if (classType == "Paladin")
                {
                    hero = new Paladin(name,100);
                }
                else if (classType == "Rogue")
                {
                    hero = new Rogue(name,80);
                }
                else if (classType == "Warrior")
                {
                    hero = new Warrior(name,100);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i -= 1;
                    continue;
                }

                raiders.Add(hero);

                total += hero.Power;
            }

            long bossPower = long.Parse(Console.ReadLine());

            foreach (var item in raiders)
            {
                Console.WriteLine(item.CastAbility());
            }

            if (total >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
