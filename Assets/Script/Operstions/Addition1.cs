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
    public AdditionGateWay additionGateWay;
    public void GenerateQuestionAddition()
    {
        var question = additionGateWay.GetAdditionEntity();
        _numberOne = question.NumberOne;
        _numberTwo = question.NumberTwo;
        _tureAnsewers = question.Result;
        _falseAnswers = Random.Range(_tureAnsewers - 10, _tureAnsewers + 10);
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
