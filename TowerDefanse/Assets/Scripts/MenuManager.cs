using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [Header("載入畫面")]
    public GameObject panelloading;
    [Header("進度")]
    public Text textloading;
    [Header("提示文字")]
    public GameObject tip;
    [Header("進度條")]
    public Image imgloading;
    [Header("載入場景名稱")]
    public string nameScene = "遊戲畫面";



    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(Loading());
    }


    public IEnumerator Loading()
    {
        panelloading.SetActive(true);
        AsyncOperation ao = SceneManager.LoadSceneAsync(nameScene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            textloading.text = (ao.progress / 0.9f * 100).ToString("F0") + "%";
            imgloading.fillAmount = ao.progress;
            yield return null;

            if (ao.progress == 0.9f)
            {
                tip.SetActive(true);

                if (Input.anyKeyDown)
                {
                    ao.allowSceneActivation = true;
                }
            }


        }
    }
}
