using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Division : MonoBehaviour
{
    // Start is called before the first frame update
    private int _numberOne = 0;
    
    private int _numberTwo = 0;

    private int _falseAnswers = 0;

    private int _tureAnsewers = 0;
    private int _maxNumber = 100;
    
    private int _minNumber = 2;
    private int[] _notPrimeNumbers = new int[75];
    public void GenerateQuestionDivision()
    {
        _numberOne = Random.Range(_minNumber,_maxNumber);
        _numberTwo = Random.Range(_minNumber, _maxNumber);
        NotPrimeNumbers();
        DivisibilityNum();
        _tureAnsewers = _numberOne / _numberTwo;
        _falseAnswers =  (_numberOne - 1) * _numberTwo;
    }
    public int GetNumberOneDivision()
    {
        return _numberOne;
    }

    public int GetNumberTwoDivision()
    {
        return _numberTwo;
    }

    public int GetTrueAnswerDivision()
    {
        return _tureAnsewers;
    }

    public int GetWrongAnswerDivision()
    {
        return _falseAnswers;
    }
    private int NotPrimeNumbers()
    {
        int[] notPrime = new int[75];
        int counter1 = 0;
            
        for (int i = 2; i <=_maxNumber; i++)
        {
            for (int j = 2; j <=i/2; j++)
            {
                if (i%j==0)
                {
                    notPrime[counter1] = i;
                    counter1++;
                    break;
                }
                    
            }
                
        }
        int r1 = Random.Range(0, counter1);
        return notPrime[r1];
    }
    private int DivisibilityNum()
    {
        int[] divisibility = new int[_numberOne / 2];
        int counter = 0;
        for (int i = 2; i <= _numberOne/2; i++)
        {
            if (_numberOne % i == 0)
            {
                Debug.Log("i"+i);
                divisibility[counter] = i;
                counter++;
            }
        }

        counter--; 
        int r = Random.Range(0, (counter));
        return divisibility[r];
    }

}
