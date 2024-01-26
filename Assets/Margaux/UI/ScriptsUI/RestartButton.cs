using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : CustomButtonUI
{
    [SerializeField] SceneAsset sceneToLoad = null;
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
        SceneManager.LoadScene(sceneToLoad.name);
        Time.timeScale = 1;

    }
}
