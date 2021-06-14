using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    public ChaseState()
    {
        pointList = GameObject.FindGameObjectsWithTag("WanderPoint");
        curSpeed = 10.0f;
        curRotSpeed = 1.0f;

        destPos = new Vector3();
        destPos = Vector3.zero;
        
    }

    public override void Reason(Transform player, Transform npc, GameObject npc_obj)
    {
        destPos = player.position;
        destPos.y = npc.position.y;
        float dist = Vector3.Distance(player.position,destPos);

        if(dist <= 10.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(3);
        }
        else if(dist>=50.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(1);
        }

    }

    public override void Act(Transform player, Transform npc)
    {
        destPos = player.position;
        destPos.y = npc.position.y;

        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }

    public override void Attacking(GameObject npc_obj)
    {
        //nothing
    }
}
