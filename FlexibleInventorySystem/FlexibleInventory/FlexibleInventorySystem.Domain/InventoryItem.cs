using System;

namespace FlexibleInventorySystem.Domain
{
    public class InventoryItem
    {
        // TODO: 
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int PriorityLevel { get; set; }
        public InventoryItem(string itemID,string itemName, int priorityLevel)
        {
            ItemId=itemID;
            ItemName=itemName;
            PriorityLevel=priorityLevel;
        }

        public override string ToString()
        {
            return $"{ItemId} {ItemName} {PriorityLevel}";
        }
    }
}