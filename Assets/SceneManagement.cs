using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene0()
    {
        //loading.LoadScene(0);
        SceneManager.LoadScene(0);
    }

    public void LoadScene1()
    {
        //loading.LoadScene(1);
        SceneManager.LoadScene(1);
    }
}
