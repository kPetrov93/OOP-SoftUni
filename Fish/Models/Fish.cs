﻿using AquaShop.Models.Fishes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;
        private int size;

        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Size = size;
            Price = price;
            
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }

                name = value;
            }
        }

        public string Species
        {
            get => species;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }

                species = value;
            }
        }

        public int Size
        {
            get => size;
            protected set
            {
                size = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }

                price = value;
            }
        }

        public virtual void Eat()
        {
            
        }
    }
}
