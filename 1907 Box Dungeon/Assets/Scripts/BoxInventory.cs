using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxInventory : Inventory
{

    public Item collapsedBox;
    public GameObject ItemObjectPrefab;
    LootModal lootModal;
    bool placementModeActive;
    public bool invalidPlacementLocation;


    public List<Item> boxInventory = new List<Item>();

    int currentItemNumber;


    private void Awake()
    {
        lootModal = GameObject.FindGameObjectWithTag("LootModal").GetComponent<LootModal>();
        currentItemNumber = 0;
    }


    private void OnMouseOver()
    {
        if (placementModeActive)
        {
            if (Input.GetMouseButtonDown(0) && !invalidPlacementLocation)
            {
                LeavePlacementMode();
            }
        }

        if (!placementModeActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                lootModal.Open(this);
                if (boxInventory.Count > 0)
                {
                    CycleInventory();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("trigger stay");
        this.transform.GetComponent<SpriteRenderer>().color = Color.red;
        invalidPlacementLocation = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.transform.GetComponent<SpriteRenderer>().color = Color.green;
        invalidPlacementLocation = false;
        print("trigger exit");
    }


    private void CycleInventory()
    {
        if (currentItemNumber >= boxInventory.Count)
            currentItemNumber = 0;

        print("BoxInv CycleInventory: " + currentItemNumber);
        lootModal.ShowItem(boxInventory[currentItemNumber]);
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

    public void EnterPlacementMode()
    {
        placementModeActive = true;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        this.GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void LeavePlacementMode()
    {
        placementModeActive = false;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }


}
