using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    protected Transform playerTransform;

    protected Vector3 destPos;

    //protected GameObject[] pointList;

    //attack material
    protected Transform attackSpawnPoint { get; set; }

    protected virtual void Initialize() { }
    protected virtual void FSMUpdate() { }

    
    void Start()
    {
        Initialize();
    }

    
    void Update()
    {
        FSMUpdate();
    }
}
