using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : MonoBehaviour
{
    MovementComponent movementComponent = null;
    ScoreComponent scoreComponent = null;

    void Start()
    {
        InitComponent();
        
    }

    void InitComponent()
    {
        movementComponent = GetComponent<MovementComponent>();
        scoreComponent = GetComponent<ScoreComponent>();
    }

    void Update()
    {
        
    }

    void ReverseCamera()
    {
        GameManager.Instance.AmyCam.Priority = GameManager.Instance.AmyCam.Priority == 1 ? 0 : 1;
        GameManager.Instance.ZombieCam.Priority = GameManager.Instance.ZombieCam.Priority == 0 ? 1 : 0;
    }

    void EnterUpsideDown()
    {
        GameManager.Instance.Spawner.IsUpsideDown = GameManager.Instance.Spawner.IsUpsideDown ? false : true;
        GameManager.Instance.Spawner.ResetAllTimers = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreItem _scoreItem = other.gameObject.GetComponent<ScoreItem>();
        if (_scoreItem)
        {
            Debug.Log("Score : +" + _scoreItem.ScoreValue);
            scoreComponent.ChangeScore(_scoreItem.ScoreValue);
            Destroy(_scoreItem.gameObject);
        }
        
        SpeedUpItem _bonusItem = other.gameObject.GetComponent<SpeedUpItem>();
        if (_bonusItem)
        {
            Debug.Log("SpeedBonus : +" + _bonusItem.SpeedBonus);
            movementComponent.SetMoveSpeed(_bonusItem.SpeedBonus);
            GameManager.Instance.Spawner.UpdateTileMaxTime();
            GameManager.Instance.AmyAnim.SetTrigger("bonusReaction");
            GameManager.Instance.ZombiGirlAnim.SetTrigger("bonusReaction");
            Destroy(_bonusItem.gameObject);
        }

        SpeedDownItem _malusItem = other.gameObject.GetComponent<SpeedDownItem>();
        if (_malusItem)
        {
            Debug.Log("SpeedDown : " + _malusItem.SpeedMalus);
            movementComponent.SetMoveSpeed(_malusItem.SpeedMalus);
            GameManager.Instance.Spawner.UpdateTileMaxTime();
            GameManager.Instance.AmyAnim.SetTrigger("malusReaction");
            GameManager.Instance.ZombiGirlAnim.SetTrigger("malusReaction");
            Destroy(_malusItem.gameObject);
        }

        ReverseItem _reverseItem = other.gameObject.GetComponent<ReverseItem>();
        if (_reverseItem)
        {
            Debug.Log("Reverse");
            GameManager.Instance.AmyAnim.SetTrigger("reverseReaction");
            GameManager.Instance.ZombiGirlAnim.SetTrigger("reverseReaction");
            //EnterUpsideDown();
            ReverseCamera();
        }

        Destroyer _destroyer = other.gameObject.GetComponent<Destroyer>();
        if (_destroyer)
        {
            Debug.Log("GameOver");
            GameManager.Instance.GameOverRef.ActivateGameOverPanel();
        }

    }

        private void OnTriggerExit(Collider other)
        {
            ReverseItem _reverseItem = other.gameObject.GetComponent<ReverseItem>();
            if (_reverseItem)
            {
                Destroy(_reverseItem.gameObject);
            }
        }

    }
