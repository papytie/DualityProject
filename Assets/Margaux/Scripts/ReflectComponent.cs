using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectComponent : MonoBehaviour
{
    [SerializeField] MovementComponent movementComponent = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReflectMovement();
    }
    public void ReflectMovement()
    {
        transform.position=movementComponent.transform.position;
    }
}
