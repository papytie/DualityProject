using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float accelerationValue = .5f;
    [SerializeField] float playerSpeed = 10; //Get Player moveSpeed
    [SerializeField] float maxDistThreshold = 4;
    [SerializeField] float minDistThreshold = 2;
    [SerializeField] float maxT = .1f;
    float currentT = 0;

    void Start()
    {
        
    }

    void Update()
    {
        currentT = IncreaseTime(ref currentT, maxT);
        StalkerMove();
    }

    void StalkerMove()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;

        /*float _dist = Vector3.Distance(player.transform.position, transform.position);
        if (_dist > maxDist) 
        {
            transform.position = player.transform.position - player.transform.forward * maxDist;
        }*/
    }

    void AccelerationControl()
    {
        float _dist = Vector3.Distance(player.transform.position, transform.position);

        if(playerSpeed >= movementSpeed && _dist > maxDistThreshold) 
        {
            movementSpeed = playerSpeed + accelerationValue; 
        }

/*        if (_dist > minDistThreshold) return;
        movementSpeed += accelerationValue;
*/
    }

    float IncreaseTime(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if(_current > _max) 
        {
            AccelerationControl();
            return 0;
        }
        return _current;
    }
}
