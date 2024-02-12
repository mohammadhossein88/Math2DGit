using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addition1 : MonoBehaviour
{
    private int _numberOne = 0;
    
    private int _numberTwo = 0;

    private int _falseAnswers = 0;

    private int _tureAnsewers = 0;
    private int _maxNumber = 100;
    
    private int _minNumber = 0;
    
    public void GenerateQuestionAddition()
    {
        _numberOne = Random.Range(_minNumber,_maxNumber);
        _numberTwo = Random.Range(_minNumber, _maxNumber);
        _tureAnsewers = _numberOne + _numberTwo;
        _falseAnswers = Random.Range(_tureAnsewers-11, _tureAnsewers+10);
    }
    public int GetNumberOneAddition()
    {
        return _numberOne;
    }

    public int GetNumberTwoAddition()
    {
        return _numberTwo;
    }

    public int GetTrueAnswerAddition()
    {
        return _tureAnsewers;
    }

    public int GetWrongAnswerAddition1()
    {
        return _falseAnswers;
    }

    
}
