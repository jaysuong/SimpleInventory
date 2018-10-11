using UnityEngine;

namespace SimpleInventory.Demo {
    /// <summary>
    /// An item that heals the player
    /// </summary>
    [CreateAssetMenu (menuName = "Simple Inventory/Health Pack")]
    public class HealthPack : Item {
        public float amountToHeal;

        public override void Use (GameObject user) {
            var health = user.GetComponent<Health> ();

            if (health != null) {
                health.hp += amountToHeal;
            }
        }
    }
}