using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownItem : PickUpItem
{
    public float SpeedMalus => speedMalus;

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
