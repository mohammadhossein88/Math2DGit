using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : MonoBehaviour
{
    private int _num1=0;
    private int _num2=0;
    private int _trueNum;
    private int _falseNum;
    private int minNum=2;
    private int maxNum=20;
    public void GenerateQuestionMultiply()
    {
        _num1 = Random.Range(minNum,maxNum); 
        _num2 = Random.Range(minNum,maxNum);
        _trueNum = _num1 * _num2;
        _falseNum = (_num1 - 1) * _num2;
    }
    public int GetNumberOneMultiply()
    {
        return _num1;
    }

    public int GetNumberTwoMultiply()
    {
        return _num2;
    }

    public int GetTrueAnswerMultiply()
    {
        return _trueNum;
    }

    public int GetWrongAnswerMultiply()
    {
        return _falseNum;
    }
   
}
