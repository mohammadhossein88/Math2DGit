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

    [SerializeField] private Button _button1;

    [SerializeField] private Button _button2;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        numberOne.text = "a";
        numberTwo.text = "b";
        answerS.text = _equation.AnsewerS.ToString();
        answerSA.text = _equation.AnsewerA.ToString();
    }

}
