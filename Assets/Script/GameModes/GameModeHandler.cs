
using UnityEngine;
public class GameModeHandler : MonoBehaviour
{
    [Header("Class Reference")]
    [SerializeField]private trueAndFalse trueAndFalse;

    [SerializeField] private ChoiceTheRightAnswers choiceTheRightAnswers;
    [SerializeField] private equation _equation;
    public GameManger _GameManger;
    public OperstionHandler operstionHandler;
    public GameManger gameManger;
    public UIManger uIManger;
    
  

    private GameModes _gameModes;
    public int _numberOne = 0;
    private int _numberTwo = 0;
    private int _Answers = 0;
    private int _AnswerA = 0;
    private Operators operstion;
    
    

    private void OnEnable()
    {
        _gameModes = _GameManger.gameModes;
        SwitchGameMode();
    }

    public void NextQuestion()
    {
        SwitchGameMode();
    }
    private void  SwitchGameMode()
    {
        switch (_gameModes)
        {
            case GameModes.ChoiseRightAnswer:
                ChoiceTheRightAnswers();
                break;
            case GameModes.equation:
                equationHandler();
                break;
            case GameModes.TrueAndFalse:
                TrueAndFalseHandler();
                break;
            
            default:
                Debug.Log("Game Mode is not deffine ");
                break;
        }
    }

    private void TrueAndFalseHandler()
    {
      
            uIManger.gameObject.SetActive(true);
            trueAndFalse.GenerateQuestionTrueAndFalse(_GameManger.operstion);
            _numberOne = trueAndFalse._numberOne;
            _numberTwo = trueAndFalse._numberTwo;
            _Answers = trueAndFalse._ansewers;
            
        
    }
    private void equationHandler()
    {
      
        uIManger.gameObject.SetActive(true);
        _equation.GenerateQuestionEquation();
        _numberOne = _equation.numberOne;
        _numberTwo = _equation.numberTwo;
        _Answers = _equation.AnsewerS;
        _AnswerA = _equation.AnsewerA;


    }

    private void ChoiceTheRightAnswers()
    {   uIManger.gameObject.SetActive(true);
        choiceTheRightAnswers.GenerateQuestionChoiceTheRightAnswers(_GameManger.operstion);
        _numberOne = choiceTheRightAnswers._numberOne;
        _numberTwo = choiceTheRightAnswers._numberTwo;
        _Answers = choiceTheRightAnswers._ansewers;
        
    }

    private void HardHardCore()
    {
        
    }
    

}
