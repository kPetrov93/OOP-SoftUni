using Bakery.Core.Contracts;
using Bakery.Models;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal income = 0;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
                drinks.Add(drink);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
                drinks.Add(drink);
            }
            
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food;

            if (type == "Cake")
            {
                food = new Cake(name, price);
                bakedFoods.Add(food);
            }
            else if (type == "Bread")
            {
                food = new Bread(name, price);
                bakedFoods.Add(food);
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
                tables.Add(table);
                
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
            }
            

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            var table = tables.FindAll(x => !x.IsReserved);

            foreach (var item in table)
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            decimal total = 0;

            foreach (var item in drinks)
            {
                total += item.Price;
            }

            foreach (var item in bakedFoods)
            {
                total += item.Price;
            }

            total += income;

            return $"Total income: {total:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            StringBuilder sb = new StringBuilder();
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():f2}");
            table.Clear();

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drink = drinks.FirstOrDefault(x => x.Name == drinkName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            else
            {
                table.OrderDrink(drink);
                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            else
            {
                table.OrderFood(food);
                return $"Table {tableNumber} ordered {foodName}";
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                tables.Add(table);
                income += table.Price;
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
