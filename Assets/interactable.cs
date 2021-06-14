using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public GameObject player;
    protected Transform playerTransform;

    public bool HasInteracted { get; set; }

    protected float radius = 3.5f;
    protected float DistanceFromPlayer;

    protected virtual void Awake()
    {
        playerTransform = player.transform;
        HasInteracted = false;
    }

    private void OnEnable()
    {
        HasInteracted = false;
    }

    public virtual void Interact()
    {
    }

    public virtual void NonInteract()
    {
    }

    // Update is called once per frame
    protected void Update()
    {
         DistanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (!HasInteracted)
        {
            if (DistanceFromPlayer <= radius)
            {
                Debug.Log("interact");
                Interact();
            }
        }
        else
        {
            if (DistanceFromPlayer > radius)
            {
                NonInteract();
            }
        }
    }
}
