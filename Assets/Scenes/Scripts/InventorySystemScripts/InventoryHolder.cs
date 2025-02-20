using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//The purpose of this script is incase of multiple inventory system on one object
[System.Serializable]

public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;

    public InventorySystem InventorySystem => inventorySystem;

    public static UnityAction<InventorySystem> onDynamicInventoryDisplayRequested;

    private void Awake()
    {
        inventorySystem = new InventorySystem(inventorySize);
    }
}
