using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fishes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private int total;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
                     
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
        {
            get => total += Decorations.Count;
            
        }

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {

            if (this.Capacity - 1 >= 0)
            {
                Fish.Add(fish);

                Capacity -= 1;
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

        }

        public void Feed()
        {
            foreach (var item in Fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            string fishColl = Fish.Any() ? string.Join(", ", Fish) : "none";
            sb.AppendLine($"Fish: {fishColl}");
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }
    }
}
