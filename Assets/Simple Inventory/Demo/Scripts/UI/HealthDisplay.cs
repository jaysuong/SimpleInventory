using UnityEngine;
using UnityEngine.UI;

namespace SimpleInventory.Demo {
    /// <summary>
    /// Displays the health on the screen
    /// </summary>
    public class HealthDisplay : MonoBehaviour {
        public Health health;

        [SerializeField]
        private Text text;


        private void Update () {
            if (health != null) {
                text.text = health.hp.ToString ();
            }
        }
    }
}