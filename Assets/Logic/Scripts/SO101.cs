using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO101 : MonoBehaviour
{
    public List<Struct101> fruits;
    public GameObject fruit;
    public int fruitNumber;
    void Start()
    {
        fruit.GetComponent<SpriteRenderer>().sprite = fruits[fruitNumber].sprite;
    }

}
