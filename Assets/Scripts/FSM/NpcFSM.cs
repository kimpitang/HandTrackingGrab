using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcFSM : FSM
{
    public enum FSMStateID
    {
        None,
        Patrol,
        Chase,
        Attack,
        Dead,
    }

    //npc state 상태 관련 변수
    public FSMStateID curState;

    private List<FSMState> fsmstates;

    //health
    private int health;
    

    //stage  1-weak npc/ 2-middle npc/ 3-strong npc
    public int npcStage;

    //panel
    public Image panel;
    private Color color;

    //attck
    public GameObject attackTool;

    //blur effect
    public bool blurEnabled;


    public void TranslateState(int index)
    {
        if(index == 1)
        {
            curState = FSMStateID.Patrol;
        }
        else if(index == 2)
        {
            curState = FSMStateID.Chase;
        }
        else if(index == 3)
        {
            curState = FSMStateID.Attack;
        }
        else if(index == 4)
        {
            curState = FSMStateID.Dead;
        }
    }

    
    
    protected override void Initialize()
    {
        curState = FSMStateID.Patrol;
        health = 100;
        

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        

        if (!playerTransform)
            print("Player doesn't exist!!");
        blurEnabled = false;
        ConstructState();
        color = panel.color;
        color.a = 0.0f;

    }

    public void ConstructState()
    {
        fsmstates = new List<FSMState>();

        PatrolState patrolState = new PatrolState();
        ChaseState chaseState = new ChaseState();
        fsmstates.Add(patrolState);
        fsmstates.Add(chaseState);
        if(npcStage == 1)
        {
            AttackState1 attackState = new AttackState1(attackTool);
            fsmstates.Add(attackState);
        }
        else if(npcStage == 2)
        {
            AttackState2 attackState2 = new AttackState2(attackTool);
            fsmstates.Add(attackState2);
        }
        else
        {
            AttackState3 attackState3 = new AttackState3(attackTool);
            fsmstates.Add(attackState3);
        }
        DeadState deadstate = new DeadState();
        fsmstates.Add(deadstate);
    }

    protected override void FSMUpdate()
    {
        
        switch(curState)
        {
            case FSMStateID.Patrol:
                fsmstates[0].Reason(playerTransform,transform, gameObject);
                fsmstates[0].Act(playerTransform, transform);
                break;
            case FSMStateID.Chase:
                fsmstates[1].Reason(playerTransform,transform, gameObject);
                fsmstates[1].Act(playerTransform, transform);
                break;
            case FSMStateID.Attack:
                fsmstates[2].Reason(playerTransform,transform, gameObject);
                fsmstates[2].Act(playerTransform, transform);
                fsmstates[2].Attacking(gameObject);
                break;
            case FSMStateID.Dead:
                fsmstates[3].Reason(playerTransform,transform, gameObject);
                fsmstates[3].Act(playerTransform,transform);
                break;
        }

        if (blurEnabled)
        {
            color.a += Time.deltaTime;
            panel.color = color;
            if(color.a > 0.9)
            {
                blurEnabled = false;
                color.a = 0.0f;
                panel.color = color;
            }
        }
        

        if (health <= 0)
            curState = FSMStateID.Dead;
    }
}
