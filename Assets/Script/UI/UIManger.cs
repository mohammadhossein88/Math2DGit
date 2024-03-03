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
        healthText.text =_health.ToString();

    }
    private void Update()
    {
        if (timerImage.fillAmount>=0)
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
            losingPanel.SetActive(true);
            Time.timeScale = 0;
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
        timerImage.color=Color.white;
        _timer = 20;
        uiAnimator.SetBool("TrueAnseers",true);
        _numTrueAnsewer++;
        gameSfxWinning.Play();
    
    }
    public void IncreaseScoreNum2()
    {
        _timerFreeze = true;
        timerImage.fillAmount = 1; 
        timerImage.color=Color.white;
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
        timerImage.color=Color.white;
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
        timerImage.color=Color.white;
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
    

    
    public void Winning()
    {
        
        if (_numTrueAnsewer == 10)
        {
            CalculateTime();
            CalculateScore();
            winningPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            NexQuestion();  

        }
    }
    public void Losing()
    {  
        if (_health == 0)
        {
            losingPanel.SetActive(true);
            Time.timeScale = 0;
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
