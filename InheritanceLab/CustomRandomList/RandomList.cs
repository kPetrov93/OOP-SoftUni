using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString()
        {
            var index = random.Next(0, Count);
            return this[index];
        }


        public string RemoveRandomString()
        {
            int index = random.Next(0, Count);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }

    }
}
