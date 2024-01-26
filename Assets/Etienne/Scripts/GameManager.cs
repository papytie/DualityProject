using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player PlayerRef => playerRef;
    public Destroyer DestroyerRef => destroyerRef;
    public CinemachineVirtualCamera AmyCam => amyCam;
    public CinemachineVirtualCamera ZombieCam => zombieCam;

    [SerializeField] Player playerRef = null;
    [SerializeField] Destroyer destroyerRef = null;
    [SerializeField] CinemachineVirtualCamera amyCam = null;
    [SerializeField] CinemachineVirtualCamera zombieCam = null;

}
