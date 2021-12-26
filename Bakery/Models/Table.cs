using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;
        private int numberOfPeople;
        private bool isReserved;
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private Table table;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber
        {
            get => tableNumber;
            private set
            {
                tableNumber = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }


        public decimal PricePerPerson
        {
            get => pricePerPerson;
            private set
            {
                pricePerPerson = value;
            }
        }

        public bool IsReserved
        {
            get => isReserved;
            private set
            {
                isReserved = value;
            }
        }
        public decimal Price
        {
            get => NumberOfPeople * PricePerPerson;
            
        }

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal total = 0;

            foreach (var item in drinkOrders)
            {
                total += item.Price;
            }

            foreach (var item in foodOrders)
            {
                total += item.Price;
            }

            total += Price;

            return total;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
            
            
        }
    }
}
