using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAuto : MonoBehaviour
{
    public float MoveSpeed => moveSpeed;
    [SerializeField] float moveSpeed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
