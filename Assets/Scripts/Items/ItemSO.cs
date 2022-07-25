using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item Manager/New Item")]
public class ItemSO : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;
    public string itemCategory;
    public string itemTrivia;
    public bool isFilipino;
}
