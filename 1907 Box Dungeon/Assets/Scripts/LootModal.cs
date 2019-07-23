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
    bool isOpen;

    // -------------------------------------------------------------

    public PlayerInventory playerInventory;
    public GameObject spriteObject;
    public GameObject menuObject;
    public GameObject breakDownButtonObject;
    public GameObject textPageObject;
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
        if (inv != activeContainer)
            Close();

        activeContainer = inv;
        type = activeContainer.type;
        containerInventory = activeContainer.boxInventory;
        //
        MoveModal();
        ResizeModal();
        ShowItem();
        //
        isOpen = true;
        menuObject.SetActive(true);
        //
        if (containerInventory.Count <= 0)
            MakeCollapsable();
        if (containerInventory.Count > 0)
            breakDownButtonObject.SetActive(false);
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

        slots[0].SetActive(true);

        for (int i = 0; i < activeContainer.slotsShown; i++)
        {
            slots[i].SetActive(true);
        }

        RectTransform bg = menuObject.GetComponent<RectTransform>();
        float modalWidth = 110f * activeContainer.slotsPerRow;
        float modalHeight = 100f + (110 * Mathf.Ceil(activeContainer.slotsShown / activeContainer.slotsPerRow));
        if (modalWidth < 250)
            modalWidth = 250;
       if (modalHeight < 220)
            modalHeight = 220;
        bg.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, modalWidth);
        bg.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, modalHeight);
    }

    public void ShowItem()
    {
        switch (type)
        {
            case ContainerType.CARDBOARD:

                // Cycle int
                if (currentItemNumber >= containerInventory.Count)
                    currentItemNumber = 0;

                Image image = slots[0].transform.GetChild(0).GetComponent<Image>();
                Sprite currentSprite = null;

                // if not empty
                if (containerInventory.Count > 0)
                    currentSprite = containerInventory[currentItemNumber].GetSprite();

                image.sprite = currentSprite;

                currentItemNumber += 1;

                UpdateText();

                break;

            case ContainerType.SHELVES:

                break;
        }

    }

    private void UpdateText()
    {
        Text text = textPageObject.GetComponent<Text>();
        int firstNumber = currentItemNumber;
        string myString = firstNumber.ToString() + " of " + containerInventory.Count.ToString();

        if (containerInventory.Count <= 0)
            myString = "empty";

        text.text = myString;
    }
    public void Close()
    {
        menuObject.SetActive(false);
        currentItemNumber = 0;
        isOpen = false;
    }

    // -------------------------------------------------------------

    public void AddToInventory()
    {
        if (!playerInventory.inventoryFull)
        {
            currentItemNumber -= 1;
            playerInventory.AddToInventory(containerInventory[currentItemNumber]);
            activeContainer.RemoveItem(currentItemNumber);

            if (containerInventory.Count < 1)
                MakeCollapsable();
            print("current item number: " + currentItemNumber);
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
