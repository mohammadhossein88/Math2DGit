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
    private float timer; 
    private float timerRedues;
    private float timerScaleX;
    private int _trueAnswers;
    public int score;
    public int health;
    public TMP_Text ctext;
    private void OnEnable()
    {
        timer = 20;
        score = 0;
        health = 3;
        healthText.text =health.ToString();

    }

    private void Update()
    {
        if (timerImage.fillAmount>=0)
        {
            timer-= Time.deltaTime;
            timerImage.fillAmount -= Time.deltaTime/timer;
            if (timerImage.fillAmount <=0.25f)
            {
                timerImage.color = Color.red;
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
        score++;
        Winning();
        GameModeHandler.NextQuestion();
    }

    public void DecreaseHealth()
    {
        health--;
        healthText.text = health.ToString();
        Losing();
    }
    public void Winning()
    {
        if (score == 10)
        {
            winningPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Losing()
    {
        if (health == 0)
        {
            losingPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
