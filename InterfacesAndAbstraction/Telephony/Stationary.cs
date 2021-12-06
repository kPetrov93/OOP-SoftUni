using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Stationary : IStationaryPhone
    {
        public Stationary(string input)
        {
            Input = input;
        }

        public string Input { get; set; }

        public void Dial(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
