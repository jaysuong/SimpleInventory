using UnityEngine;
using System;

namespace SimpleInventory {
    /// <summary>
    /// A collection of items
    /// </summary>
    public class Inventory : MonoBehaviour {
        /// <summary>
        /// A collection of slots containing an item and a name.
        /// Note: If the item is null, then the slot is empty
        /// </summary>
        public ItemSlot[] slots;


        [Serializable]
        public struct ItemSlot {
            public Item item;
            public int count;
        }

        /// <summary>
        /// Adds an item into the inventory
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <param name="amount">The quantity of the item to add</param>
        public void AddItem (Item item, int amount) {
            var itemIndex = FindItemIndex (item, ref slots);

            if (itemIndex != -1) {
                var slot = slots[itemIndex];
                slot.count += amount;
                slots[itemIndex] = slot;
            } else {
                // If no such item exist, find an empty slot and 
                // insert the item there
                for (var i = 0; i < slots.Length; ++i) {
                    if (slots[i].item == null) {
                        slots[i] = new ItemSlot {
                            item = item,
                            count = amount
                        };

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the quantity of a particular item in the inventory
        /// </summary>
        /// <param name="item">The item to count</param>
        /// <returns>0 if no such item exists</returns>
        public int CountItem (Item item) {
            var itemIndex = FindItemIndex (item, ref slots);
            if (itemIndex != -1) {
                return slots[itemIndex].count;
            }

            return 0;
        }

        /// <summary>
        /// Removes an item from the inventory. If the slot's amount is zero, then
        /// the item's slot will be nuked.
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <param name="amount">The quantity to remove</param>
        public void RemoveItem (Item item, int amount) {
            var itemIndex = FindItemIndex (item, ref slots);

            if (itemIndex != -1) {
                var slot = slots[itemIndex];
                slot.count -= amount;

                // If the remaining quantity is 0, then the slot is empty
                if (slot.count <= 0) {
                    slot = new ItemSlot ();
                }

                slots[itemIndex] = slot;
            }
        }

        /// <summary>
        /// Attempts to use an item if it exists in the inventory
        /// </summary>
        /// <param name="item">The item to use</param>
        /// <param name="user">The current user</param>
        /// <param name="consumeAmount">The amount to consume (If the consumption is greater than the current amount, then it will not be used)</param>
        public void UseItem (Item item, GameObject user, int consumeAmount = 0) {
            var itemIndex = FindItemIndex (item, ref slots);

            if (itemIndex != -1) {
                var slot = slots[itemIndex];
                if (slot.count >= consumeAmount) {
                    item.Use (user);
                    RemoveItem (item, consumeAmount);
                }
            }
        }

        /// <summary>
        /// Finds the index of an item in a slot array.
        /// Note: We can map the item to an index via a dictionary for faster lookup
        /// </summary>
        /// <param name="item">The item to search</param>
        /// <param name="slots">The inventory slots</param>
        /// <returns>-1 if no such item exist</returns>
        private int FindItemIndex (Item item, ref ItemSlot[] slots) {
            for (var i = 0; i < slots.Length; ++i) {
                if (slots[i].item == item) {
                    return i;
                }
            }

            return -1;
        }

    }
}