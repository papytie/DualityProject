using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : CustomButtonUI
{
    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject scoreText = null;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Execute()
    {
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        GameManager.Instance.AudioManager.PlaySound("ContinueSound");

    }
}
