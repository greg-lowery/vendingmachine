using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    class VendingMachine
    {

        public Dictionary<string, VendingMachineItem> VendingMachineDictionary { get; set; } = new Dictionary<string, VendingMachineItem> { };
     
        public decimal MachineBalance { get; private set; } = 0;

        public VendingMachine()
        {
            //file to be read of inventory list 
            string currentDirectory = Environment.CurrentDirectory;
            string whereToRead = Path.Combine(currentDirectory, "vendingmachine.csv");

            //create new file to write to
            FileLogWriter writeLogFile = new FileLogWriter();

            //create new instance of inventory read class
            InventoryRead inventoryRead = new InventoryRead();

            //create new dictionary using invetoryReaed method to populate
            VendingMachineDictionary = inventoryRead.ReadFile(whereToRead);
        }
        public void DisplayAvaliableInvetory()
        {
            foreach (KeyValuePair<string, VendingMachineItem> item in VendingMachineDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value.ItemName} - {item.Value.ItemCost} - {item.Value.ItemQuantity} remaining");
            }
        }
        public void DisplayMainMenu()
        {

            string mainMenuSelection = "";
            do
            {
                //display main menu options for user to select
                Console.WriteLine("(1) Display Vending Machine Items \n(2) Purchase \n(3) Exit");
                mainMenuSelection = Console.ReadLine();


                if (mainMenuSelection == "1")
                {
                    DisplayAvaliableInvetory();
                    Console.Write("\n Press any key to return to main menu: ");
                    Console.ReadLine();
                }

                if(mainMenuSelection == "2")
                {
                    DisplayPurchaseMenu();
                }

                if (mainMenuSelection == "3")
                {
                    break;
                }

            } while (mainMenuSelection != "3");
        }

        public void DisplayPurchaseMenu()
        {

            bool exitMenu = false;

            while(exitMenu == false) 
            {
                Console.WriteLine("\n(1) Feed Money \n(2) Select Product \n(3) Finish Transaction");
                Console.WriteLine($"\nCurrent Money Provided: {MachineBalance}");
                string purchaseMenuSelection = Console.ReadLine();

                //add money to bank selection
                if (purchaseMenuSelection == "1")
                {
                    //prompt user for whole dollar amount, then update current machine balance
                    Console.Write("\nPlease enter the whole dollar amount you would like to deposit: ");
                    MachineBalance += decimal.Parse(Console.ReadLine());
                    //TODO: LOG ENTERED MONEY
                }

                //dispense item selection
                if (purchaseMenuSelection == "2")
                {
                    DisplayAvaliableInvetory();
                    Console.Write("\nEnter the code of the product you want to purchase:");
                    string selectedItemCode = Console.ReadLine();

                    //check on item avaliabilty and update inventory 
                    if (VendingMachineDictionary.ContainsKey(selectedItemCode))
                    {
                        //VendingMachineDictionary[selectedItemCode].ItemQuantity; -this needs to be set to property
                        VendingMachineItem item = VendingMachineDictionary[selectedItemCode];
                        if (item.ItemQuantity >= 1)
                        {
                            //update machine balance after purchasing item
                            MachineBalance -= item.ItemCost;
                            
                            //print slogan of selected item
                            string slogan = "";
                            if(item.ItemCategory == "Chip")
                            {
                                slogan = "Crunch Crunch, Yum!";
                            }
                            else if(item.ItemCategory == "Candy")
                            {
                                slogan = "Munch Munch, Yum!";
                            }
                            else if(item.ItemCategory == "Drink")
                            {
                                slogan = "Glug Glug, Yum!";
                            }
                            else if(item.ItemCategory == "Gum")
                            {
                                slogan = "Chew Chew, Yum!";
                            }

                            //print reciept to user
                            Console.WriteLine($"\nYou selected: {item.ItemName} \nCost of item: {item.ItemCost} \nYour remaining balance: {MachineBalance}  \n{slogan}");

                            //update item inventory by subtracting selected item from group
                            item.ItemQuantity--;
                        }
                        else
                        {
                            Console.WriteLine("\nThe selected item is SOLD OUT, please select another.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou entered an invalid code, please try again!");
                    } 
                }

                //finish transaction selection
                if (purchaseMenuSelection == "3")
                {
                    //TODO: break into method:  return customer change in largest coins possible and print change amount to console 
                    int coinChange = (int)(MachineBalance * 100);
                    int quarter = coinChange / 25;
                    coinChange %= 25;
                    int dime = coinChange / 10;
                    coinChange %= 10;
                    int nickel = coinChange / 5;
                    coinChange %= 5;

                    //write to user change expected in quarters, nickles, dimes
                    Console.WriteLine($"\nAmount of change: {MachineBalance} \nquarters: {quarter} \ndimes: {dime} \nnickels: {nickel}\n");

                    //update machine balance to $0
                    MachineBalance = 0;

                    //TODO: Log purchase and machine balance in LOG 


                    //return to main menu after finished 
                    exitMenu = true;
                }
            } 
        }







    }
}
