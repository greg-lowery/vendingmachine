
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
    }
}
