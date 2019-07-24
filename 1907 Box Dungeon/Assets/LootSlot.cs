using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LootSlot : MonoBehaviour, IPointerClickHandler
{

    LootModal lootModal;

    public int slotNumber;

    // -------------------------------------------------------------

    private void Awake()
    {
        lootModal = this.transform.parent.parent.parent.GetComponent<LootModal>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            lootModal.AddToInventory(slotNumber);
        }
    }

}
