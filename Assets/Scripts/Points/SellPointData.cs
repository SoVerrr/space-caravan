using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class SellPointData : MonoBehaviour
{
    private string sellName;
    private int priceMax;
    private int priceMin;
    private int listSize;
    private int processListSize;
    private bool showRawMaterials;
    private bool showProcessingResults;

    private List<int> priceMaxList = new List<int>();
    private List<int> priceMinList = new List<int>();
    private List<string> nameList = new List<string>();
    private List<ProcessingResult> resultList = new List<ProcessingResult>();
    public void ConvertProcessingToSell(ProcessingResult result)
    {
        sellName = result.GetResultName();
        priceMax = result.GetPriceMax();
        priceMin = result.GetPriceMin();
    }
    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(SellPointData)), CanEditMultipleObjects]
    public class SellPointDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SellPointData sellPointData = (SellPointData)target;
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            sellPointData.showRawMaterials = EditorGUILayout.Foldout(sellPointData.showRawMaterials, "Raw Materials", true);
            if (sellPointData.showRawMaterials)
            {
                while (sellPointData.priceMaxList.Count > sellPointData.listSize)
                {
                    sellPointData.priceMaxList.RemoveAt(sellPointData.priceMaxList.Count - 1);
                    sellPointData.priceMinList.RemoveAt(sellPointData.priceMinList.Count - 1);
                    sellPointData.nameList.RemoveAt(sellPointData.nameList.Count - 1);
                }
                while (sellPointData.priceMaxList.Count < sellPointData.listSize)
                {
                    sellPointData.priceMaxList.Add(0);
                    sellPointData.priceMinList.Add(0);
                    sellPointData.nameList.Add(null);
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
            sellPointData.nameList[i] = EditorGUILayout.TextField(sellPointData.nameList[i], GUILayout.MaxWidth(200));

            EditorGUILayout.LabelField("PriceMin", GUILayout.MaxWidth(60));
            sellPointData.priceMinList[i] = EditorGUILayout.IntField(sellPointData.priceMinList[i], GUILayout.MaxWidth(30));

            EditorGUILayout.LabelField("PriceMax", GUILayout.MaxWidth(60));
            sellPointData.priceMaxList[i] = EditorGUILayout.IntField(sellPointData.priceMaxList[i], GUILayout.MaxWidth(30));

            EditorGUILayout.EndHorizontal();
        }
    }
#endif
    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
