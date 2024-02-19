using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChoiceTheRightAnswers : MonoBehaviour
{

    [SerializeField] private Addition1 addition1;
    [SerializeField] private Substraction subtraction;
    [SerializeField] private Multiply multiply;
    [SerializeField] private Division division;
    [SerializeField] private UIManger UIManger;
    [SerializeField] private Image trueButton;
    [SerializeField] private Image falseButton;
    [HideInInspector] public int _numberOne = 0;
    [HideInInspector] public int _numberTwo = 0;
    [HideInInspector] public int _ansewers = 0;
    [HideInInspector] public string _opText;
    
    [SerializeField] private GameObject choiceAnswerGameObject;
    [SerializeField] private ChoiceTheRightAnswersUI _choiceTheRightAnswersUI;
    [SerializeField] private Button[] answerButtons;
    [SerializeField] private TMP_Text[] answerButtonsText;
    [SerializeField] private Image[] answerButtonImage;
    private bool isTrue;
    public void GenerateQuestionChoiceTheRightAnswers(Operators operators)
    {
        for (int i = 0; i < answerButtonImage.Length; i++)
        {
            answerButtonImage[i].color=Color.white;
        }
        OperstionHandling(operators);

    }
    public void OperstionHandling(Operators operators)
    {
        if (operators == Operators.addition)
        {
            _opText = "+";
            addition1.GenerateQuestionAddition();
            TureAndFalse(addition1.GetNumberOneAddition(), addition1.GetNumberTwoAddition(),
                addition1.GetTrueAnswerAddition(), addition1.GetWrongAnswerAddition1());
        }
        else if (operators == Operators.substraction)
        {
            _opText = "-";
            subtraction.GenerateQuestion();
            TureAndFalse(subtraction.GetNumberOneSubstraction(), subtraction.GetNumberTwoSubstraction(),
                subtraction.GetTrueAnswerSubstraction(), subtraction.GetWrongAnswerSubstraction());
        }
        else if (operators == Operators.multiply)
        {
            _opText = "*";
            multiply.GenerateQuestionMultiply();
            TureAndFalse(multiply.GetNumberOneMultiply(), multiply.GetNumberTwoMultiply(),
                multiply.GetTrueAnswerMultiply(), multiply.GetWrongAnswerMultiply());
        }
        else if (operators == Operators.division)
        {
            _opText = "/";
            division.GenerateQuestionDivision();
            TureAndFalse(division.GetNumberOneDivision(), division.GetNumberTwoDivision(),
                division.GetTrueAnswerDivision(), division.GetWrongAnswerDivision());
        }

    }
    private void TureAndFalse(int num1,int num2,int tAnswer,int fAnswer)
    {
        _numberOne = num1;
        _numberTwo = num2;
        int random = Random.Range(0, 2);
        _ansewers = tAnswer;
        answerButtons[random].name = tAnswer.ToString();
        answerButtonsText[random].text = tAnswer.ToString();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i != random)
            {
                answerButtons[i].name = fAnswer.ToString();
                answerButtonsText[i].text = fAnswer.ToString();

            }
        }
        choiceAnswerGameObject.SetActive(true);
        _choiceTheRightAnswersUI.numberOne.text = num1.ToString();
        _choiceTheRightAnswersUI.numberTwo.text = num2.ToString();
        _choiceTheRightAnswersUI.operstText.text = _opText;
    }

    public void OnSelectedAnswer(GameObject buttonObject)
    {
        int selectedAnswer = Convert.ToInt32(buttonObject.name);
        string buttonName = buttonObject.name;
        if (selectedAnswer == _ansewers)
        {
            ChangeColorBaseOnAnswer(true, buttonName);
            UIManger.IncreaseScore();
        }
        else
        {
            ChangeColorBaseOnAnswer(false, buttonName);
            StartCoroutine(UIManger.DecreaseHealth());
        }
    }

    private void ChangeColorBaseOnAnswer(bool isRight,string buttonName)
    {
        for (int i = 0; i < answerButtonImage.Length; i++)
        {
            if (answerButtonImage[i].gameObject.name == buttonName)
            {
                if (isRight)
                {
                    answerButtonImage[i].color = Color.green;
                }
                else
                {
                    answerButtonImage[i].color = Color.red;
                }
            }
            else
            {
                if (isRight)
                {
                    answerButtonImage[i].color = Color.red;
                }
                else
                {
                    answerButtonImage[i].color = Color.green;
                }
            }
        }
    }
   

}
