using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScoreUI : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI endScoreUI = null;
    [SerializeField] ScoreComponent scoreComponent= null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEndScore(scoreComponent.Score);
    }
    public void UpdateEndScore(int _value)
    {
        endScoreUI.text = $"Score:\n {_value}";
    }
}
