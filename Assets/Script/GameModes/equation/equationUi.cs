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
    [SerializeField] private TMP_Text text3;
    [SerializeField]  equation equation;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] buttonsText;
    

    private void OnEnable()
    {
        numberOne.text = "a+b=" + equation.AnsewerA.ToString();
        numberTwo.text = "a-b="+equation.AnsewerS.ToString();
        text3.text = "a?".ToString();
       int trueAnswers= Random.Range(0, 2);
       _buttons[trueAnswers].name = _equation.numberOne.ToString();
       buttonsText[trueAnswers].text = _equation.numberOne.ToString();
       for (int i = 0; i < 2; i++)
       {
           if (i != trueAnswers)
           {
               
               _buttons[i].name = _equation.numberTwo.ToString();
               buttonsText[i].text = _equation.numberTwo.ToString();
           }
       }
        
        equation.gameObject.SetActive(true);
        
    }

    public void OnAnswers(GameObject button)
    {
        
        _equation.AnswerChecker(button.name);
    }
    

}
