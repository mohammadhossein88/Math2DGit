
using UnityEngine;
public class GameModeHandler : MonoBehaviour
{
    [Header("Class Reference")] [SerializeField]
    private trueAndFalse trueAndFalse;

    [SerializeField] private ChoiceTheRightAnswers choiceTheRightAnswers;
    [SerializeField] private equation _equation;
    public GameManger _GameManger;
    public UIManger uIManger;

    private GameModes _gameModes;


    private void OnEnable()
    {
        _gameModes = _GameManger.gameModes;
        SwitchGameMode();
    }

    public void NextQuestion()
    {
        SwitchGameMode();
    }

    private void SwitchGameMode()
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
    }

    private void equationHandler()
    {
        Debug.Log("Enter Eq Handelr ");
        uIManger.gameObject.SetActive(true);
        _equation.GenerateQuestionEquation();
    }

    private void ChoiceTheRightAnswers()
    {
        uIManger.gameObject.SetActive(true);
        choiceTheRightAnswers.GenerateQuestionChoiceTheRightAnswers(_GameManger.operstion);
    }

    private void HardHardCore()
    {
        
    }
    

}
