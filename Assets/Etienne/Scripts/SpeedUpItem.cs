using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : PickUpItem
{
    [SerializeField] float speedBonus = .5f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
