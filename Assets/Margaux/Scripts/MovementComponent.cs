using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{   
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float clampNeg = -1;
    [SerializeField] float clampPos = 1;
    [SerializeField] Controls controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] AnimationParameter animationParameter = null;
    [SerializeField] Animation animationUpdate = null;
       
    public InputAction Move => move;
    public float MoveSpeed
    {
        get { return moveSpeed; }
    }

    private void Awake()
    {
        controls = new Controls();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       MoveAutoForward();
        MoveHorizontal();
    }
    public void MoveAutoForward()
    {
        Vector3 _fwdMovement = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += _fwdMovement;       
    }
    public void MoveHorizontal()
    {
        float _horizontalValue = Move.ReadValue<float>();
        Vector3 _horizontalMovement = new Vector3(_horizontalValue, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.position += _horizontalMovement;
        transform.position=new Vector3(Mathf.Clamp(
            transform.position.x,clampNeg,clampPos),transform.position.y,transform.position.z);
        //UpdateRightAxisParam();
    }
    public void UpdateAnimSpeed()
    {
        //animSpeed = moveSpeed / 10;
    }
   
    public void SetMoveSpeed(float _value)
    {
        moveSpeed += _value;
    }

    private void OnEnable()
    {
        move = controls.Runner.Move;
        move.Enable();

    }
}
