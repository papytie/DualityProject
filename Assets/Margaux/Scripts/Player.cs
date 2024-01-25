using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddSpeed()
    {
        float _increase = Random.Range(10, 20);
        moveSpeed += _increase;
        moveSpeed = Mathf.Clamp(moveSpeed, 1, float.MaxValue);
    }

    public void RemoveSpeed() 
    {
        float _reduction = Random.Range(5f, 10f);
        moveSpeed -= _reduction;
        moveSpeed=Mathf.Clamp(moveSpeed, 1, 10);
    }
}
