using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInventory : Inventory
{

    public GameObject lootModalObject;
    public Item collapsedBox;
    public GameObject ItemObjectPrefab;
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
            if (boxInventory.Count > 0)
            {
                CycleInventory();
                lootModal.Open();
            }
        }
    }


    private void CycleInventory()
    {
        if (currentItemNumber >= boxInventory.Count)
            currentItemNumber = 0;

        print("BoxInv CycleInventory: " + currentItemNumber);
        lootModal.ShowItem(this, boxInventory[currentItemNumber]);
        currentItemNumber += 1;     
    }

    public void RemoveItem()
    {
        print("BoxInv RemoveItem");
        currentItemNumber -= 1;
        boxInventory.RemoveAt(currentItemNumber);

        if (boxInventory.Count < 1)
            lootModal.MakeCollapsable();

        CycleInventory();
    }

    public void CollapseBox()
    {
        GameObject newObj = Instantiate(ItemObjectPrefab, this.transform.position, this.transform.rotation);
        newObj.GetComponent<ItemObject>().SetUpObject(collapsedBox);
        Destroy(this.transform.gameObject);
    }

}
