using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item thisItem;
    PlayerInventory playerInventory;


    private void Awake()
    {
        GameObject playerInventoryObject = GameObject.FindGameObjectWithTag("PlayerInventory");
        playerInventory = playerInventoryObject.GetComponent<PlayerInventory>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
            AddToInventory();
    }

    public void SetUpObject(Item thatItem)
    {
        thisItem = thatItem;
        this.GetComponent<SpriteRenderer>().sprite = thisItem.GetSprite();
    }

    private void AddToInventory()
    {
        if (!playerInventory.inventoryFull)
        {
            playerInventory.AddToInventory(thisItem);
            Destroy(this.transform.gameObject);
        }
    }
}
