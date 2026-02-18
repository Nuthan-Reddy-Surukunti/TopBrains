using System;
using System.Collections.Generic;
using FlexibleInventorySystem.Domain;
using FlexibleInventorySystem.Domain.Exceptions;

namespace FlexibleInventorySystem.Services
{
    public class InventoryManager
    {
        public static SortedDictionary<int, Queue<InventoryItem>> _store = new SortedDictionary<int, Queue<InventoryItem>>();

        /// TODO: Add InventoryItem to the correct priority queue (preserve FIFO). Validate priority &gt; 0.
        public void AddItem(InventoryItem item)
        {
            if(item.PriorityLevel<1) throw new InvalidPriorityException("Invalid priority level");
            if (!_store.ContainsKey(item.PriorityLevel))
            {
                _store[item.PriorityLevel] = new Queue<InventoryItem>();
            }
            _store[item.PriorityLevel].Enqueue(item);
        }

        /// TODO: Return all items sorted by priority (ascending) and FIFO within a priority.
        public IEnumerable<InventoryItem> GetInventoryStatus()
        {
            List<InventoryItem> result = new List<InventoryItem>();
            foreach(var i in _store)
            {
                foreach(var j in i.Value) result.Add(j);
            }
            return result;
        }
        
        /// TODO: Update an item's priority and move it between queues.

        public void UpdatePriority(string itemId, int newPriority)
        {
            if(newPriority<1) throw new InvalidPriorityException("Invalid priority");
            var check = _store.SelectMany(i=>i.Value).FirstOrDefault(g=>g.ItemId==itemId);
            if(check==null) throw new ItemNotFoundException("Item not found");
             _store[check.PriorityLevel].Dequeue();
            check.PriorityLevel=newPriority;
            if (!_store.ContainsKey(newPriority))
            {
                _store[newPriority] = new Queue<InventoryItem>();
            }
            _store[newPriority].Enqueue(check);
            }
    }
}