using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineUnitTests
    {
        VendingMachine vendingMachine = new VendingMachine();
        TestMethods testMethods = new TestMethods();

        [TestMethod]
        public void TestFinishTransactionQuarters()
        {
            string result = $"\nAmount of change: $2.25 \nquarters: 9 \ndimes: 0 \nnickels: 0\n";
       
            decimal currentMachineBalance = 2.25M;
            Assert.AreEqual(result, TestMethods.FinishTransactionTestMethod(currentMachineBalance));
        }

        [TestMethod]
        public void TestFinishTransactionAllDemoninations()
        {
            string result = $"\nAmount of change: $6.40 \nquarters: 25 \ndimes: 1 \nnickels: 1\n";

            decimal currentMachineBalance = 6.40M;
            Assert.AreEqual(result, TestMethods.FinishTransactionTestMethod(currentMachineBalance));
        }

    //    [TestMethod]
    //    public void TestDisplayMainMenuOptionInvalidEntry()
    //    {
    //        string result = "\nYou entered an invalid code, please try again!\n";

    //       string mainMenuSelectionTest = "5";

    //        Assert.AreEqual(result, TestMethods.DisplayMainMenuTestMethod(mainMenuSelectionTest));
    //    }
    }
}
