using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endScoreUI = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateEndScore(int _value)
    {
        endScoreUI.text = $"{_value}";
    }
}
