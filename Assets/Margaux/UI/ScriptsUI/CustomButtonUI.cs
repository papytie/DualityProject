using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CustomButtonUI : MonoBehaviour
{
    [SerializeField] protected Button button = null;
    [SerializeField] protected TextMeshProUGUI buttonText = null;

    public Button Button => button;
    public TextMeshProUGUI ButtonText => buttonText;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void Init()
    {
        button.onClick.AddListener(Execute);
    }
    protected abstract void Execute();
}
