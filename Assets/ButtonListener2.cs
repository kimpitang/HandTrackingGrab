using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonListener2 : MonoBehaviour
{
    public UnityEvent proximityEvent;
    public UnityEvent contactEvent;
    public UnityEvent actionEvent;
    public UnityEvent defaultEvent;
    //public Image panel;
    //private Color color;
    //private bool fadeIn;
    
    
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);
        //color = panel.color;
        //fadeIn = false;
        //color.a = 0.0f;
        //panel.gameObject.SetActive(true);
    }

    void InitiateEvent(InteractableStateArgs state)
    {
        if (state.NewInteractableState == InteractableState.ProximityState)
            proximityEvent.Invoke();
        else if (state.NewInteractableState == InteractableState.ContactState)
            contactEvent.Invoke();
        else if (state.NewInteractableState == InteractableState.ActionState)
        {
            actionEvent.Invoke();
        }
        else
            defaultEvent.Invoke();
    }

    /*
    public IEnumerator FadeIn()
    {
        color.a += Time.deltaTime;
        panel.color = color;
        if (color.a > 0.9f)
        {
            color.a = 1.0f;
            panel.color = color;
            SceneManager.LoadScene("SampleScene2");
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            panel.gameObject.SetActive(true);
            color.a += 0.01f;
            panel.color = color;
            if (color.a > 0.9f)
            {
                color.a = 1.0f;
                SceneManager.LoadScene("SampleScene2");
                fadeIn = false;
            }
            
            //StartCoroutine(FadeIn());
            
        }
    }
    */
    
}
