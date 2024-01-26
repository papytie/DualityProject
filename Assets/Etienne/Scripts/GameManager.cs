using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public MovementComponent PlayerMoveRef => playerMoveRef;
    public Destroyer DestroyerRef => destroyerRef;
    public CinemachineVirtualCamera AmyCam => amyCam;
    public CinemachineVirtualCamera ZombieCam => zombieCam;
    public PickupComponent PickUpComponentRef => pickUpComponentRef;

    [SerializeField] MovementComponent playerMoveRef = null;
    [SerializeField] Destroyer destroyerRef = null;
    [SerializeField] CinemachineVirtualCamera amyCam = null;
    [SerializeField] CinemachineVirtualCamera zombieCam = null;
    [SerializeField] PickupComponent pickUpComponentRef = null;

}
