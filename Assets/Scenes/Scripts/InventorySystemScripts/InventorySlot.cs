using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot 
{
    [SerializeField] private InventoryItem itemData;
    [SerializeField] private int stackSize;

    public InventoryItem ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(InventoryItem source, int amount)
    {
        this.itemData = source;
        this.stackSize = amount;
    }

    //initalize empty inventory
    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlot(InventoryItem data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }


    // Check the stacking of items and put the leftovers on the mouse when maxSize is reached
    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = itemData.MaxStack - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    // Check if the slot reach the maxStack or not
    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.MaxStack) return true;
        else return false;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount) 
    { 
        stackSize -= amount; 
    }

}
