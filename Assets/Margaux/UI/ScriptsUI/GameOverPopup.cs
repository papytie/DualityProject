using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] GameObject gameOver = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateGameOverPanel()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
