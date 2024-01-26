using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpItem : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100;
    [SerializeField] Destroyer destroyer = null;

    protected virtual void Start()
    {
        InitItem();
    }

    protected virtual void Update()
    {
        ItemRotation();
    }

    void InitItem()
    {
        transform.eulerAngles = new Vector3(45, 45, 45);
        destroyer = GameManager.Instance.DestroyerRef;

    }

    protected void ItemRotation()
    {
        transform.eulerAngles += transform.up * rotationSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroyer _destroyer = other.gameObject.GetComponent<Destroyer>();
        if (_destroyer)
            Destroy(gameObject);
    }
}
