using UnityEngine;

namespace SimpleInventory {
    /// <summary>
    /// Represents an item that can be pickable or usable
    /// </summary>
    [CreateAssetMenu (menuName = "Simple Inventory/Item")]
    public class Item : ScriptableObject {
        /// <summary>
        /// The item's type
        /// </summary>
        public ItemType type;


        public virtual void Use (GameObject user) { }
    }
}