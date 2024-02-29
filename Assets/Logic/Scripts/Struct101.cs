using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObjects/SOTest", order = 0)]

public class Struct101 : ScriptableObject
{
    public string fruitName;
    public int price;
    public Sprite sprite;
}
