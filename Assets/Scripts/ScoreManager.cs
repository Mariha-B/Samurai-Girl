using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreNum;
    
    public int startingScore;
    public int currentScore { get; private set; }

    private void Awake()
    {
        currentScore = startingScore;
    }

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
         scoreNum.text = currentScore.ToString();
    }

    public void AddScore(int _value)
    {
        currentScore += _value;

    }


}
