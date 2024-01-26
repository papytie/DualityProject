using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParameter 
{
    public const string RIGHT_PARAM = "right";
    public const string ANIMESPEED_PARAM = "animSpeed";

    public static readonly int RightAxisParam = Animator.StringToHash(RIGHT_PARAM);
    public static readonly int AnimSpeedParam = Animator.StringToHash(ANIMESPEED_PARAM);
}
