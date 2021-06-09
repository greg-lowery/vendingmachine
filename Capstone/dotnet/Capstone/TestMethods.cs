
namespace Capstone
{
    public class TestMethods
    {


        public static string FinishTransactionTestMethod(decimal currentMachineBalanceTest)
        {

            //return customer change in largest coins possible and print change amount to console 
            int coinChange = (int)(currentMachineBalanceTest * 100);
            int quarter = coinChange / 25;
            coinChange %= 25;
            int dime = coinChange / 10;
            coinChange %= 10;
            int nickel = coinChange / 5;
            coinChange %= 5;

            //write to user change expected in quarters, nickles, dimes
            return $"\nAmount of change: {currentMachineBalanceTest:c2} \nquarters: {quarter} \ndimes: {dime} \nnickels: {nickel}\n";

        }

        
            //below is an attempt to test the do/while loop - how can you test a loop such as this Joe?
        //public static string DisplayMainMenuTestMethod(string mainMenuSelectionTest)
        //{
        //    string testReturn = "";
        //    do
        //    {
        //        //display main menu options for user to select
        //        Console.WriteLine("(1) Display Vending Machine Items \n(2) Purchase \n(3) Exit");
        //        mainMenuSelectionTest = Console.ReadLine();

        //        //handle invalid user input
        //        if (mainMenuSelectionTest != "1" && mainMenuSelectionTest != "2" && mainMenuSelectionTest != "3")
        //        {
        //            testReturn = ("\nYou entered an invalid code, please try again!\n");
        //        }

        //        //menu selection "1" to display full inventory to user 
        //        if (mainMenuSelectionTest == "1")
        //        {

        //            testReturn = ("*INVENTORY READOUT*\n Press any key to return to main menu: ");
                   
        //        }
        //        //menu selection "2" to take user to purchasing menu
        //        if (mainMenuSelectionTest == "2")
        //        {
        //            testReturn = ("*PURCHASE MENU READOUT*");
        //        }
        //        //menu selection "3" to leave program
        //        if (mainMenuSelectionTest == "3")
        //        {
        //            break;
                    
        //        }
        //        //TODO: PRINT SALES REPORT
        //        //if (mainMenuSelection = 4)
        //        return testReturn;
        //    } while (mainMenuSelectionTest != "3");
        //}
    }
}
