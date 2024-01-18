using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Addition : MonoBehaviour
{

    // Start is called before the first frame updat

    public TMP_Text Atext;
    public TMP_Text Btext;
    public TMP_Text Operatortext;
    public TMP_Text healthText;
    public GameObject winningPanel;
    public GameObject losingPanel;
    
    public Button[] buttons;
    public TMP_Text[] textButtons;
    
    public Transform timerImage;
    public SpriteRenderer timerSprite;

    public GameManger gameManger;
    private int[] _notPrimeNumbers = new int[75];
    private int _a;
    private int _b;
    private int c;
    private int d;
    private int score;
    private int health;
    private int operstion;
    private int minRandom;
    private int maxRandom;
    private float timer = 20;
    private float timerRedues;
    private float timerScaleX;
    void Start()
    {
        operstion = gameManger.operstion;
        Debug.Log(operstion);
        GenrateQuestion();
        health = 3;
        healthText.text = health.ToString();
        score = 0;
        timerScaleX = timerImage.localScale.x;

    }

    private int GameOperationHandler()
    {
        if (operstion == 1)
        {
            minRandom = 0;
            maxRandom = 100;
            _a = Random.Range(minRandom,maxRandom);
            Atext.text = _a.ToString();
            _b = Random.Range(minRandom, 100);
            Btext.text = _b.ToString();
            Operatortext.text = "+";
            return _a + _b;
            //+
        }
        else if(operstion==2)
        {
            Operatortext.text = "-";
            maxRandom = 0;
            maxRandom = 100;
            minRandom = 0;
            maxRandom = 100;
            _a = Random.Range(minRandom,maxRandom);
            _b = Random.Range(minRandom,maxRandom);
            if (_a < _b)
            {
                Btext.text = _a.ToString();
                Atext.text = _b.ToString();
                return _b - _a;

            }

            Atext.text = _a.ToString();
            Btext.text = _b.ToString();
            return _a - _b;
        }
        else if (operstion == 3)
        {
            Operatortext.text = "*";
            minRandom = 2;
            maxRandom = 20;
            _a = Random.Range(minRandom,maxRandom);
            Atext.text = _a.ToString();
            _b = Random.Range(minRandom, maxRandom);
            Btext.text = _b.ToString();
            return _a * _b;
        }
        else if (operstion == 4)
        {
            Operatortext.text = "/";
            minRandom = 2;
            maxRandom = 100;
            _a = Random.Range(minRandom,maxRandom);
            Atext.text = _a.ToString();
            int[] divisibility = new int[_a / 2];
            int counter = 0;
            for (int i = 2; i < _a/2; i++)
            {
                if (_a % i == 0)
                {
                    divisibility[counter] = i;
                    counter++;
                }
            }

            int r = Random.Range(0, counter);
            _b = divisibility[r];
            return _a / _b;
            
        }

        return 0;
    }
    private void Update()
    {
        if (timerImage.localScale.x >= 0)
        {
            timerRedues = timer * Time.deltaTime;
            timerImage.localScale = new Vector3(timerImage.localScale.x - timerRedues, timerImage.localScale.y,
                timerImage.localScale.z);
            if (timerImage.localScale.x <= timerScaleX / 4)
            {
                timerSprite.color = Color.red;
            }
        }
        Winning();
        Losing();
    }
    
    private void GenrateQuestion()
    {

        c = GameOperationHandler();
        d = Random.Range(c - 10, c + 11);
        int randomAnswers = Random.Range(0, 2);
        buttons[randomAnswers].gameObject.name = c.ToString();
        textButtons[randomAnswers].text = c.ToString();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != randomAnswers)
            {
                buttons[i].gameObject.name = d.ToString();
                textButtons[i].text = d.ToString();
            }
        }
    }
    public void True(GameObject button)
    {
     int answer=   Convert.ToInt32(button.name);
     AnswerCheck(answer);
    }

    private void AnswerCheck(int answer)
    {
        if (answer == c)
        {
            GenrateQuestion();
            timerImage.localScale = new Vector3(timerScaleX - timerRedues, timerImage.localScale.y,
                timerImage.localScale.z);
            timerSprite.color=Color.white;
            score++;
            Winning();
           
        }
        else
        {
            health--;
            healthText.text = health.ToString();
            Losing();
        }
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
