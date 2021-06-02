using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public static int sceneNum;

    public Image loadingBar;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    void Update()
    {
        
    }

    public static void LoadScene(int index)
    {
        sceneNum = index;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOp;

        asyncOp = SceneManager.LoadSceneAsync(sceneNum);
        asyncOp.allowSceneActivation = false;
        float timer = 0.0f;

        while(!asyncOp.isDone)
        {
            yield return null;
            timer += Time.deltaTime;

            if (asyncOp.progress < 0.9f)
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, asyncOp.progress, timer);
                if(loadingBar.fillAmount >= asyncOp.progress)
                {
                    timer = 0;
                }
            }

            else
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1, timer);
                if(loadingBar.fillAmount == 1.0f)
                {
                    asyncOp.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}
