using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public int CurrentScore { get; set;}

    [SerializeField] private TextMeshProUGUI _scoreText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _scoreText.text = CurrentScore.ToString("0");
        Time.timeScale = 0f;
    }


    public void IncreaseScore(int Amount)
    {
        CurrentScore += Amount;
        _scoreText.text = CurrentScore.ToString("0"); 

    }
}
