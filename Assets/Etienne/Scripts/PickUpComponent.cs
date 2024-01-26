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

    void ReverseCamera()
    {
        GameManager.Instance.AmyCam.Priority = GameManager.Instance.AmyCam.Priority == 1 ? 0 : 1;
        GameManager.Instance.ZombieCam.Priority = GameManager.Instance.ZombieCam.Priority == 0 ? 1 : 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        SpeedUpItem _bonusItem = other.gameObject.GetComponent<SpeedUpItem>();
        if (_bonusItem)
        {
            Debug.Log("SpeedBonus : +" + _bonusItem.SpeedBonus);
            //TODO: Call AddSpeed
            Destroy(_bonusItem.gameObject);
        }

        SpeedDownItem _malusItem = other.gameObject.GetComponent<SpeedDownItem>();
        if (_malusItem)
        {
            Debug.Log("SpeedDown : " + _malusItem.SpeedMalus);
            //TODO: Call RemoveSpeed
            Destroy(_malusItem.gameObject);
        }

        ReverseItem _reverseItem = other.gameObject.GetComponent<ReverseItem>();
        if (_reverseItem)
        {
            Debug.Log("Reverse");
            ReverseCamera();
            Destroy(_reverseItem.gameObject);
        }


    }
}
