# Simple Inventory

A barebones implementation of an inventory system in Unity using Scriptable Objects. 

## Notes
* Create a new item by right-clicking the Project window and select `Create/Simple Inventory/Item` and edit its properties.
  * Since each item is unique, we can treat them as "ids"
  * Items have an overridable function called `Use(GameObject user)` to apply effects, like healing
* The `Inventory` script stores items in slots with a corresponding quantity field
    * Slots with a `null` Item reference can be treated as empty slots
* The `PickupTrigger` script applies one of the following effects if the player walks into it:
    * `Add`: Adds/Removes an item from the inventory
    * `InventoryUse`: Applies an item effect while consuming a specified quantity
    * `ApplyEffect`: Immediately applies an effect to the player
* Example effects are found in the **Sample Inventory** scene
    * WSAD to move
* All scripts are in the following namespaces:
    * `SimpleInventory`
    * `SimpleInventory.Demo`


## Requirements

* Unity 2018.2 or higher (possible to use 2018.0 and up as well)