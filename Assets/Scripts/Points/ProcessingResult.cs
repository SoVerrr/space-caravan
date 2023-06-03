using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProcessingResult : ScriptableObject
{
    [SerializeField] string resultName;
    [SerializeField] string[] materialsNeeded;
    [SerializeField] int[] numberOfMaterialsNeeded;
}
