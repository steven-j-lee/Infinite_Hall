using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rose", menuName = "Create Rose")]
public class Rose_Data : ScriptableObject
{
    public string name;
    public bool isTaken = false;
}
