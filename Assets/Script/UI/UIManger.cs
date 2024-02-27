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
    
    [Header("win and lose ")]
    [SerializeField]private GameObject winningPanel;
    [SerializeField]private GameObject losingPanel;
    [SerializeField]private AudioSource gameSfxWinning;
    [SerializeField]private AudioSource gameSfxLosing;
    
    //Class property 
    private float _timer; 
    private int _score;
    private int _health;
    private bool _timerFreeze;
    private void OnEnable()
    {
        _timer = 20;
        _score = 0;
        _health = 3;
        _timerFreeze = false;
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
        _score++;
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

    
    public void Winning()
    {
        
        if (_score == 10)
        {
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
  
    private void NexQuestion()
    {
        GameModeHandler.NextQuestion();
        _timerFreeze = false;
    }
   

}
