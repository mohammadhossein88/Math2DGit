using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIManger : MonoBehaviour
{
    [Header("Dependency ")]
    public GameModeHandler GameModeHandler;
    [Header("Question Panel")]
    public GameObject questionPanel;
    //Filed 
    [FormerlySerializedAs("UiAnimator")] [SerializeField]private Animator uiAnimator;
    
    [Header("timer and health")]
    [SerializeField]private Image timerImage;
    [SerializeField]private TMP_Text healthText;
    [SerializeField]private TMP_Text healthTextNum2;
    [Header("Score")]
    [SerializeField]private TMP_Text highscore;
    [SerializeField] private TMP_Text score;
    [Header("Timer")] 
    [SerializeField]private TMP_Text playTime;
        
    [Header("win and lose ")]
    [SerializeField]private GameObject winningPanel;
    [SerializeField]private GameObject losingPanel;
    [SerializeField] private GameObject startmenu;
    [SerializeField]private AudioSource gameSfxWinning;
    [SerializeField]private AudioSource gameSfxLosing;
    
    //Class property 
    private float _timer;
    
    private int _numTrueAnsewer;
    private float _playTime;
    private int _score;
    private int _health;
    private bool _timerFreeze;
    private DateTime _playerStartingTime;

    public int healthNum2;
    public int scoreNum2;
    private void OnEnable()
    {
        healthNum2 = 3;
        scoreNum2 = 0;
        _timer = 20;
        _score = 0;
        _numTrueAnsewer = 0;
        _playTime = 0;
        _health = 3;
        _timerFreeze = false;
        _playerStartingTime=DateTime.Now;
        timerImage.color=Color.green;
        timerImage.fillAmount = 1;
        healthText.text =_health.ToString();
        if (GameModeHandler.playingMod == PlayingMod.TwoPlayer)
        {
            questionPanel.GetComponent<RectTransform>().rotation = new Quaternion(questionPanel.transform.rotation.x,
                questionPanel.transform.rotation.y, 1, questionPanel.transform.rotation.w);
        }
        else
        {
            questionPanel.GetComponent<RectTransform>().rotation = new Quaternion(questionPanel.transform.rotation.x,
                questionPanel.transform.rotation.y, 0, questionPanel.transform.rotation.w);
        }

    }
    private void Update()
    {
        if (timerImage.fillAmount>0)
        {
            if (_timerFreeze == false)
            {
                _timer -= Time.deltaTime;
                timerImage.fillAmount -= Time.deltaTime / _timer;
                if (timerImage.fillAmount <= 0.25f)
                {
                    timerImage.color = Color.red;
                }
            }
        }
        else
        {

            StartCoroutine(Losing());
           // Time.timeScale = 0;
        }
    }

    public void SetHealth(int heath)
    {
        if (heath > 0)
        {
            _health = heath;
        }
        else
        {
            Debug.LogError($"Health number must not be less than zero {heath} ");
        }
    }
    public void IncreaseScore()
    {
        _timerFreeze = true;
        timerImage.fillAmount = 1; 
        timerImage.color=Color.green;
        _timer = 20;
        uiAnimator.SetBool("TrueAnseers",true);
        _numTrueAnsewer++;
        gameSfxWinning.Play();
    
    }
    public void IncreaseScoreNum2()
    {
        _timerFreeze = true;
        timerImage.fillAmount = 1; 
        timerImage.color=Color.green;
        _timer = 20;
        uiAnimator.SetBool("TrueAnseers",true);
        scoreNum2++;
        gameSfxWinning.Play();
    
    }



    public IEnumerator DecreaseHealth()
    {
        _health--;
        gameSfxLosing.Play();
        _timerFreeze = true;
        timerImage.fillAmount = 1;
        timerImage.color=Color.green;
        _timer = 20;
        uiAnimator.SetBool("WrongAnswer",true);
        yield return new WaitForSeconds(0.5f);
        healthText.text = _health.ToString();

    }
    public IEnumerator DecreaseHealthNum2()
    {
        healthNum2--;
        gameSfxLosing.Play();
        _timerFreeze = true;
        timerImage.fillAmount = 1;
        timerImage.color=Color.green;
        _timer = 20;
        uiAnimator.SetBool("WrongAnswer",true);
        yield return new WaitForSeconds(0.5f);
        healthTextNum2.text = healthNum2.ToString();

    }

    public void winningTwoPlayer()
    {
        if (scoreNum2 == 10)
        {
            
        }
        else if (_numTrueAnsewer == 10)
        {
            
        }
        
        
    }

    public void losingTwoPlayer()
    {
        if (healthNum2 == 0)
        {
            
        }
        else if (_health == 0)
        {
            
        }
        
    }
    

    
    public IEnumerator Winning()
    {
        
        if (_numTrueAnsewer == 10)
        {
            CalculateTime();
            CalculateScore();
            winningPanel.SetActive(true);
            Time.timeScale = 0;
            yield return new WaitForSeconds(2.5f);
            GameModeHandler._onended();
            startmenu.SetActive(true);
            winningPanel.SetActive(false);
        }
        else
        {
            NexQuestion();  

        }
    }
    public IEnumerator Losing()
    {  
        if (_health == 0||  timerImage.fillAmount==0)
        {
            losingPanel.SetActive(true);
            yield return new WaitForSeconds(2.5f);
           // Time.timeScale = 0;

            startmenu.SetActive(true);
            GameModeHandler._onended();
            losingPanel.SetActive(false);
        }
        else
        {
            NexQuestion();

        }
    }
  
    public void NexQuestion()
    {
        GameModeHandler.NextQuestion();
        _timerFreeze = false;
    }

    private void CalculateScore()
    {
        // OP
        //Game Mode 
        // HardNess
        _score = (int) ((_numTrueAnsewer + _health)*_playTime);
        HighScore();
      
    }

    private void HighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < _score)
            {
                PlayerPrefs.SetInt("HighScore", _score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore",_score);
        }

        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        score.text = _score.ToString(); 
        

    }

    private void CalculateTime()
    {
        var time = _playerStartingTime - DateTime.Now;
        _playTime = time.Seconds;
        playTime.text=time.Seconds.ToString();
    }
   

}
