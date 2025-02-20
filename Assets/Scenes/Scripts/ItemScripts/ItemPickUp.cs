using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public InventoryItem ItemData;

    private CircleCollider2D myCollider;

    private void Awake()
    {
        myCollider = GetComponent<CircleCollider2D>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // if the object it collided with has a inventory Holder return true
        var inventory = collider.transform.GetComponent<InventoryHolder>();

        if(!inventory) return;

        if (inventory.InventorySystem.AddToInventory(ItemData, 1))
        {
            //If successfully added to the inventory
            Destroy(this.gameObject);
        }
    }
    
}
