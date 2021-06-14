using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 3.0f;
    public float LifeTime = 3.0f;
    
    
    void Start()
    {
        Destroy(gameObject,LifeTime);    
    }

    
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
