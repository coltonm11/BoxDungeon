using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LootModal : MonoBehaviour, IPointerClickHandler
{
    public PlayerInventory playerInventory;
    BoxInventory activeContainer;
    Item currentItem;
    public GameObject spriteObject;
    public GameObject menuObject;
    public GameObject CollapseButtonObject;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (activeContainer.boxInventory.Count > 0)
                AddToInventory();
        }
    }


    public void Open(BoxInventory inv)
    {
        activeContainer = inv;
        menuObject.SetActive(true);
        MoveModal();

        if (activeContainer.boxInventory.Count > 0)
            CollapseButtonObject.SetActive(false);
    }

    public void Close()
    {
        menuObject.SetActive(false);
    }

    private void MoveModal()
    {
        Vector3 containerPos = activeContainer.transform.position;
        this.transform.position = Camera.main.WorldToScreenPoint(containerPos);
    }

    public void ShowItem(Item item)
    {
        if (item != null)
        {
            currentItem = item;
            spriteObject.GetComponent<Image>().sprite = item.GetSprite();
        }
        if (item = null)
        {

        }

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

    public void MakeCollapsable()
    {
        CollapseButtonObject.SetActive(true);
    }

    public void CollapseContainer()
    {
        activeContainer.CollapseBox();
        Close();
    }

}
