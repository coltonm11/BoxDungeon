using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { JUNK, CONTAINER };
[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public string itemName;
    public int maxStackSize;
    public int quantity;
    public Sprite sprite;
    public ItemType type;
    public GameObject containerObjectPrefab;

    private void Awake()
    {
        quantity = 1; 
    }


    public Sprite GetSprite()
    {
        return sprite;
    }

    public ItemType GetItemType()
    {
        return type;
    }

}
