using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleInventory {
    /// <summary>
    /// Defines how the pickup will apply the effect
    /// </summary>
    public enum PickupEffectType {
        Add,            // Adds an item to the inventory
        InventoryUse,   // Uses an item from the inventory (can consume quantities)
        ApplyEffect         // Automatically applies an effect on the user
    }

    /// <summary>
    /// Applies an inventory item to a gameobject containing the inventory script, if the gameobject
    /// enters its sphere of influence
    /// </summary>
    public class PickupTrigger : MonoBehaviour {

        [SerializeField]
        private PickupEffectType effectType;
        [SerializeField]
        private Item pickupItem;
        [SerializeField]
        private int quantity;
        [SerializeField]
        private string[] tagsToDetect = new string[] { "Player" };


        private HashSet<string> tags;


        private void Awake () {
            tags = new HashSet<string> (tagsToDetect);
        }

        /// <summary>
        /// Unity callback for trigger collisions
        /// </summary>
        private void OnTriggerEnter (Collider other) {
            if (tags.Contains (other.tag)) {
                var inventory = other.GetComponentInParent<Inventory> ();

                // If the inventory exists, apply the effect
                if (inventory != null) {
                    ApplyPickupEffect (inventory, effectType, pickupItem, quantity);
                }
            }
        }

        /// <summary>
        /// Applies a pickup effect on the inventory, whether it is simply adding/removing items or applying
        /// a "use" effect
        /// </summary>
        private void ApplyPickupEffect (Inventory inventory, PickupEffectType effectType, Item item, int amount) {
            switch (effectType) {
                case PickupEffectType.Add:
                    inventory.AddItem (item, amount);
                    break;

                case PickupEffectType.InventoryUse:
                    inventory.UseItem (item, inventory.gameObject, amount);
                    break;

                case PickupEffectType.ApplyEffect:
                    item.Use (inventory.gameObject);
                    break;
            }
        }
    }
}