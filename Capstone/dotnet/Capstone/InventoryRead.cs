using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class InventoryRead
    {

         
        //this will read from the inventory file and let us instantiate an item base on that particular line of vendingmachine.csv

        public Dictionary<string, VendingMachineItem> ReadFile(string whereToRead)
        {
            Dictionary<string, VendingMachineItem> vendingMachineDictionary = new Dictionary<string, VendingMachineItem>();
            try
            {
                using (StreamReader sr = new StreamReader(whereToRead))

                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();

                        string[] separatedItem = line.Split("|");


                             string itemCode = separatedItem[0].ToString();

                            string itemName = separatedItem[1].ToString();

                            decimal itemCost = decimal.Parse(separatedItem[2].ToString());

                            string itemCategory = separatedItem[3].ToString();


                        VendingMachineItem vendingMachineItem = new VendingMachineItem(itemName, itemCost, itemCode, itemCategory);

                        vendingMachineDictionary[itemCode] = vendingMachineItem;

                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return vendingMachineDictionary;
        }



    }
}
