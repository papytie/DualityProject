using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreComponent : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreTxt = null;
    [SerializeField] float bonusScore = 50;
    [SerializeField] float malusScore = -50;

    public int Score => score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScore(int _value)
    {
        score += _value;
        UpdateScoreUI(_value);
    }
   
    public void UpdateScoreUI(float _value)
    {

        scoreTxt.text = $"{_value}";


    }


}
