
using UnityEngine;
public class GameModeHandler : MonoBehaviour
{
    [Header("Class Reference")] [SerializeField]
    private trueAndFalse trueAndFalse;

    [SerializeField] private ChoiceTheRightAnswers choiceTheRightAnswers;
    [SerializeField] private equation _equation;
    [SerializeField] private hardcore hardcore;
    [SerializeField] private GameObject _forTwoplayer;
    
    
    public GameManger _GameManger;
    public UIManger uIManger;

    private GameModes _gameModes;
    private PlayingMod _playingMod;

    private void OnEnable()
    {
        _gameModes = _GameManger.gameModes;
        _playingMod = _GameManger.playerMod;
        _twoPlayer(_playingMod);
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
            case GameModes.Hardcore :
                HardCore();
                break;

            default:
                Debug.Log("Game Mode is not deffine ");
                break;
        }
    }

    public void TrueAndFalseHandler()
    {
        uIManger.gameObject.SetActive(true);
        trueAndFalse.GenerateQuestionTrueAndFalse(_GameManger.operstion);
    }

    public void equationHandler()
    {
        Debug.Log("Enter Eq Handelr ");
        uIManger.gameObject.SetActive(true);
        _equation.GenerateQuestionEquation();
    }

    public void ChoiceTheRightAnswers()
    {
        uIManger.gameObject.SetActive(true);
        choiceTheRightAnswers.GenerateQuestionChoiceTheRightAnswers(_GameManger.operstion);
    }

    private void HardCore()
    {
        uIManger.gameObject.SetActive(true);
        hardcore.GenerateQuestionHradcore();
    }

    private void _twoPlayer(PlayingMod playingMod)
    {
        if(playingMod == PlayingMod.TwoPlayer)
        {
            _forTwoplayer.SetActive(true);
        }
        
    }
    

}
