using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smart : ISmartphone
    {
        public Smart(string input, string link)
        {
            Input = input;
            Link = link;
        }

        public string Input { get; set; }

        public string Link { get; set; }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
