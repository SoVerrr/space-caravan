using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu]
[System.Serializable]
public class SellPointData : ScriptableObject
{ 
    private int listSize;
    private int processListSize;
    private bool showRawMaterials;
    private bool showProcessingResults;

    [HideInInspector][SerializeField] List<int> priceMaxArr;
    [HideInInspector][SerializeField] List<int> priceMinArr;
    [HideInInspector][SerializeField] List<string> nameArr;
    [HideInInspector][SerializeField] ProcessingResult[] processArr;

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
        foreach (var item in processArr)
        {
            ConvertProcessingToSell(item);
        }
        for (int i = 0; i < priceMaxArr.Count; i++)
        {
            nameList.Add(nameArr[i]);
            priceMaxList.Add(priceMaxArr[i]);
            priceMinList.Add(priceMinArr[i]);
        }
    }
    #region Editor
#if UNITY_EDITOR
    [System.Serializable]
    [CustomEditor(typeof(SellPointData)), CanEditMultipleObjects]
    public class SellPointDataEditor : Editor
    {
        SerializedProperty priceMax;
        SerializedProperty priceMin;
        SerializedProperty materialName;
        SerializedProperty processingResult;

        bool showMaterials;
        bool showProcessing;

        private void OnEnable()
        {
            priceMax = serializedObject.FindProperty(nameof(priceMaxArr));
            priceMin = serializedObject.FindProperty(nameof(priceMinArr));
            materialName = serializedObject.FindProperty(nameof(nameArr));
            processingResult = serializedObject.FindProperty(nameof(processArr));
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();
            showMaterials = EditorGUILayout.Foldout(showMaterials, "Raw Materials");
            if (showMaterials)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(materialName, GUILayout.Width(200));
                EditorGUILayout.PropertyField(priceMin, GUILayout.Width(200));
                EditorGUILayout.PropertyField(priceMax);
                EditorGUILayout.EndHorizontal();
            }
            showProcessing = EditorGUILayout.Foldout(showProcessing, "Processing results");
            if (showProcessing)
            {
                EditorGUILayout.PropertyField(processingResult, GUILayout.Width(200));
            }
            UpdateListSizes();
            serializedObject.ApplyModifiedProperties();
        }
        private void UpdateListSizes()
        {
            if(materialName.arraySize > priceMin.arraySize || materialName.arraySize < priceMin.arraySize)
            {
                priceMin.arraySize = materialName.arraySize;
            }
            if(materialName.arraySize > priceMax.arraySize || materialName.arraySize < priceMax.arraySize)
            {
                priceMax.arraySize = materialName.arraySize;
            }
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
