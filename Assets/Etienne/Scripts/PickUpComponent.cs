using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : MonoBehaviour
{
    [SerializeField] MovementComponent movementComponent;

    void Start()
    {
        InitComponent();
        
    }

    void InitComponent()
    {
        movementComponent = GetComponent<MovementComponent>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpeedUpItem _speedItem = collision.gameObject.GetComponent<SpeedUpItem>();
        if (!_speedItem) return;
        //TODO: increase Movement Speed in MovementComponent
    }
}
