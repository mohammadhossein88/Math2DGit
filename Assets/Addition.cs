using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public Button[] buttons;
    public TMP_Text[] textButtons;
    
    public Transform timerImage;
    public SpriteRenderer timerSprite;
    
    private int _a;
    private int b;
    private int c;
    private int d;
    private int score;
    private int health;
    
    private float timer = 20;
    private float timerRedues;
    private float timerScaleX;
    void Start()
    {
        Operatortext.text = "+";
        GenrateQuestion();
        health = 3;
        healthText.text = health.ToString();
        score = 0;
        timerScaleX = timerImage.localScale.x;

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
        else
        {
           
        }
    }

    private void GenrateQuestion()
    {
        _a = Random.Range(0,100);
        Atext.text = _a.ToString();
        b = Random.Range(0, 100);
        Btext.text = b.ToString();
        c = _a + b;
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
        }
    }

    public void Losing()
    {
        if (health == 0)
        {
        }
    }
  
}
