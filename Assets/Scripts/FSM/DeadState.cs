using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : FSMState
{
    private bool bDead;

    public DeadState()
    {
        bDead = false;
    }
    public override void Reason(Transform player, Transform npc, GameObject npc_obj)
    {
        if(!bDead)
        {
            bDead = true;
            Destroy(npc_obj);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        //nothing
    }

    public override void Attacking(GameObject npc_obj)
    {
        //nothing
    }
}
