using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{   
    public void PlayGame()
    {       
        SceneManager.LoadScene("LV1");        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
