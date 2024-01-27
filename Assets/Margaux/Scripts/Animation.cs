using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator = null;
    [SerializeField] MovementComponent movement = null;
    [SerializeField] Animator reflectAnimator = null;


    public MovementComponent Movement => movement;

   

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        playerAnimator = GetComponent<Animator>();
        movement = GetComponent<MovementComponent>();
        
    }

    public void UpdateRightAxisParam(float _value)
    {
       
        playerAnimator.SetFloat(AnimationParameter.RightAxisParam, _value);
        reflectAnimator.SetFloat(AnimationParameter.RightAxisParam, _value);
        

    }
    public void UpdateAnimSpeedParam(float _value)
    {

        playerAnimator.SetFloat(AnimationParameter.AnimSpeedParam, _value);
        reflectAnimator.SetFloat(AnimationParameter.AnimSpeedParam, _value);

    }
}
