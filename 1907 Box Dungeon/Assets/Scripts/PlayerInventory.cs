using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public bool inventoryFull;

    public List<Item> inventory = new List<Item>();

    public GameObject[] inventorySlotObject = new GameObject[10];

    private void Start()
    {
        inventoryFull = false;
    }

    public void AddToInventory(Item item)
    {
        if (inventory.Count < 10)
        {
            if (!CheckForDuplicates(item))
            {
                inventory.Add(item);
                UpdateInventory();
            }
        }
        else if (inventory.Count >= 10)
        {
            inventoryFull = true;
        }
    }

    private bool CheckForDuplicates(Item item)
    {
        print("CheckForDupes");
        bool b = false;

        for (int i = 0; i < inventory.Count; i++)
        {
            if (item.itemName == inventory[i].itemName)
            {
                if (inventory[i].quantity < inventory[i].maxStackSize)
                {
                    inventory[i].quantity += 1;
                    i = inventory.Count;
                    b = true;
                }
            }

        }

        return b;
    }

    void UpdateInventory()
    {
        print(inventory.Count);
        for (int i = 0; i < inventory.Count; i++)
        {
            print("{ PINV } Update Inventory");
            inventorySlotObject[i].GetComponent<Image>().sprite = inventory[i].GetSprite();
        }
    }

}
