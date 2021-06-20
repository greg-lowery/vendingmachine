
namespace Capstone
{
    public class VendingMachineItem
    {
        public string ItemName { get; private set; }

        public decimal ItemCost { get; private set; }

        public string ItemCategory { get; private set; }

        public int ItemQuantity { get; set; }

        // abstract method for itemSound that inherits from base class VendingMachineItem??

        public VendingMachineItem(string itemName, decimal itemCost, string itemCategory, int itemQuantity)
        {
            ItemName = itemName;
            ItemCost = itemCost;
            ItemCategory = itemCategory;
            ItemQuantity = itemQuantity;
        }


    }
}