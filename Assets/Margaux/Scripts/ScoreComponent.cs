using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreComponent : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreTxt = null;
    [SerializeField] RectTransform uiPanelRect = null;

    public float initialSize;
    public float sizeIncreaseFactor = 0.001f;
    
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
        //initialSize=uiPanelRect.localScale.x;
        UpdateScoreUI(score);
    }
   
    public void UpdateScoreUI(int _value)
    {

        scoreTxt.text = $"{_value}";
        //float _newSize = initialSize + score * sizeIncreaseFactor;
        //uiPanelRect.localScale=new Vector3(_newSize, _newSize, 1);


    }


}
