using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{
    
    [SerializeField] TMP_Text ttcoinText;
    public GameObject loadingScene;
    public Slider loadingBar;
    // Start is called before the first frame update
    void Start()
    {
        //DataManager.Coins = 0;
        int c = DataManager.Coins;
        ttcoinText.text = "Coin: " + c.ToString();
    }
     
    // man hinh loading 

    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsyn(levelIndex));
    }
    IEnumerator LoadSceneAsyn(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
