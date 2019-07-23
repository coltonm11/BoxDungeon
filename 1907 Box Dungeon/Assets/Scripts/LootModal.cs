using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LootModal : MonoBehaviour, IPointerClickHandler
{

    BoxInventory activeContainer;
    ContainerType type;
    List<Item> containerInventory;
    Item currentItem;
    int currentItemNumber;

    // -------------------------------------------------------------

    public PlayerInventory playerInventory;
    public GameObject spriteObject;
    public GameObject menuObject;
    public GameObject breakDownButtonObject;
    public GameObject[] slots;

    // -------------------------------------------------------------

    public void Awake()
    {
        currentItemNumber = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (activeContainer.boxInventory.Count > 0)
                AddToInventory();
        }
    }

    // -------------------------------------------------------------

    public void Open(BoxInventory inv)
    {
        activeContainer = inv;
        type = activeContainer.type;
        containerInventory = activeContainer.boxInventory;
        //
        MoveModal();
        ResizeModal();
        ShowItem();
        //
        menuObject.SetActive(true);
        //
        if (containerInventory.Count <= 0)
            MakeCollapsable();
    }

    private void MoveModal()
    {
        Vector3 containerPos = activeContainer.transform.position;
        this.transform.position = Camera.main.WorldToScreenPoint(containerPos);
    }

    private void ResizeModal()
    {
        foreach(GameObject s in slots)
        {
            s.SetActive(false);
        }

        for (int i = 0; i < activeContainer.slotsShown; i++)
        {
            slots[i].SetActive(true);
        }

        RectTransform bg = menuObject.GetComponent<RectTransform>();
        float modalWidth = 100f * activeContainer.slotsPerRow;
        float modalHeight = 100f + (100 * Mathf.Ceil(activeContainer.slotsShown / 3));
        if (modalWidth < 250)
            modalWidth = 250;
        bg.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, modalWidth);
        bg.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, modalHeight);
    }

    public void Close()
    {
        menuObject.SetActive(false);
        currentItemNumber = 0;
    }

    // -------------------------------------------------------------

    public void ShowItem()
    {
        switch (type)
        {
            case ContainerType.CARDBOARD:

                if (currentItemNumber >= containerInventory.Count)
                    currentItemNumber = 0;

                Image image = slots[0].transform.GetChild(0).GetComponent<Image>();
                Sprite currentSprite = containerInventory[currentItemNumber].GetSprite();
                image.sprite = currentSprite;

                currentItemNumber += 1;

                break;

            case ContainerType.SHELVES:

                break;
        }

    }

    public void AddToInventory()
    {
        if (!playerInventory.inventoryFull)
        {
            currentItemNumber -= 1;
            playerInventory.AddToInventory(containerInventory[currentItemNumber]);
            activeContainer.RemoveItem(currentItemNumber);

            if (containerInventory.Count < 1)
                MakeCollapsable();

            ShowItem();
        }
    }

    public void MakeCollapsable()
    {
        breakDownButtonObject.SetActive(true);
    }

    public void CollapseContainer()
    {
        activeContainer.CollapseBox();
        Close();
    }

}
