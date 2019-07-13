using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    public GameObject[] inventorySlotObject = new GameObject[10];

    public void AddToInventory(Item item)
    {
        if (inventory.Count > 10)
        {
            inventory.Add(item);
            UpdateInventory();
        }
        else if (inventory.Count >= 10)
        {
            print("inventory full");
        }

    }

    void UpdateInventory()
    {
        for (int i = 0; i == inventory.Count; i++)
        {
            inventorySlotObject[i].GetComponent<SpriteRenderer>().sprite = inventory[i].GetSprite();
        }
    }

}
