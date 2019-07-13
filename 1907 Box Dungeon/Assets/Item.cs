using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public Sprite sprite;

    public Sprite GetSprite()
    {
        return sprite;
    }
}
