using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class equation : MonoBehaviour
{
    [SerializeField] private UIManger uIManger;
    [SerializeField] private GameObject equationGameObject;
    [HideInInspector]public int numberOne = 0;
    [HideInInspector]public int AnsewerA = 0;
    [HideInInspector]public int AnsewerS = 0;
    [HideInInspector]public int numberTwo = 0;
    private int _equation;
    private bool _isTrue;
    private int _MaxNumber = 100;
    private int _minNumber = 0;
    public void GenerateQuestionEquation()
    {
       
        numberTwo = Random.Range(_minNumber, _MaxNumber);
        numberOne=Random.Range(_minNumber, _MaxNumber);
        AnsewerS =numberOne-numberTwo ;
        if (numberOne<numberTwo)
        {
            AnsewerS = numberTwo - numberOne;
        }
        AnsewerA = numberTwo + numberOne;
        equationGameObject.SetActive(true);
        
    }

    public void AnswerChecker(string answer)
    {
        int ans = Convert.ToInt32(answer);
        if (ans == numberOne)
        {
            uIManger.IncreaseScore();

        }
        else
        {
            StartCoroutine(uIManger.DecreaseHealth());

        }
    }
  
        
}

    

