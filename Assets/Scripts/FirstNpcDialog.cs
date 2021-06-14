using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using OculusSampleFramework;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
}

public class FirstNpcDialog : MonoBehaviour
{
    static public int npc_tak_int = 0;
    Boolean justOne = false;
    public Text txt_Dialogue;
    public Button button_1;
    public Button button_2;

    static public bool isDialogue = true;

    private int count = 0;

    static private String[] dialogue;

    //public OVRHand hand;
    //public bool isIndexFingerPinching = false;

    private void Awake()
    {
        dialogue = new string[100];
        dialogue[0] = "[DS1057]\n\n거기 누구 있어요?";
        dialogue[1] = "[DS1057]\n\n반가워요. 저는 기지를 지키던 DS1057이에요.";
        dialogue[2] = "[DS1057]\n\n갑자기 다른 로봇들이 들어오더니 기지를 부수고 저를 망가뜨렸어요.";
        dialogue[3] = "[DS1057]\n\n혹시 당신도 나쁜 로봇은 아니겠죠?";
        dialogue[4] = "[DS1057]\n\n지금 공격당해서 팔이 망가졌어요.";
        dialogue[5] = "[DS1057]\n\n저기 있는 도구를 이용해서 저좀 고쳐주세요.";
        dialogue[6] = "[DS1057]\n\n고마워요!";
        dialogue[7] = "end";
        dialogue[8] = "[DS1057]\n\n아직은 버틸만해요. 하지만 서둘러주세요!";
        dialogue[9] = "[DS1057]\n\n아직은 버틸만해요. 하지만 서둘러주세요!";
        dialogue[10] = "[DS1057]\n\n아직은 버틸만해요. 하지만 서둘러주세요!";
    }
    // Start is called before the first frame update
    void Start()
    {
       // hand = GetComponent<OVRHand>();
        button_1.gameObject.SetActive(false);
        button_2.gameObject.SetActive(false);

        Debug.Log("dialogue.length=" + dialogue.Length);
        ShowDialogue(0);
    }

    public void ShowDialogue(int count_)
    {
        count = count_;
        NextDialogue();
    }

    public void talk_npc()
    {
        button_1.gameObject.SetActive(true);
        button_2.gameObject.SetActive(true);
        count = 8;
        txt_Dialogue.text = dialogue[count];
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count];
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        //isIndexFingerPinching = hand.GetFingerIsPinching(HandFinger.Index);

        if (npc_tak_int==1&&justOne==false)
        {
            talk_npc();
            justOne = true;
        }
        else if(npc_tak_int==2)
        {
            button_1.gameObject.SetActive(false);
            button_2.gameObject.SetActive(false);
            justOne = false;
        }

        if(isDialogue&&count!=8)
        {
            if(dialogue[count].Equals("end"))
            {
                npc_tak_int = 1;
            }
            if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.Hands))
            {
                if (count < dialogue.Length)
                    NextDialogue();
            }
        }
    }
}

//OVRInput.Get[Down / Up](OVRInput.Button.Three, OVRInput.Controller.Hands)