using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpItem : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100;

    protected virtual void Start()
    {
        transform.eulerAngles = new Vector3(45, 45, 45);
    }

    protected virtual void Update()
    {
        ItemRotation();
    }

    protected void ItemRotation()
    {
        transform.eulerAngles += transform.up * rotationSpeed * Time.deltaTime;
    }
}
