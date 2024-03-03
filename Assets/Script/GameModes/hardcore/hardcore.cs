using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class hardcore : MonoBehaviour
{
    // Start is called before the first frame update
    private int _a;
    public GameModeHandler GameModeHandler;
    public UIManger UIManger;
   

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
         GameModeHandler.TrueAndFalseHandler(); 
      }
      
      else if (_a % 2 == 1)
      {
          if (_a % 5 == 0)
          {
              GameModeHandler.equationHandler();
          }
          else
          {
              GameModeHandler.ChoiceTheRightAnswers();
          }

      
          
      }

    }

 
}
