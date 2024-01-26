using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownItem : PickUpItem
{
    [SerializeField] float speedMalus = -1;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
