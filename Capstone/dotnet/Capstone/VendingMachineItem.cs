using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    class VendingMachineItem
    {
        public string ItemName { get; private set; }

        public decimal ItemCost { get; private set; }

        public string ItemCode { get; private set; }

        public string ItemCategory { get; private set; }

        public int ItemQuantity { get; private set; } = 5;


        public VendingMachineItem(string itemName, decimal itemCost, string itemCode, string itemCategory)
        {
            ItemName = itemName;
            ItemCost = itemCost;
            ItemCode = itemCode;
            ItemCategory = itemCategory;

        }


    }
}