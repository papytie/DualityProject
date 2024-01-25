using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator = null;
    [SerializeField] MovementComponent movement = null;

    public MovementComponent Movement => movement;

   

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        movement = GetComponent<MovementComponent>();
        
    }

    public void UpdateForwardAxisParam(float _value)
    {
       
        playerAnimator.SetFloat(AnimationParameter.ForwardAxisParam, _value);

    }
}
