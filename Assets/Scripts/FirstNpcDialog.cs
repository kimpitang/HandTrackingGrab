using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue
{
    [TextArea(5, 3)]
    public string dialogue;
}

public class FirstNpcDialog : MonoBehaviour
{
    static public int npc_talk_int = 0;
    Boolean justOne = false;
    public TextMeshProUGUI txt_Dialogue;
    //public Button button_1;
    //public Button button_2;

    static public bool isDialogue = true;

    // 대화가 얼마나 진행 되었는지 확인
    private int count = 0;

    static private String[] dialogue; // 대화가 들어가는 배열

    public bool nextdialogok = false;

    private void Awake()
    {
        dialogue = new String[100];
        // 처음 intro 대사
        dialogue[0] = "[DS1057]\n\n거기 누구 없나요!";
        dialogue[1] = "[DS1057]\n\n저를 좀 도와주세요!";
        dialogue[2] = "[DS1057]\n\n갑자기 다른 로봇들이 저를 공격했어요!";
        dialogue[3] = "[DS1057]\n\n혹시 당신도 나쁜 로봇은 아니겠죠?";
        dialogue[4] = "[DS1057]\n\n나쁜 로봇이 아니라면 저를 도와주세요!";
        dialogue[5] = "[DS1057]\n\n저기 있는 도구를 이용해서 제 팔을 붙여주세요.";
        dialogue[6] = "[DS1057]\n\n제 팔을 붙여주시면 다른 곳으로 갈 수 있는 포탈을 열어드릴게요.";
        dialogue[7] = "[DS1057]\n\n기다리고 있을게요.";
        dialogue[8] = "[DS1057]\n\n준비가 되었다면 저에게 알려주세요.";
        // 대화 끝에 null을 넣어서 대화가 끝났음을 알린다.
        dialogue[9] = "";
        dialogue[10] = "end";
        dialogue[11] = "[DS1057]\n\n준비가 되셨나요?";

    }
    private void Start()
    {
        //button_1.gameObject.SetActive(false);
        //button_2.gameObject.SetActive(false);

        Debug.Log("dialogue.length = " + dialogue.Length);
        ShowDialogue(0);
    }

    public void ShowDialogue(int count_)
    {
        count = count_;
        NextDialogue();
    }
    public void talk_npc()
    {
        //button_1.gameObject.SetActive(true);
        //button_2.gameObject.SetActive(true);
        count = 11;
        txt_Dialogue.text = dialogue[count];
    }

    public void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count];
        count++;
        nextdialogok = false;
    }

    
    IEnumerator WaitSeconds()
    {
        NextDialogue();
        //Time.timeScale = 0.0f;
        nextdialogok = false;
        //yield return new WaitForSeconds(1.0f);
        yield return new WaitForSecondsRealtime(1.0f);
        nextdialogok = true;
        //Time.timeScale = 1.0f;


    }
    

    void Update()
    {

        if (npc_talk_int == 1 && justOne == false)
        {
            talk_npc();
            justOne = true;
        }
        else if (npc_talk_int == 2)
        {
            //button_1.gameObject.SetActive(false);
            //button_2.gameObject.SetActive(false);
            justOne = false;
        }
        // count 가 12면 선택지 대화 진행중이라 막아 둔다.
        if (isDialogue && count != 11)
        {
            if (dialogue[count].Equals("end"))
            {
                npc_talk_int = 1;
            }
            //if (OVRInput.GetDown(OVRInput.Button.One))
            if (nextdialogok)
            {
                if (count < dialogue.Length)
                {
                    NextDialogue();
                    //StartCoroutine(WaitSeconds());
                }
            }
        }
    }
}