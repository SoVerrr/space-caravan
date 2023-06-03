using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingResult : ScriptableObject
{
    [SerializeField] string[] materialsNeeded;
    [SerializeField] int[] numberOfMaterialsNeeded;
}
