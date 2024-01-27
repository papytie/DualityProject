using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : PickUpItem
{
    public int ScoreValue => scoreValue;

    [SerializeField] int scoreValue = 50;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
