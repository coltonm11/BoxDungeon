using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HotbarSlot : MonoBehaviour, IPointerClickHandler
{
    public int slotNumber;
    Image image;

    GroundPlacementController placementController;

    PlayerInventory playerInventory;
    Item currentItem;
    ItemType type;

    private void Start()
    {
        GameObject pInvTemporary;
        pInvTemporary = GameObject.FindGameObjectWithTag("PlayerInventory");
        playerInventory = pInvTemporary.GetComponent<PlayerInventory>();
        image = this.GetComponent<Image>();
        placementController = GameObject.FindGameObjectWithTag("DM").GetComponent<GroundPlacementController>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Use();
        }
    }


    public void RecieveItem(Item item)
    {
        currentItem = item;
        image.sprite = item.GetSprite();
        type = item.GetItemType();
    }

    private void Use()
    {
        switch (type)
        {
            case ItemType.CONTAINER:
                placementController.PlaceContainer(currentItem.containerObjectPrefab);
                playerInventory.RemoveItem(slotNumber);
                break;
            case ItemType.JUNK:
                break;
        }
    }
}
