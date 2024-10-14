using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public TileBase tile;
    public Sprite sprite;
    public Vector2Int range = new Vector2Int(5, 4);
    public bool stackable = true;
    public Sprite image;
}


