
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class ChoiceTheRightAnswersUI:MonoBehaviour
    {
        [SerializeField] private ChoiceTheRightAnswers _choiceTheRightAnswers;
        [Header("Question")]
        [SerializeField] public TMP_Text numberOne;
        [SerializeField] public TMP_Text numberTwo;
        [SerializeField] public TMP_Text operstText;
       
        // Start is called before the first frame update
        private void OnEnable()
        {
            
            numberOne.text = _choiceTheRightAnswers._numberOne.ToString();
            numberTwo.text = _choiceTheRightAnswers._numberTwo.ToString();
        }
        
        
    }
