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
    public PickUpComponent PickUpComponentRef => pickUpComponentRef;
    public GameOverPopup GameOverRef => gameOverRef;
    public InfiniteLevelGeneration Spawner => spawner;
    public Animator AmyAnim => amyAnim;
    public Animator ZombiGirlAnim => zombiGirlAnim;
    public AudioManager AudioManager => audioManager;

    [SerializeField] InfiniteLevelGeneration spawner = null;
    [SerializeField] AudioManager audioManager = null;
    [SerializeField] MovementComponent playerMoveRef = null;
    [SerializeField] Destroyer destroyerRef = null;
    [SerializeField] CinemachineVirtualCamera amyCam = null;
    [SerializeField] CinemachineVirtualCamera zombieCam = null;
    [SerializeField] PickUpComponent pickUpComponentRef = null;
    [SerializeField] GameOverPopup gameOverRef = null;
    [SerializeField] Animator amyAnim = null;
    [SerializeField] Animator zombiGirlAnim = null;

}
