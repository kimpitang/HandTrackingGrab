using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    

    public PatrolState()
    {
        pointList = GameObject.FindGameObjectsWithTag("WanderPoint");
        curSpeed = 10.0f;
        curRotSpeed = 1.0f;
        destPos = new Vector3();
        destPos = Vector3.zero;
    }


    public override void Reason(Transform player, Transform npc, GameObject npc_obj)
    {
        Vector3 playerPos = player.position;
        playerPos.y = npc.position.y;

        if (Vector3.Distance(npc.position, playerPos) <= 30.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(2); // curState -> chase로 변경
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        destPos.y = npc.position.y;
        if (Vector3.Distance(npc.position, destPos) <= 50.0f)
        {
            FindNextPoint(npc);
        }

        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }

    public override void Attacking(GameObject npc_obj)
    {
        //nothing
    }

}
