using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : MonoBehaviour
{

    protected GameObject[] pointList;
    protected float curSpeed;

    protected float curRotSpeed;

    protected Vector3 destPos;

    public abstract void Reason(Transform player, Transform npc, GameObject npc_obj);
    public abstract void Act(Transform player, Transform npc);

    public abstract void Attacking(GameObject npc_obj);

    protected void FindNextPoint(Transform npc)
    {
        int rndIndex = Random.Range(0, pointList.Length);
        destPos = pointList[rndIndex].transform.position;
        destPos.y = npc.position.y;


        if ((Mathf.Abs(destPos.x - npc.position.x) <= 30) && (Mathf.Abs(destPos.z - npc.position.z) <= 30))
        {
            Vector3 rndPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            destPos = pointList[rndIndex].transform.position + rndPosition;
        }

    }
}
