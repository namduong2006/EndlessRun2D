using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public static UIManager Instance;
    [SerializeField] TMP_Text coinText;
    //[SerializeField] TMP_Text coinEnd;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject gameOver;
    [SerializeField] Slider volumM;
    [SerializeField] Slider volumeS;
    [SerializeField] TMP_Text _FPS;
    int coin_health = 50;
    int coin;
    int health;
    bool takehealth = true;
    bool setcolor = true;
    float deltaTime = 0f;
    bool _fps = true;
    
    private void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            coin = 0;
            health = 3;
        }
        else
        {
            coin = Data.Instance.Coins;
            health = Data.Instance.Health;
        }        
        gameOver.SetActive(false);       
        volumM.value = Data.Instance.VolMusic;
    }   
    // Update is called once per frame
    void Update()
    {
        if (_fps)
        {
            StartCoroutine(SetFPS());
        }
        
        coinText.SetText("Coin " + coin);
        //coinEnd.text = coin.ToString();
        healthText.SetText("x" + health);
        Music.Instance.SetVolumMusic(volumM.value);
        Music.Instance.SetVolumSound(volumeS.value);
        if(takehealth == false)
        {
            if(setcolor == true)
            {
                StartCoroutine(SetColor());
            }
        }
        else
        {
            Player.instance.SetColorWhite();
        }
    }   
    private IEnumerator SetFPS()
    {
        _fps = false;
        _FPS.text = "FPS:" + FPS().ToString("00");
        yield return new WaitForSeconds(0.1f);
        _fps = true;
    }
    public float FPS()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        return Mathf.Abs(fps);
    }
    private IEnumerator SetColor()
    {
        setcolor = false;
        Player.instance.SetColorRed();
        yield return new WaitForSeconds(0.1f);
        Player.instance.SetColorWhite();
        yield return new WaitForSeconds(0.1f);
        setcolor = true;
    }   
    public void AddCoin()
    {
        coin++;
        if(coin >= coin_health)
        {
            health++;
            Data.Instance.Health = health;
            coin-= coin_health;
        }
        Data.Instance.Coins = coin;
    }
    public void LoadHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void LoadGame() 
    {
        SceneManager.LoadScene("LV1");
        
    }
    public void Setting()
    {
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
    }
    public void TakeDamage()
    {
        if (takehealth)
        {
            StartCoroutine(TimeTakeHealth());
            health--;
            Data.Instance.Health = health;
            Player.instance.ResetPosition();
            if (health <= 0)
            {
                Music.Instance.SoundGameOver();
                gameOver.SetActive(true);
                Setting();
            }
        }       
    }   
    private IEnumerator TimeTakeHealth()
    {
        takehealth = false;
        yield return new WaitForSeconds(3f);
        takehealth = true;
    }
    public void PLJump()
    {
        Player.instance.Jump();
    }
    public void PLATK()
    {
        Player.instance.Attack();
    }
}
