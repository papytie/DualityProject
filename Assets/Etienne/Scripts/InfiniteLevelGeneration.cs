using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLevelGeneration : MonoBehaviour
{
    public event Action OnTileSpawn = null;
    public event Action OnBonusSpawn = null;
    public event Action OnMalusSpawn = null;

    [Header("References")]
    [SerializeField] MoveAuto player = null;

    [Header("Tile Settings")]
    [SerializeField] GameObject tileTemplate = null;
    [SerializeField] float sectionSize = 10;
    [SerializeField] float tileCurrentTime = 0;
    [SerializeField] float tileMaxTime = 3;
    [SerializeField] int tileCount = 3;

    [Header("PickUps Settings")]
    [SerializeField] float minZPos = -10;
    [SerializeField] float maxZPos = 10;
    [SerializeField] int minXPos = -4;
    [SerializeField] int maxXPos = 4;

    [Header("Bonus Settings")]
    [SerializeField] GameObject SpeedBonusItem = null;
    [SerializeField] float bonusCurrentTime = 0;
    [SerializeField] float bonusMaxTime = 3;
    [SerializeField] float bonusYPos = 1;

    [Header("Malus Settings")]
    [SerializeField] GameObject SpeedMalusItem = null;
    [SerializeField] float malusCurrentTime = 0;
    [SerializeField] float malusMaxTime = 3;
    [SerializeField] float malusYPos = -1;

    //[SerializeField] bool faceRecto = true;
    //[SerializeField] List<GameObject> tileList = new();
    public Vector3 NextTilePos => transform.position + transform.forward * sectionSize * tileCount;
    void Start()
    {
        OnTileSpawn += () =>
        {
            SpawnNew(tileTemplate, NextTilePos);
            tileCount++;
        };

        OnBonusSpawn += () =>
        {
            SpawnNew(SpeedBonusItem, NextPickUpPos(bonusYPos));
        };

        OnMalusSpawn += () =>
        {
            SpawnNew(SpeedMalusItem, NextPickUpPos(malusYPos));
        };
    }

    void Update()
    {
        tileCurrentTime = IncreaseTimer(OnTileSpawn, ref tileCurrentTime, tileMaxTime);
        bonusCurrentTime = IncreaseTimer(OnBonusSpawn, ref bonusCurrentTime, bonusMaxTime);
        malusCurrentTime = IncreaseTimer(OnMalusSpawn, ref malusCurrentTime, malusMaxTime);
    }


    void SpawnNew(GameObject _toSpawn, Vector3 _spawnPos)
    {
        Instantiate(_toSpawn, _spawnPos, Quaternion.identity);
    }

    float IncreaseTimer(Action _event, ref float _time, float _max)
    {
        _time += Time.deltaTime;
        if( _time > _max) 
        {
            _event?.Invoke();
            return 0;
        }
        return _time;
    }


    void UpdateMaxTime()
    {
        //maxTime = player.MoveSpeed /10 * 2
    }

    Vector3 NextPickUpPos(float _upPos)
    {
        return new Vector3(RandomXClampPos(), _upPos, RandomZFromPlayer());
    }

    int RandomXClampPos()
    {
        return UnityEngine.Random.Range(minXPos, maxXPos);
    }

    float RandomZFromPlayer() 
    {
        return player.transform.position.z + UnityEngine.Random.Range(minZPos, maxZPos);
    }
}
