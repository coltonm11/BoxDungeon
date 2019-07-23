using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContainerType { CARDBOARD, SHELVES }

public class BoxInventory : Inventory
{

    public List<Item> boxInventory = new List<Item>();
    public ContainerType type;
    public float slotsShown;
    public float slotsPerRow;

    // -------------------------------------------------------------

    public Item collapsedBox;
    public GameObject ItemObjectPrefab;

    // -------------------------------------------------------------

    LootModal lootModal;
    bool placementModeActive;
    public bool invalidPlacementLocation;
    int currentItemNumber;

    // -------------------------------------------------------------

    private void Awake()
    {
        lootModal = GameObject.FindGameObjectWithTag("LootModal").GetComponent<LootModal>();
        currentItemNumber = 0;
    }

    private void OnMouseOver()
    {
        if (placementModeActive)
        {
            if (!invalidPlacementLocation)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    LeavePlacementMode();
                }
            }
        }

        if (!placementModeActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                switch (type)
                {
                    case ContainerType.CARDBOARD:
                        lootModal.Open(this);
                        break;
                    case ContainerType.SHELVES:
                        lootModal.Open(this);
                        break;
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

    // -------------------------------------------------------------

    public void RemoveItem(int itemNumber)
    {
        boxInventory.RemoveAt(itemNumber);
    }

    public void CollapseBox()
    {
        GameObject newObj = Instantiate(ItemObjectPrefab, this.transform.position, this.transform.rotation);
        newObj.GetComponent<ItemObject>().SetUpObject(collapsedBox);
        Destroy(this.transform.gameObject);
    }

    // -------------------------------------------------------------

    public void EnterPlacementMode()
    {
        placementModeActive = true;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        this.transform.GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void LeavePlacementMode()
    {
        placementModeActive = false;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        this.transform.GetComponent<SpriteRenderer>().color = Color.white;
    }


}
