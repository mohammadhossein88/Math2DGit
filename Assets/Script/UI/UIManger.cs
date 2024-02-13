using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIManger : MonoBehaviour
{
   
    public TMP_Text healthText;
    public GameObject winningPanel;
    public GameObject losingPanel;
    [Header("Game Object Modes")]
    public GameModeHandler GameModeHandler;
    public Image timerImage;
    public Image answerIndicator;
    private float timer; 
    private float timerRedues;
    private float timerScaleX;
    private int _trueAnswers;
    public int score;
    public int health;
    public bool timerFreeze;
  
    private Color defual;
    private Color answerIndicatorColor;
    private void OnEnable()
    {
        timer = 20;
        score = 0;
        health = 3;
        timerFreeze = false;
        healthText.text =health.ToString();
        defual=Color.white;

    }

    private void Update()
    {
        if (timerImage.fillAmount>=0)
        {
            if (timerFreeze == false)
            {
                timer -= Time.deltaTime;
                timerImage.fillAmount -= Time.deltaTime / timer;
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
    public void IncreaseScore()
    {
        timerImage.fillAmount = 1;
        timerImage.color=Color.white;
        answerIndicatorColor=Color.red;
        answerIndicatorColor.a = 0.5f;
        score++;
        Winning();
    }

    public void DecreaseHealth()
    {
        health--;
        timerImage.fillAmount = 1;
        timerImage.color=Color.white;
        answerIndicatorColor=Color.green;
        answerIndicatorColor.a = 0.5f;
        healthText.text = health.ToString();
        Losing();

    }

    private IEnumerator NexQuestion()
    {
        timerFreeze = true;
        answerIndicator.color = answerIndicatorColor;
        yield return new WaitForSeconds(2f);
        answerIndicatorColor = defual;
        answerIndicatorColor.a = 0;
        answerIndicator.color = answerIndicatorColor;
        GameModeHandler.NextQuestion();
        
        timerFreeze = false;
    }
    public void Winning()
    {
        if (score == 10)
        {
            winningPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(NexQuestion());

        }
    }
    public void Losing()
    {
        if (health == 0)
        {
            losingPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(NexQuestion());

        }
    }

}
