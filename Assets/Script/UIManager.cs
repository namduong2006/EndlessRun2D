using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance;
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text coingText;
    [SerializeField] TMP_Text coinwText;
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coingText.text = coinText.text;
        coinwText.text = coinText.text;       
    }
    public void SetCoin(int coin)
    {
        coinText.SetText($"Gold: "+coin);
    }
    public void LoadHome()
    {
        SceneManager.LoadScene("Scenes/Home");
    }
    public void LoadGame() 
    {
        SceneManager.LoadScene("Scenes/Game");
    }
    public void Setting()
    {
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
    }   
}
