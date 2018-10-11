using UnityEngine;

namespace SimpleInventory.Demo {
    /// <summary>
    /// A simple controller for moving the player
    /// </summary>
    [RequireComponent (typeof (CharacterController))]
    public class PlayerController : MonoBehaviour {
        [SerializeField]
        private float speed = 1;

        private CharacterController controller;

        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";


        private void Awake () {
            controller = GetComponent<CharacterController> ();
        }


        private void Update () {
            var xAxis = Input.GetAxis (HorizontalAxis);
            var yAxis = Input.GetAxis (VerticalAxis);

            var moveSpeed = speed * Time.deltaTime;
            var moveVector = new Vector3 (xAxis * moveSpeed, 0f, yAxis * moveSpeed);

            controller.Move (moveVector);
        }
    }
}