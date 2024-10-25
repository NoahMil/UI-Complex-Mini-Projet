using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public Sprite image;
}

public enum ItemType
{
    Weapon,
    Scarf,
    Ring,
    Headband,
    Cloak,
    Bracelet
}

