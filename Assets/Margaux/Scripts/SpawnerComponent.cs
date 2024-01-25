using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    
    [SerializeField] GameObject bonus = null;
    [SerializeField] GameObject malus = null;

    [SerializeField] float currentTime = 0;
    [SerializeField] float maxTime = 1;

    [SerializeField] Vector3 spawnPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPickup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnPickup()
    {
        Debug.Log("Spawn");
        float _currentTime = Time.deltaTime;
        if(_currentTime% 10==0)
        {
            GameObject _pickupPrefab=Random.Range(0,1)<0.5f ?bonus : malus;
            Vector3 _spawnPos=new Vector3(Random.Range(-5,5),1f, Random.Range(-5f, 5f));
            Instantiate(_pickupPrefab, _spawnPos, Quaternion.identity);
        }       
    }
    
}
