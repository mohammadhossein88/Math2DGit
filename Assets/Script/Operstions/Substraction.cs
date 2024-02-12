using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Substraction : MonoBehaviour
{

    private int _numberOne = 0;
    
    private int _numberTwo = 0;

    private int _falseAnswers = 0;

    private int _tureAnsewers = 0;
    private int _maxNumber = 100;
    
    private int _minNumber = 0;
    
    public void GenerateQuestion()
    {
       _numberOne = Random.Range(_minNumber,_maxNumber); 
       _numberTwo = Random.Range(_minNumber,_maxNumber);
        if (_numberOne < _numberTwo)
        {
            int swape = _numberOne;
            _numberOne = _numberTwo;
            _numberTwo = swape;
           
        }

        _tureAnsewers = _numberOne - _numberTwo;
        _falseAnswers = Random.Range(_tureAnsewers-11, _tureAnsewers+10);
    }

    public int GetNumberOneSubstraction()
    {
        return _numberOne;
    }

    public int GetNumberTwoSubstraction()
    {
        return _numberTwo;
    }

    public int GetTrueAnswerSubstraction()
    {
        return _tureAnsewers;
    }

    public int GetWrongAnswerSubstraction()
    {
        return _falseAnswers;
    }
    
    
}
