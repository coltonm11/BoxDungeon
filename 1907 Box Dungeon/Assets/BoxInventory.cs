using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInventory : Inventory
{

    public GameObject lootModalObject;
    LootModal lootModal;

    public List<Item> boxInventory = new List<Item>();

    int currentItemNumber;


    private void Start()
    {
        lootModal = lootModalObject.GetComponent<LootModal>();
        currentItemNumber = 0;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CycleInventory();
            lootModal.Open();
            print("BoxInv mouse down recieved");
        }
    }


    private void CycleInventory()
    {
        if (currentItemNumber >= boxInventory.Count)
            currentItemNumber = 0;

        print("BoxInv CycleInventory");
        lootModal.ShowItem(this, boxInventory[currentItemNumber]);
        currentItemNumber += 1;     
    }

    public void RemoveItem()
    {
        print("BoxInv RemoveItem");
        currentItemNumber -= 1;
        boxInventory.RemoveAt(currentItemNumber);

        if (boxInventory.Count < 1)
        {
            lootModal.Close();
        }

        CycleInventory();
    }

}
