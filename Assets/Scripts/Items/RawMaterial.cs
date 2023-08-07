using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/RawMaterial")]
public class RawMaterial : ScriptableObject
{
    [SerializeField] public string materialName;
    [SerializeField] public string itemID;
    [SerializeField] public int maxPrice;
    [SerializeField] public int minPrice;
}
