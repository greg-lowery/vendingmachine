using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(1) Display Vending Machine Items \n(2) Purchase \n(3) Exit");

            string mainMenuSelection = Console.ReadLine();

            string whereToRead = @"C:\Users\Greg\source\module1-capstone-c-team-5\Capstone\dotnet\vendingmachine.csv";

            InventoryRead inventoryRead = new InventoryRead();

            Dictionary<string, VendingMachineItem> vendingMachineDictionary = inventoryRead.ReadFile(whereToRead);

            if (mainMenuSelection == "1")
            {
                foreach (KeyValuePair<string, VendingMachineItem> item in vendingMachineDictionary)
                {
                    Console.WriteLine($"{item.Key} - {item.Value.ItemName} - {item.Value.ItemCost} - {item.Value.ItemQuantity} remaining");
                }
            }
        }
    }
}
 