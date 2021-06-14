using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState2 : FSMState
{

    //attackTool

    public GameObject attackTool;

    //attack 변수
    private float attackRate;
    private float elapsedTime; //Timer

    public AttackState2(GameObject gameObject)
    {
        pointList = GameObject.FindGameObjectsWithTag("WanderPoint");
        curSpeed = 10.0f;
        curRotSpeed = 1.0f;

        destPos = new Vector3();
        destPos = Vector3.zero;

        attackTool = gameObject;

        elapsedTime = 0.0f;
        attackRate = 3.0f;
    }

    public override void Reason(Transform player, Transform npc, GameObject npc_obj)
    {
        //y값을 고려하지 않기 위해서
        destPos = player.position;
        destPos.y = npc.position.y;

        float dist = Vector3.Distance(npc.position, destPos);

        if (dist >= 20.0f && dist <= 50.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(2); // curState -> chase로 변경
        }
        else if (dist > 50.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(1); // curState -> patrol로 변경
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        //y값을 고려하지 않기 위해서
        destPos = player.position;
        destPos.y = npc.position.y;

        float dist = Vector3.Distance(npc.position, destPos);
        if (dist > 2.0f)
        {

            npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
        }


        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
    }

    public override void Attacking(GameObject npc_obj)
    {
        Transform attackSpawnPoint = npc_obj.transform.GetChild(0).transform;

        if (elapsedTime >= attackRate)
        {
            Instantiate(attackTool, attackSpawnPoint.position, attackSpawnPoint.rotation);
            elapsedTime = 0.0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }

    /*
    protected void UpdateAttackState()
    {
        destPos = playerTransform.position;
        destPos.y = defaultY;
        float dist = Vector3.Distance(transform.position, destPos);

        if(dist >= 5.0f && dist <= 40.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);

            curState = FSMState.Attack;
        }
        else if(dist>40.0f)
        {
            curState = FSMState.Patrol;
        }

        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        Attacking();
    }

    protected void Attacking()
    {
        if(elapsedTime >= attackRate)
        {
            Instantiate(attackTool, attackSpawnPoint.position, attackSpawnPoint.rotation);
            elapsedTime = 0.0f;
        }
    }
     */
}
