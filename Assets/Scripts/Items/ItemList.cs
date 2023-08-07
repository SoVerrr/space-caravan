using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField] private List<RawMaterial> rawMaterials;
    [SerializeField] private List<ProcessingResult> processingResults;
    private List<Item> items;

    private void ConvertRawToItems()
    {
        foreach (var material in rawMaterials)
        {
            items.Add(new Item(material));
        }
    }
    private void ConvertProcessingToItems()
    {
        foreach (var processing in processingResults)
        {
            items.Add(new Item(processing));
        }
    }
    public void InitializeItemList()
    {
        ConvertRawToItems();
        ConvertProcessingToItems();
    }
}