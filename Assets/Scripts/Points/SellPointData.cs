using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu]
public class SellPointData : ScriptableObject
{ 
    private int listSize;
    private int processListSize;
    private bool showRawMaterials;
    private bool showProcessingResults;

    private List<int> priceMaxListRaw = new List<int>();
    private List<int> priceMinListRaw = new List<int>();
    private List<string> nameListRaw = new List<string>();
    private List<ProcessingResult> resultList = new List<ProcessingResult>();

    private List<int> priceMaxList = new List<int>();
    private List<int> priceMinList = new List<int>();
    private List<string> nameList = new List<string>();
    public void ConvertProcessingToSell(ProcessingResult result)
    {
        nameList.Add(result.GetResultName());
        priceMaxList.Add(result.GetPriceMax());
        priceMinList.Add(result.GetPriceMin());
    }
    public void SetData()
    {
        if(nameList.Count > 0)
        {
            return;
        }
        foreach (var item in resultList)
        {
            ConvertProcessingToSell(item);
        }
        for (int i = 0; i < priceMaxListRaw.Count; i++)
        {
            nameList.Add(nameListRaw[i]);
            priceMaxList.Add(priceMaxListRaw[i]);
            priceMinList.Add(priceMinListRaw[i]);
        }
    }
    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(SellPointData)), CanEditMultipleObjects]
    public class SellPointDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {


            base.OnInspectorGUI();
            SellPointData sellPointData = (SellPointData)target;
            EditorGUILayout.Space();
            sellPointData.showRawMaterials = EditorGUILayout.Foldout(sellPointData.showRawMaterials, "Raw Materials", true);
            if (sellPointData.showRawMaterials)
            {
                while (sellPointData.priceMaxListRaw.Count > sellPointData.listSize)
                {
                    sellPointData.priceMaxListRaw.RemoveAt(sellPointData.priceMaxListRaw.Count - 1);
                    sellPointData.priceMinListRaw.RemoveAt(sellPointData.priceMinListRaw.Count - 1);
                    sellPointData.nameListRaw.RemoveAt(sellPointData.nameListRaw.Count - 1);
                }
                while (sellPointData.priceMaxListRaw.Count < sellPointData.listSize)
                {
                    sellPointData.priceMaxListRaw.Add(0);
                    sellPointData.priceMinListRaw.Add(0);
                    sellPointData.nameListRaw.Add("");
                }
                for (int i = 0; i < sellPointData.listSize; i++)
                {
                    DrawSellData(sellPointData, i);
                }
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("+", GUILayout.MaxWidth(20)))
                {
                    sellPointData.listSize++;
                }
                if (GUILayout.Button("-", GUILayout.MaxWidth(20)))
                {
                    sellPointData.listSize--;
                }
                EditorGUILayout.EndHorizontal();
            }
            sellPointData.showProcessingResults = EditorGUILayout.Foldout(sellPointData.showProcessingResults, "Processing Results", true);
            if (sellPointData.showRawMaterials)
            {
                while(sellPointData.resultList.Count > sellPointData.processListSize)
                {
                    sellPointData.resultList.RemoveAt(sellPointData.resultList.Count - 1);
                }
                while (sellPointData.resultList.Count < sellPointData.processListSize)
                {
                    sellPointData.resultList.Add(null);
                }
                EditorGUILayout.BeginVertical();
                for (int i = 0; i < sellPointData.processListSize; i++)
                {
                    sellPointData.resultList[i] = (ProcessingResult)EditorGUILayout.ObjectField(sellPointData.resultList[i], typeof(ProcessingResult), false);
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("+", GUILayout.MaxWidth(20)))
                {
                    sellPointData.processListSize++;
                }
                if (GUILayout.Button("-", GUILayout.MaxWidth(20)))
                {
                    sellPointData.processListSize--;
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        static void DrawSellData(SellPointData sellPointData, int i)
        {
            
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Name", GUILayout.MaxWidth(50));
            sellPointData.nameListRaw[i] = EditorGUILayout.TextField(sellPointData.nameListRaw[i], GUILayout.MaxWidth(200));

            EditorGUILayout.LabelField("PriceMin", GUILayout.MaxWidth(60));
            sellPointData.priceMinListRaw[i] = EditorGUILayout.IntField(sellPointData.priceMinListRaw[i], GUILayout.MaxWidth(30));

            EditorGUILayout.LabelField("PriceMax", GUILayout.MaxWidth(60));
            sellPointData.priceMaxListRaw[i] = EditorGUILayout.IntField(sellPointData.priceMaxListRaw[i], GUILayout.MaxWidth(30));

            EditorGUILayout.EndHorizontal();
        }
    }
#endif
    #endregion
    public List<string> GetNames()
    {
        return nameList;
    }
    public List<int> GetMaxPrices()
    {
        return priceMaxList;
    }
    public List<int> GetMinPrices()
    {
        return priceMinList;
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}
