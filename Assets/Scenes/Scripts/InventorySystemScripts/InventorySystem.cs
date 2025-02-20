using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem 
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    private int inventorySize;

    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);
        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    //Not finished-need to check other conditions
    public bool AddToInventory(InventoryItem itemToAdd, int amountToAdd)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot))// check whether item exist in the inventory, we do it with a list
                                                                     // incase we have multiple stacks of the same item
        {
            foreach(var slot in invSlot)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                    
                }// if we add the current amount of items will it fit?
            }
           
        }
        else if(HasFreeSlot(out InventorySlot freeSlot))// Gets the first available slot if item don't already exist in the inventory
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
        

    }

    public bool ContainsItem(InventoryItem itemToAdd, out List<InventorySlot> invSlot)
    {
        invSlot = InventorySlots.Where(i=>i.ItemData == itemToAdd).ToList();
        
        return invSlot == null ? true: false; //if the inventory slot has a number greater than 1 with the same item data
                                               //then it contains the item
    }

    public bool HasFreeSlot(out InventorySlot freeSlot) 
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null); //if the slot is empty then it's a free slot
        return freeSlot == null ? false: true;
    }
    

}
