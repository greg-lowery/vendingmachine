using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.DisplayMainMenu();
        }
    }
}
 