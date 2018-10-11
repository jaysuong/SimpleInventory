using UnityEditor;
using UnityEngine;

namespace SimpleInventory.Editor {
    /// <summary>
    /// Overrides the default inventory dropdowns to avoid unnecessary clicks
    /// </summary>
    [CustomPropertyDrawer (typeof (Inventory.ItemSlot))]
    public class SlotPropertyDrawer : PropertyDrawer {

        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty (position, label, property);

            var itemRect = new Rect (position.x, position.y, position.width * 0.75f, EditorGUIUtility.singleLineHeight);
            var countRect = new Rect (position.x + position.width * 0.75f, position.y, position.width * 0.25f, EditorGUIUtility.singleLineHeight);

            // NOTE: If the field names are changed, change the string names or the gui will break
            EditorGUI.PropertyField (itemRect, property.FindPropertyRelative ("item"), GUIContent.none, false);
            EditorGUI.PropertyField (countRect, property.FindPropertyRelative ("count"), GUIContent.none, false);

            EditorGUI.EndProperty ();
        }
    }
}