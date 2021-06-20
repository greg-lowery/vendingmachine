using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        //create VendingMachine properties for a dictionary of items and a monetary balance
        public Dictionary<string, VendingMachineItem> VendingMachineDictionary { get; set; } = new Dictionary<string, VendingMachineItem> { };

        //create a machine balance to keep track of money input by user
        public decimal MachineBalance { get;  private set; } = 0;

        //instantiate log writing method 
        FileLogWriter fileLogWriter = new FileLogWriter();

        //create a timestamp for log printing
        string timeStamp = DateTime.Now.ToString();

        //constructor method for an instance of a VendingMachine
        public VendingMachine()
        {
            //file to be read of inventory list 
            string currentDirectory = Environment.CurrentDirectory;
            string whereToRead = Path.Combine(currentDirectory, "vendingmachine.csv");

            //create new instance of inventory read class
            InventoryRead inventoryRead = new InventoryRead();

            //create new dictionary using inventoryRead method to populate
            VendingMachineDictionary = inventoryRead.ReadFile(whereToRead);
        }

        //method for displaying the inventory from the vending machine dictionary
        public void DisplayAvailableInvetory()
        {
            foreach (KeyValuePair<string, VendingMachineItem> item in VendingMachineDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value.ItemName} - {item.Value.ItemCost:c2} - {item.Value.ItemQuantity} remaining");
            }
        }

        //main menu display of a VendingMachine
        public void DisplayMainMenu()
        {

            string mainMenuSelection = "";

            while (mainMenuSelection != "3") 
            {
                //display main menu options for user to select
                Console.WriteLine("(1) Display Vending Machine Items \n(2) Purchase \n(3) Exit");
                mainMenuSelection = Console.ReadLine();

                //handle invalid user input
                if (mainMenuSelection != "1" && mainMenuSelection != "2" && mainMenuSelection != "3")
                {
                    Console.WriteLine("\nYou entered an invalid code, please try again!\n");
                }

                //menu selection "1" to display full inventory to user 
                if (mainMenuSelection == "1")
                {
                    DisplayAvailableInvetory();
                    Console.Write("\n Press any key to return to main menu: ");
                    Console.ReadLine();
                }
                //menu selection "2" to take user to purchasing menu
                if (mainMenuSelection == "2")
                {
                    PurchaseMenu();
                }

                //menu selection "3" to leave program
                if (mainMenuSelection == "3")
                {
                    break;
                }
                //TODO: PRINT SALES REPORT
                //if (mainMenuSelection = 4)

            } 
        }

        public void PurchaseMenu()
        {
            //set to true to exit to main menu
            bool exitMenu = false;

            while (exitMenu == false)
            {
                Console.WriteLine("\n(1) Feed Money \n(2) Select Product \n(3) Finish Transaction");
                Console.WriteLine($"\nCurrent Money Provided: {MachineBalance:c2}");
                string purchaseMenuSelection = Console.ReadLine();

                //handle invalid user input
                if (purchaseMenuSelection != "1" && purchaseMenuSelection != "2" && purchaseMenuSelection != "3")
                {
                    Console.WriteLine("\nYou entered an invalid code, please try again!\n");
                }
                //add money to bank selection
                if (purchaseMenuSelection == "1")
                {
                    FeedMoney();
                }

                //dispense item selection
                if (purchaseMenuSelection == "2")
                {
                    DispenseItem();
                }
               
                //finish transaction selection
                if (purchaseMenuSelection == "3")
                {
                    FinishTransaction();
                    //return to main menu after finished 
                    exitMenu = true;
                }
                
            }
        }

        public void FeedMoney()
        {
            //prompt user for whole dollar amount to deposit
            Console.Write("\nPlease enter the whole dollar amount you would like to deposit $(1, 2, 5, 10, or 20): ");
            string userDepositAmount = Console.ReadLine();
            
            //accept only  1, 2, 5, 10, 20 as a valid deposit amount
            if (userDepositAmount == "1" || userDepositAmount == "2" || userDepositAmount == "5" || userDepositAmount == "10" || userDepositAmount == "20")
            {
                decimal depositAmount = decimal.Parse(userDepositAmount);

                //add deposited amount to machine balance
                MachineBalance += depositAmount;

                //write to file log for machine 
                string logFeedMoney = $"{timeStamp} FEED MONEY: {depositAmount:c2} {MachineBalance:c2}";
                fileLogWriter.WriteLogMessage(logFeedMoney);
            }

            //throw error message if currency deposit is invalid
            else
            {
                Console.WriteLine("\nInvalid Currency Deposited. Please Deposit Whole Dollar Amounts Only.");
            }
            
        }
        public void DispenseItem()
        {
            //display inventory to user
            DisplayAvailableInvetory();
            
            //prompt user for item code and accept input
            Console.Write("\nEnter the code of the product you want to purchase:");
            string selectedItemCode = Console.ReadLine().ToUpper();

            //check if the dictionary contains the item code that the user selected
            if (VendingMachineDictionary.ContainsKey(selectedItemCode))
            {
                VendingMachineItem item = VendingMachineDictionary[selectedItemCode];
                if (item.ItemQuantity >= 1)
                {
                    //create a current machine balance for manipulating later
                    decimal currentMachineBalance = MachineBalance;

                    //make sure user has sufficient funds for item, else throw error message
                    if (MachineBalance > item.ItemCost)
                    {

                        //update machine balance after purchasing item
                        MachineBalance -= item.ItemCost;

                        //print slogan of selected vending machine item
                        string slogan = "";
                        if (item.ItemCategory == "Chip")
                        {
                            slogan = "Crunch Crunch, Yum!";
                        }
                        else if (item.ItemCategory == "Candy")
                        {
                            slogan = "Munch Munch, Yum!";
                        }
                        else if (item.ItemCategory == "Drink")
                        {
                            slogan = "Glug Glug, Yum!";
                        }
                        else if (item.ItemCategory == "Gum")
                        {
                            slogan = "Chew Chew, Yum!";
                        }

                        //print reciept to user
                        Console.WriteLine($"\nYou selected: {item.ItemName} \nCost of item: {item.ItemCost:c2} \nYour remaining balance: {MachineBalance:c2}  \n{slogan}");

                        //update item inventory by subtracting selected item from group
                        item.ItemQuantity--;

                        //WRITE TO THE LOG
                        string logItemPurchased = $"{timeStamp} {item.ItemName} {VendingMachineDictionary[selectedItemCode]} {currentMachineBalance:c2} {MachineBalance:c2}";
                        fileLogWriter.WriteLogMessage(logItemPurchased);
                    }
                    else
                    {
                        Console.WriteLine("\nInsufficient Funds - Please Deposit More Money.");
                    }

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
        public void FinishTransaction()
        {
            decimal currentMachineBalance = MachineBalance;

            GiveChange();

            //update machine balance to $0
            MachineBalance = 0;

            //WRITE TO LOG
            string logChangeGiven = $"{timeStamp} GIVE CHANGE: {currentMachineBalance:c2} {MachineBalance:c2}";
            fileLogWriter.WriteLogMessage(logChangeGiven);
        }

        public void GiveChange()
        {
            //return customer change in largest coins possible and print change amount to console 
            int coinChange = (int)(MachineBalance * 100);
            int quarter = coinChange / 25;
            coinChange %= 25;
            int dime = coinChange / 10;
            coinChange %= 10;
            int nickel = coinChange / 5;
            coinChange %= 5;

            //write to user change expected in quarters, nickles, dimes
            Console.WriteLine($"\nAmount of change: {MachineBalance:c2} \nquarters: {quarter} \ndimes: {dime} \nnickels: {nickel}\n");
        }
    }
}
