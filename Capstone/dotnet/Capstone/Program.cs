using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)

        {
            //file to be read of inventory list 
            string currentDirectory = Environment.CurrentDirectory;
            string whereToRead = Path.Combine(currentDirectory, "vendingmachine.csv");

            string mainMenuSelection = "";
            do
            {
                //display main menu options for user to select
                Console.WriteLine("(1) Display Vending Machine Items \n(2) Purchase \n(3) Exit");
                mainMenuSelection = Console.ReadLine();
                
                if (mainMenuSelection == "3")
                {
                    break;
                }

                //create new instance of inventoryread class
                InventoryRead inventoryRead = new InventoryRead();

                //create new dictionary using invetoryReaed method to populate
                Dictionary<string, VendingMachineItem> vendingMachineDictionary = inventoryRead.ReadFile(whereToRead);
                
                if (mainMenuSelection == "1")
                {
                    foreach (KeyValuePair<string, VendingMachineItem> item in vendingMachineDictionary)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value.ItemName} - {item.Value.ItemCost} - {item.Value.ItemQuantity} remaining");
                    }
                    Console.WriteLine("\n Press any key to return to main menu");
                    Console.ReadLine();
                }
            } while (mainMenuSelection != "3");
          
        }
    }
}
 