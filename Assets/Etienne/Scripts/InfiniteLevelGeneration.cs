using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLevelGeneration : MonoBehaviour
{
    public event Action OnTileSpawn = null;
    public event Action OnBonusSpawn = null;
    public event Action OnMalusSpawn = null;
    public event Action OnReverseSpawn = null;

    [Header("References")]
    [SerializeField] GameObject player = null;

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
    [SerializeField] float bonusSequenceTime = .1f;
    [SerializeField] int bonusSequenceNumber = 4;
    [SerializeField] bool bonusSpawnInSequence = true;
    int bonusSpawnCount = 0;
    float bonusZLocation = 0;
    float bonusXLocation = 0;

    [Header("Malus Settings")]
    [SerializeField] GameObject SpeedMalusItem = null;
    [SerializeField] float malusCurrentTime = 0;
    [SerializeField] float malusMaxTime = 3;
    [SerializeField] float malusYPos = -1;

    [Header("Reverse Settings")]
    [SerializeField] GameObject reverseItem = null;
    [SerializeField] float reverseCurrentTime = 0;
    [SerializeField] float reverseMaxTime = 3;
    [SerializeField] float reverseYPos = 0;

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
            if(bonusSpawnInSequence)
            {
                SpawnSequence(bonusSequenceNumber, bonusSequenceTime, bonusYPos);
                return;
            }
            SpawnNew(SpeedBonusItem, NextPickUpPos(bonusYPos));
        };

        OnMalusSpawn += () =>
        {
            SpawnNew(SpeedMalusItem, NextPickUpPos(malusYPos));
        };

        OnReverseSpawn += () =>
        {
            SpawnNew(reverseItem, NextPickUpPos(reverseYPos));
        };
    }

    void Update()
    {
        tileCurrentTime = IncreaseTimer(OnTileSpawn, ref tileCurrentTime, tileMaxTime);
        bonusCurrentTime = IncreaseTimer(OnBonusSpawn, ref bonusCurrentTime, bonusMaxTime);
        malusCurrentTime = IncreaseTimer(OnMalusSpawn, ref malusCurrentTime, malusMaxTime);
        reverseCurrentTime = IncreaseTimer(OnReverseSpawn, ref reverseCurrentTime, reverseMaxTime);
    }

    void SpawnNew(GameObject _toSpawn, Vector3 _spawnPos)
    {
        Instantiate(_toSpawn, _spawnPos, Quaternion.identity);
    }

    void SpawnSpeedBonus()
    {
        Vector3 _newLoc = new Vector3(bonusXLocation, bonusYPos, bonusZLocation + player.transform.position.z);
        //Debug.Log(_newLoc);
        SpawnNew(SpeedBonusItem, _newLoc);
        
        bonusSpawnCount++;
        if (bonusSpawnCount >= bonusSequenceNumber)
        {
            CancelInvoke(nameof(SpawnSpeedBonus));
            bonusSpawnCount = 0;
        }
    }

    void SpawnSequence(int _number, float _time, float _Ypos)
    {
        bonusZLocation = RandomZFromPlayer();
        bonusXLocation = RandomXClampPos();
        InvokeRepeating(nameof(SpawnSpeedBonus), 0, _time);

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
