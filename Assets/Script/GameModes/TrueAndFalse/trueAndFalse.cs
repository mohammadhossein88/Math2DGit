using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class trueAndFalse : MonoBehaviour
{
    
    
    [SerializeField]private Addition1 addition1; 
    [SerializeField]private Substraction subtraction; 
    [SerializeField] private Multiply multiply;
    [SerializeField]private Division division;
    [SerializeField] private UIManger UIManger;
    [SerializeField] private GameObject trueAndFalseGameObject;
    [SerializeField] private TureAndFalseUI trueAndFalseUI;
    [SerializeField] private Image trueButton;
    [SerializeField] private Image falseButton;
    [SerializeField] private Image trueButtonNum1;
    [SerializeField] private Image falseButtonNum1;
    [SerializeField] private Image trueButtonNum2;
    [SerializeField] private Image falseButtonNum2;
    
    [HideInInspector]public int _numberOne = 0;
    [HideInInspector]public int _numberTwo = 0;
    [HideInInspector]public int _ansewers = 0;
    [HideInInspector] public string _opText;
     private int _falseOrTrue;
     private bool isTrue;
     //private bool _isFirstPlayer;
    public void GenerateQuestionTrueAndFalse(Operators operators)
    {
        trueButton.color=Color.white;
        falseButton.color = Color.white;
        OperstionHandling(operators);

    }

    public void OperstionHandling(Operators operators)
    {
        if (operators == Operators.addition)
        {
            _opText = "+";
            addition1.GenerateQuestionAddition();
            TureAndFalse(addition1.GetNumberOneAddition(),addition1.GetNumberTwoAddition(),addition1.GetTrueAnswerAddition(),addition1.GetWrongAnswerAddition1());
        }
        else if (operators == Operators.substraction)
        {
            _opText = "-";
            subtraction.GenerateQuestion();
            TureAndFalse(subtraction.GetNumberOneSubstraction(),subtraction.GetNumberTwoSubstraction(),subtraction.GetTrueAnswerSubstraction(),subtraction.GetWrongAnswerSubstraction());
        }
        else if (operators == Operators.multiply)
        {
            _opText = "*";
            multiply.GenerateQuestionMultiply();
            TureAndFalse(multiply.GetNumberOneMultiply(),multiply.GetNumberTwoMultiply(),multiply.GetTrueAnswerMultiply(),multiply.GetWrongAnswerMultiply());
        }
        else if (operators == Operators.division)
        {
            _opText = "/";
            division.GenerateQuestionDivision();
            TureAndFalse(division.GetNumberOneDivision(),division.GetNumberTwoDivision(),division.GetTrueAnswerDivision(),division.GetWrongAnswerDivision());
        }
        
    }

    private void TureAndFalse(int num1,int num2,int tAnswer,int fAnswer)
    {
        _numberOne = num1;
        _numberTwo = num2;
        //1-4 change => 1,10=> 1,100
        _falseOrTrue = Random.Range(1, 4);
        
        if (_falseOrTrue%2==0)
        {
            isTrue = true;
            _ansewers = tAnswer;
        }

        if (_falseOrTrue%2==1)
        {
            isTrue = false;
            _ansewers = fAnswer;
            //false
        }
        trueAndFalseGameObject.SetActive(true);
        trueAndFalseUI.numberOne.text = num1.ToString();
        trueAndFalseUI.numberTwo.text = num2.ToString()+"=";
        trueAndFalseUI.ansewers.text = _ansewers.ToString();
        trueAndFalseUI.opertor.text = _opText;
    }

    public void onavtive()
    {
        trueAndFalseGameObject.SetActive(false);
        trueAndFalseUI.numberOne.text = "";
        trueAndFalseUI.numberTwo.text = "";
        trueAndFalseUI.ansewers.text = "";
        trueAndFalseUI.opertor.text = "";
    }

    public void OnTrueAnswer()
    {
        if (isTrue)
        {
            trueButton.color=Color.green;
            falseButton.color = Color.red;
            UIManger.IncreaseScore();
        }
        else
        {
            trueButton.color=Color.red;
            falseButton.color = Color.green;
            StartCoroutine(UIManger.DecreaseHealth());
        }
    }
    

    public void OnFlaseAnswer()
    {
        if (isTrue == false)
        {
            trueButton.color=Color.green;
            falseButton.color = Color.red;
            UIManger.IncreaseScore();

        }
        else
        {
            trueButton.color=Color.red;
            falseButton.color = Color.green;
            StartCoroutine(UIManger.DecreaseHealth());
        }
    }

    private void OnSingleAnswerOrTwoPlayer(bool isFirst)
    {
        if (isFirst == true)
        {
            if (isTrue == false)
            {
                trueButtonNum1.color=Color.green;
                falseButtonNum1.color = Color.red;
                UIManger.IncreaseScoreNum2();

            }
            else
            {
                trueButtonNum1.color=Color.red;
                falseButtonNum1.color = Color.green;
                StartCoroutine(UIManger.DecreaseHealthNum2());
            }
        }
            
        

        if (isFirst!=true)
        {
            
            if (isTrue == false)
            {
                trueButtonNum2.color=Color.green;
                falseButtonNum2.color = Color.red;
                UIManger.IncreaseScore();

            }
            else
            {
                trueButtonNum2.color=Color.red;
                falseButtonNum2.color = Color.green;
                StartCoroutine(UIManger.DecreaseHealth());
            }
            
            
        }
        UIManger.winningTwoPlayer();
        UIManger.losingTwoPlayer();


    }
  
}
