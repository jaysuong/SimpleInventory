using UnityEngine;
using UnityEngine.UI;

namespace SimpleInventory.Demo {
    /// <summary>
    /// Displays the number of items on the screen
    /// </summary>
    public class ItemCountDisplay : MonoBehaviour {
        public Item itemToCount;
        public Inventory inventory;

        [SerializeField]
        private Text text;


        private void Update () {
            // NOTE: Should update only if the number has changed, 
            // otherwise we'd be throwing garbage every frame
            if (inventory != null) {
                var count = inventory.CountItem (itemToCount);
                text.text = count.ToString ();
            }
        }
    }
}