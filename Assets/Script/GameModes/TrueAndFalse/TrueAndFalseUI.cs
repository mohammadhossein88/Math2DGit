using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrueAndFalseUI : MonoBehaviour
{
    [SerializeField] private trueAndFalse trueAndFalse;
    [SerializeField] private TMP_Text numberOne;

    [SerializeField] private TMP_Text numberTwo;
    [SerializeField] private TMP_Text operstText;
    [SerializeField] private TMP_Text answers;

    [SerializeField] private Button _button1;

    [SerializeField] private Button _button2;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _button1.onClick.AddListener(OnButton1Click);
        _button2.onClick.AddListener(OnButton2Click);
        numberOne.text = trueAndFalse._numberOne.ToString();
        numberTwo.text = trueAndFalse._numberTwo.ToString();
        answers.text = trueAndFalse._ansewers.ToString();
    }
    

    private void OnButton1Click()
    {
        trueAndFalse.OnTrueAnswer();
    }

    private void OnButton2Click()
    {
        trueAndFalse.OnFlaseAnswer();
    }
}
