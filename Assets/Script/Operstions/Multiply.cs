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
    public multiplyGateWay multiplyGateWay;
    public void GenerateQuestionMultiply()
    {
        var muliplylist = multiplyGateWay.GetMultiplyEntity();
        _num1 = muliplylist.NumberOne;
        _num2 = muliplylist.NumberTwo;
        _trueNum = muliplylist.Result;
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
