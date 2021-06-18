using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : interactable
{
    public GameObject dialoguePanel;
    public string npcName;
    public GameObject npc;
    public GameObject mark;

    protected override void Awake()
    {
        base.Awake();
        radius = 3.5f;
        mark.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        dialoguePanel.SetActive(true);
        HasInteracted = true;
    }

    public override void NonInteract()
    {
        dialoguePanel.SetActive(false);
        HasInteracted = false;
    }
}