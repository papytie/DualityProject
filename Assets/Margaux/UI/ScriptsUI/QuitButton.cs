using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuitButton : CustomButtonUI
{
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
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
