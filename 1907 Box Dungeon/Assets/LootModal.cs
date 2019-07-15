using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootModal : MonoBehaviour
{
    public PlayerInventory playerInventory;
    BoxInventory activeContainer;
    Item currentItem;
    public GameObject spriteObject;
    public GameObject menuObject;


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            AddToInventory();
        }
    }


    public void Open()
    {
        menuObject.SetActive(true);
        MoveModal();
    }

    public void Close()
    {
        menuObject.SetActive(false);
    }

    private void MoveModal()
    {
        this.transform.position = activeContainer.transform.position;
    }

    public void ShowItem(BoxInventory inv, Item item)
    {
        print("LootModal - ShowItem");
        activeContainer = inv;
        currentItem = item;
        spriteObject.GetComponent<SpriteRenderer>().sprite = item.GetSprite();
    }

    private void AddToInventory()
    {
        print("LootModal - AddToInventory");
        if (!playerInventory.inventoryFull)
        {
            playerInventory.AddToInventory(currentItem);
            activeContainer.RemoveItem();
        }
    }
}
