using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInventory : MonoBehaviour
{

    public GameObject boxInventoryModal;
    public GameObject ModalSpriteObject;
    Sprite modalSprite;
    SpriteRenderer modalSpriteRenderer;
    Image modalImage; 

    public Item[] boxInventory;

    int itemNumber;

    private void Start()
    {
        modalSprite = ModalSpriteObject.GetComponent<Sprite>();
        modalSpriteRenderer = ModalSpriteObject.GetComponent<SpriteRenderer>();
        modalImage = ModalSpriteObject.GetComponent<Image>();
        itemNumber = 0;
    }

    private void OnMouseDown()
    {
        boxInventoryModal.SetActive(true);
        CycleInventory();
    }

    private void CycleInventory()
    {
        //modalSprite = boxInventory[itemNumber].GetSprite();
        //modalSpriteRenderer.sprite = boxInventory[itemNumber].GetSprite();
        modalImage.sprite = boxInventory[itemNumber].GetSprite();
        itemNumber += 1;
        print("cycled inventory");
    }

}
