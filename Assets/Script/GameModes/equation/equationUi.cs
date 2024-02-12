using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class equationUi : MonoBehaviour
{
    [SerializeField] private equation _equation;
    [SerializeField] private TMP_Text numberOne;

    [SerializeField] private TMP_Text numberTwo;
    [SerializeField] private TMP_Text operstText;
    [SerializeField] private TMP_Text answerS;
    [SerializeField] private TMP_Text answerSA;
    private equation equation;
    [SerializeField] private GameObject Equation;
    [SerializeField] private Button[] _buttons;
    
   

    private void OnEnable()
    {
        numberOne.text = "a";
        numberTwo.text = "b";
       int trueAnswers= Random.Range(0, 2);
       _buttons[trueAnswers].name = _equation.numberOne.ToString();
       for (int i = 0; i < 2; i++)
       {
           if (i != trueAnswers)
           {
               _buttons[i].name = _equation.numberTwo.ToString();
           }
       }
        answerS.text = _equation.AnsewerS.ToString();
        answerSA.text = _equation.AnsewerA.ToString();
        equation.gameObject.SetActive(true);
        equation.onfalseAnsewer();
        equation.onfalseAnsewer();
    }

    public void OnAnswers(GameObject button)
    {
        _equation.AnswerChecker(button.name);
    }
    

}
