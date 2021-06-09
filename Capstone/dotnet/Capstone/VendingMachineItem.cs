
namespace Capstone
{
    public class VendingMachineItem
    {
        public string ItemName { get; private set; }

        public decimal ItemCost { get; private set; }

        public string ItemCode { get; private set; }

        public string ItemCategory { get; private set; }

        public int ItemQuantity { get; set; } = 5;


        public VendingMachineItem(string itemName, decimal itemCost, string itemCode, string itemCategory, int itemQuantity)
        {
            ItemName = itemName;
            ItemCost = itemCost;
            ItemCode = itemCode;
            ItemCategory = itemCategory;
            ItemQuantity = itemQuantity;
        }


    }
}