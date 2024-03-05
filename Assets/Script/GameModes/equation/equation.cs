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
    private equationUi _equationUi;
    private int _equation;
    private bool _isTrue;
    private int _MaxNumber = 100;
    private int _minNumber = 0;
    public void GenerateQuestionEquation()
    {
       
        numberTwo = Random.Range(_minNumber, _MaxNumber);
        numberOne=Random.Range(_minNumber, _MaxNumber);
      if (numberOne == numberTwo)
        {
           numberTwo = Random.Range(numberOne - 15, numberOne + 17);
        }
        AnsewerS =numberOne-numberTwo ;
        if (numberOne<numberTwo)
        {
            AnsewerS = numberTwo - numberOne;
        }
        AnsewerA = numberTwo + numberOne;
        equationGameObject.SetActive(true);
        
    }

    public void onavtive()
    {
        equationGameObject.SetActive(false);
        _equationUi.numberOne.text = "";
        _equationUi.numberTwo.text = "";
        _equationUi.text3.text = "";
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

    

