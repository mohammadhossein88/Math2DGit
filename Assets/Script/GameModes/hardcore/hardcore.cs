using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class hardcore : MonoBehaviour
{
    // Start is called before the first frame update
    private int _a;
    public GameObject trueandfalse;
    public trueAndFalse Trueandfalse;
    public ChoiceTheRightAnswers ChoiceTheRightAnswers;
    public GameObject choiceTheRightAnswers;
    public equation equation;
    public GameObject Equation;
    public UIManger UIManger;
    public Operators operators;

    private void OnEnable()
    {
        GenerateQuestionHradcore();
        UIManger.SetHealth(1);


    }
    public void GenerateQuestionHradcore()
    {
      _a = Random.Range(1, 100);
      if (_a % 2 == 0)
      {
          trueandfalse.gameObject.SetActive(true);
         Trueandfalse .GenerateQuestionTrueAndFalse(operators);
          UIManger.gameObject.SetActive(true);

      }
      
      else if (_a % 2 == 1)
      {
          if (_a % 5 == 0)
          {
              Equation.gameObject.SetActive(true);
              equation.GenerateQuestionEquation();
              UIManger.gameObject.SetActive(true);
          }
          else
          {
              choiceTheRightAnswers.gameObject.SetActive(true);
              ChoiceTheRightAnswers.GenerateQuestionChoiceTheRightAnswers(operators);
          }

      
          
      }

    }

 
}
