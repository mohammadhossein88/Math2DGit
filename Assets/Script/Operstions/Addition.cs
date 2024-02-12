using System;
using TMPro;
using UnityEngine;
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
    private Operators operstion;
    private int minRandom;
    private int maxRandom;
    private float timer = 20;
    private float timerRedues;
    private float timerScaleX;

    private void OnEnable()
    {
        timer = 20;
        operstion = gameManger.operstion;
        health = 3;
        score = 0;
        timerScaleX = timerImage.localScale.x;

    }

    void Start()
    {
        GenrateQuestion();
        healthText.text = health.ToString();

    }

    private int GameOperationHandler()
    {
        if (operstion == Operators.addition)
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
        else if(operstion== Operators.substraction)
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
        else if (operstion ==  Operators.multiply)
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
        else if (operstion ==  Operators.division)
        {
            Operatortext.text = "/";
            minRandom = 2;
            maxRandom = 100;
            _a = NotPrimeNumbers();
            Atext.text = _a.ToString();
            _b = DivisibilityNum();
            Btext.text = _b.ToString();
            return _a / _b;
           

        }

        return 0;
    }

    private int FalseAnswerHandler(int c)
    {
        int falseAnswer = 0;
        if (operstion == Operators.addition || operstion== Operators.substraction)
        {
            falseAnswer = Random.Range(c-11, c+10);
            return falseAnswer;
        }
        else if (operstion==Operators.multiply||operstion==Operators.division)
        {
            falseAnswer = (_a - 1) * _b;
            return falseAnswer;
        }

        return 0;

    }
    private int NotPrimeNumbers()
    {
        int[] notPrime = new int[75];
        int counter1 = 0;
            
        for (int i = 2; i <=maxRandom; i++)
        {
            for (int j = 2; j <=i/2; j++)
            {
                if (i%j==0)
                {
                    notPrime[counter1] = i;
                    counter1++;
                    break;
                }
                    
            }
                
        }
        int r1 = Random.Range(0, counter1);
        return notPrime[r1];
    }

    private int DivisibilityNum()
    {
        int[] divisibility = new int[_a / 2];
        int counter = 0;
        for (int i = 2; i <= _a/2; i++)
        {
            if (_a % i == 0)
            {
                Debug.Log("i"+i);
                divisibility[counter] = i;
                counter++;
            }
        }

        counter--; 
        int r = Random.Range(0, (counter));
        return divisibility[r];
    }
    private void Update()
    {
        
        if (timerImage.localScale.x >= 0)
        {
            Debug.Log(timer);
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
        d =FalseAnswerHandler(c);
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

    private void OnDisable()
    {
        timerImage.localScale = new Vector3(timerScaleX, timerImage.localScale.y);

    }
}
