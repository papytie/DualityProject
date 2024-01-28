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
    public event Action OnScoreSpawn = null;

    public bool IsUpsideDown { get => isUpsideDown; set { isUpsideDown = value; } }
    public bool ResetAllTimers { get => resetAllTimers; set { resetAllTimers = value; } }

    [Header("References")]
    [SerializeField] GameObject player = null;

    [Header("Global Settings")]
    bool resetAllTimers = false;

    [Header("Tile Settings")]
    [SerializeField] GameObject tileTemplate = null;
    [SerializeField] float sectionSize = 10;
    [SerializeField] float tileMaxTime = 3;
    [SerializeField] float timeMaxDiv = 20;
    [SerializeField] int tileCount = 3;
    float tileCurrentTime = 0;

    [Header("PickUps Settings")]
    [SerializeField] int minXPos = -4;
    [SerializeField] int maxXPos = 4;
/*    [SerializeField] float minZPos = -10;
    [SerializeField] float maxZPos = 10;
*/    

    [Header("Score Settings")]
    [SerializeField] GameObject scoreItem = null;
    [SerializeField] float scoreMaxTime = 3;
    [SerializeField] float scoreYSpawnPos = 1;
    [SerializeField] float scoreZSpawnPos = 1;
    [SerializeField] float scoreSequenceTime = .1f;
    [SerializeField] int scoreSequenceNumber = 4;
    [SerializeField] bool scoreSpawnInSequence = true;
    [SerializeField] float scoreCurrentTime = 0;
    [SerializeField] int scoreSpawnCount = 0;
    //float scoreZLocation = 0;
    float scoreXLocation = 0;

    [Header("Speed Bonus Settings")]
    [SerializeField] GameObject SpeedBonusItem = null;
    [SerializeField] float bonusMaxTime = 3;
    [SerializeField] float versoBonusMaxTime = 5;
    [SerializeField] float bonusYSpawnPos = 1;
    [SerializeField] float bonusZSpawnPos = 1;
    float bonusCurrentTime = 0;

    [Header("Speed Malus Settings")]
    [SerializeField] GameObject SpeedMalusItem = null;
    [SerializeField] float malusMaxTime = 3;
    [SerializeField] float versoMalusMaxTime = 1;
    [SerializeField] float malusYSpawnPos = -1;
    [SerializeField] float malusZSpawnPos = -1;
    float malusCurrentTime = 0;

    [Header("Reverse Settings")]
    [SerializeField] GameObject reverseItem = null;
    [SerializeField] float reverseMaxTime = 3;
    [SerializeField] float versoReverseMaxTime = 3;
    [SerializeField] float reverseYSpawnPos = 0;
    [SerializeField] float reverseZSpawnPos = 0;
    [SerializeField] bool isUpsideDown = false;
    float reverseCurrentTime = 0;

    //[SerializeField] bool faceRecto = true;
    //[SerializeField] List<GameObject> tileList = new();
    public Vector3 NextTilePos => transform.position + transform.forward * sectionSize * tileCount;
    void Start()
    {
        UpdateTileMaxTime();

        OnTileSpawn += () =>
        {
            SpawnNew(tileTemplate, NextTilePos);
            tileCount++;
        };

        OnScoreSpawn += () =>
        {
            if(scoreSpawnInSequence && !isUpsideDown) //No sequences in UpsideDown
            {
                SpawnSequence(scoreSequenceNumber, scoreSequenceTime, scoreYSpawnPos);
                return;
            }
            //SpawnNew(scoreItem, RandomPickUpPos(scoreYSpawnPos));
            SpawnNew(scoreItem, new Vector3(RandomXClampPos(), scoreYSpawnPos, player.transform.position.z + scoreZSpawnPos));

        };

        OnBonusSpawn += () =>
        {
            SpawnNew(SpeedBonusItem, new Vector3(RandomXClampPos(), bonusYSpawnPos, player.transform.position.z + malusZSpawnPos));
        };

        OnMalusSpawn += () =>
        {
            SpawnNew(SpeedMalusItem, new Vector3(RandomXClampPos(), malusYSpawnPos, player.transform.position.z + malusZSpawnPos));
        };

        OnReverseSpawn += () =>
        {
            SpawnNew(reverseItem, new Vector3(0, reverseYSpawnPos, player.transform.position.z + reverseZSpawnPos));
            isUpsideDown = isUpsideDown ? false : true;
            resetAllTimers = true;
        };
    }

    void Update()
    {
        tileCurrentTime = IncreaseTimer(OnTileSpawn, ref tileCurrentTime, tileMaxTime);

        if (resetAllTimers)
        {
            bonusCurrentTime = 0;
            malusCurrentTime = 0;
            reverseCurrentTime = 0;
            scoreCurrentTime = 0;
            resetAllTimers = false;
            return;
        }

        if(isUpsideDown)
        {
            bonusCurrentTime = IncreaseTimer(OnBonusSpawn, ref bonusCurrentTime, versoBonusMaxTime);
            malusCurrentTime = IncreaseTimer(OnMalusSpawn, ref malusCurrentTime, versoMalusMaxTime);
            reverseCurrentTime = IncreaseTimer(OnReverseSpawn, ref reverseCurrentTime, versoReverseMaxTime);
            scoreCurrentTime = IncreaseTimer(OnScoreSpawn, ref scoreCurrentTime, scoreMaxTime);
            return;
        }

        bonusCurrentTime = IncreaseTimer(OnBonusSpawn, ref bonusCurrentTime, bonusMaxTime);
        malusCurrentTime = IncreaseTimer(OnMalusSpawn, ref malusCurrentTime, malusMaxTime);
        reverseCurrentTime = IncreaseTimer(OnReverseSpawn, ref reverseCurrentTime, reverseMaxTime);
        scoreCurrentTime = IncreaseTimer(OnScoreSpawn, ref scoreCurrentTime, scoreMaxTime);
    }

    void SpawnNew(GameObject _toSpawn, Vector3 _spawnPos)
    {
        Instantiate(_toSpawn, _spawnPos, Quaternion.identity);
    }

    void SpawnScoreSequence()
    {
        Vector3 _newLoc = new Vector3(scoreXLocation, scoreYSpawnPos, player.transform.position.z + scoreZSpawnPos);
        SpawnNew(scoreItem, _newLoc);
        
        scoreSpawnCount++;
        if (scoreSpawnCount >= scoreSequenceNumber)
        {
            CancelInvoke(nameof(SpawnScoreSequence));
            scoreSpawnCount = 0;
        }
    }

    void SpawnSequence(int _number, float _time, float _Ypos)
    {
        //scoreZLocation = RandomZFromPlayer(); no use
        scoreXLocation = RandomXClampPos();
        InvokeRepeating(nameof(SpawnScoreSequence), 0, _time);

    }
    public void UpdateTileMaxTime()
    {
        tileMaxTime = timeMaxDiv / GameManager.Instance.PlayerMoveRef.MoveSpeed;
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

    int RandomXClampPos()
    {
        return UnityEngine.Random.Range(minXPos, maxXPos);
    }

/*    Vector3 RandomPickUpPos(float _upPos)
    {
        return new Vector3(RandomXClampPos(), _upPos, RandomZFromPlayer());
    }

    Vector3 CenterPickUpPos(float _upPos)
    {
        return new Vector3(0, _upPos, maxZPos);
    }

    float RandomZFromPlayer() 
    {
        return player.transform.position.z + UnityEngine.Random.Range(minZPos, maxZPos);
    }
*/

}
