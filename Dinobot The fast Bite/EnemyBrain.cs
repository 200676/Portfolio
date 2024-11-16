using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum States
{
    patrol,
    shoot
}
public class EnemyBrain : MonoBehaviour
{
    [SerializeField] public FieldOfView fov;
    [SerializeField] public EnemyShooting enemyShooting;
    [SerializeField] public EnemyPatrol waypoints;
    [SerializeField] private States thisState;
    private Animator enemyAnim;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetInteger("StateRex", 0);
        enemyAnim.Play("idle trex");
    }
    private void SettingState(States stateNew)
    {
        thisState = stateNew;
    }
    private void LateUpdate()
    {
        EnemyBrains();
    }

    void EnemyBrains()
    {
        switch (thisState)
        {
            case States.patrol:
                enemyAnim.SetInteger("StateRex", 1);
                enemyAnim.Play("walk trex");
                if (waypoints)
                {
                    waypoints.SetNextTarget();
                    Debug.Log("Patrol Enemy");
                    if (fov.canSeePlayer)
                    {
                        SettingState(States.shoot);
                    }
                }
                break;
            case States.shoot:
               
                if (enemyShooting)
                {
                    enemyAnim.SetInteger("StateRex", 2);
                    enemyAnim.Play("bite trex");
                    enemyShooting.enemyShoot();
                    Debug.Log("Shoot Enemy");
                    if (fov.canSeePlayer == false)
                    {
                        SettingState(States.patrol);
                    }
                   
                }
               

                break;
                   
        }


    }

}
