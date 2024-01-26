using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : PickUpItem
{
    public float SpeedBonus => speedBonus;

    [SerializeField] float speedBonus = 1;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
