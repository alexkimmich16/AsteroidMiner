using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Example Scriptable Object", order = 51)]
public class Objectives : ScriptableObject
{
    public List<string> ToDo = new List<string>();
    public List<string> ActiveToDo = new List<string>();
    public List<string> GameplayTry = new List<string>();
}
