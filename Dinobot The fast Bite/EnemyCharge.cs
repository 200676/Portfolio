using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
enum State
{
    Idle,
    Aggro,
    Tired
}
public class EnemyCharge : MonoBehaviour
{
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float chargeDistance;
    [SerializeField] private float chargeCoolDown = 0f;
    [SerializeField] private float chargeCooldownMax = 3f;
    [SerializeField] private Transform playerChargeTransform;
    private Rigidbody rbEnemyCharge;
    private bool freezeRot = false;
    [SerializeField] private float freezeChargeTimeRemaining = 0f;
    [SerializeField] private float freezeChargeTimeMax = 4f;
    [SerializeField] private float tiredDistance;
    [SerializeField] private float startIdleDistance;
    private State currentState;
    private Animator anim;
   

    
    void Start()
    {
        rbEnemyCharge = GetComponent<Rigidbody>();
        currentState = State.Idle;
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 2);
       

    }
    private void Update()
    {
        enemyCharge();
    }

    private void SetState(State newState)
    {
        currentState = newState;
    }

    public void enemyCharge()
    {
        switch (currentState)
        {
            
            case State.Idle:
                if (Vector3.Distance(transform.position, playerChargeTransform.position) < startIdleDistance)
                {
                    anim.SetInteger("State", 0);
                    anim.Play("idle trike");
                    
                    if (freezeRot == false)
                    {
                        transform.LookAt(playerChargeTransform);
                        chargeCoolDown += Time.deltaTime;
                    }
                    if (chargeCoolDown >= chargeCooldownMax)
                    {
                        SetState(State.Aggro);
                        chargeCoolDown = 0;
                    }
                }
                break;
            case State.Aggro:
                
                if (Vector3.Distance(transform.position, playerChargeTransform.position) <= chargeDistance)
                {
                   
                    freezeRot = true;
                    rbEnemyCharge.constraints = RigidbodyConstraints.FreezeRotationY;
                    Debug.Log("freeze rot");
                    transform.position += transform.forward * chargeSpeed * Time.deltaTime;
                    freezeChargeTimeRemaining += Time.deltaTime;
                    anim.SetInteger("State", 1);
                    anim.Play("chargeeeee trike");
                }
                if (freezeChargeTimeRemaining >= freezeChargeTimeMax)
                {
                    SetState(State.Tired);
                    freezeChargeTimeRemaining = 0;
                    
                }
                break;

            case State.Tired:

                
                if (freezeRot == true)
                {
                    anim.SetInteger("State", 2);
                    anim.Play("walk trike");
                    chargeCoolDown += Time.deltaTime;
                        
                    if (chargeCoolDown >= chargeCooldownMax)
                    {
                       
                        if (Vector3.Distance(transform.position, playerChargeTransform.position) >= tiredDistance)
                        {
                            
                            freezeRot = false;
                            rbEnemyCharge.constraints = RigidbodyConstraints.None;
                            chargeCoolDown = 0;
                            SetState(State.Idle);

                        }
                    }

                }
                break;

                default:
                Debug.LogWarning("unkown state reached" + currentState);
                

                break;
        }
    }

}
