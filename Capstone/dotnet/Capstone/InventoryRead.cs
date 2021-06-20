using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class InventoryRead 
    {

         
        //this will read from the inventory file and let us instantiate a dictionary with key = the item code and value = relevant properties of that item

        public Dictionary<string, VendingMachineItem> ReadFile(string whereToRead)
        {
            Dictionary<string, VendingMachineItem> vendingMachineDictionary = new Dictionary<string, VendingMachineItem>();
            try
            {
                using (StreamReader sr = new StreamReader(whereToRead))

                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();

                        //seperate items into array to be read
                        string[] separatedItem = line.Split("|");

                        string itemCode = separatedItem[0].ToString();

                        string itemName = separatedItem[1].ToString();

                        decimal itemCost = decimal.Parse(separatedItem[2].ToString());

                        string itemCategory = separatedItem[3].ToString();

                        int itemQuantity = 5;

                        VendingMachineItem vendingMachineItem = new VendingMachineItem(itemName, itemCost, itemCategory, itemQuantity);

                        vendingMachineDictionary[itemCode] = vendingMachineItem;

                    }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found!" + e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return vendingMachineDictionary;
        }
    }
}
