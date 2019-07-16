using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public string itemName;
    public int maxStackSize;
    public int quantity;
    public Sprite sprite;

    private void Awake()
    {
        quantity = 1;
    }


    public Sprite GetSprite()
    {
        return sprite;
    }
}
