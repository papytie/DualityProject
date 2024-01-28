using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] bool isFreeze = false;
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float accelerationValue = .5f;
    [SerializeField] float maxDistThreshold = 4;
    [SerializeField] float minDistThreshold = 2;
    [SerializeField] float maxT = .1f;
    float currentT = 0;

    public bool IsFreeze { get => isFreeze; set { isFreeze = value; }}

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
        if (isFreeze) return;
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void AccelerationControl()
    {
        float _dist = Vector3.Distance(GameManager.Instance.PlayerMoveRef.transform.position, transform.position);

        if(GameManager.Instance.PlayerMoveRef.MoveSpeed >= movementSpeed && _dist > maxDistThreshold) 
        {
            movementSpeed = GameManager.Instance.PlayerMoveRef.MoveSpeed + accelerationValue; 
        }

        //Adjust difficulty
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

    private void OnTriggerExit(Collider other)
    {
        Tile _tile = other.gameObject.GetComponent<Tile>();
        if (_tile)
        {
            Destroy(_tile.gameObject);
        }
    }
}
