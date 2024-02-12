using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Exsmaple : MonoBehaviour
{
    private string json;
    private List<int> number = new List<int>();
    public QuestionListAddition QuestionListAddition;
    // Start is called before the first frame update
    void Start()
    {
        ListTest();
        var a = Resources.Load("AdditoinJson");
        var ab=JArray.Parse(a.ToString()).ToObject<List<JObject>>();
        for (int i = 0; i < ab.Count; i++)
        {
            var numberOne = (int)ab[i]["NumberOne"];
            var numberTwo = (int)ab[i]["NumberTwo"];
            var numberThree = (int)ab[i]["Answers"];
            AdditionQuestions sc = ScriptableObject.CreateInstance<AdditionQuestions>();
            sc.numberOne = numberOne;
            sc.numberTwo = numberTwo;
            sc.anwers = numberThree;
            QuestionListAddition.AdditionQuestionsList.Add(sc);
            
        }
        
    }

    //m Update is called once per frame
    void Update()
    {
        
    }
    public void ListTest()

    {
        number.Add(3);
        number.Add(4);
        number.Add(5);
        for (int i = 0; i < number.Count; i++)
        {
            Debug.Log(number[i]);
        }
        number.Remove(3);
        for (int i = 0; i < number.Count; i++)
        {
            Debug.Log(number[i]);
        }

        Debug.Log(        number.Contains(3)
            );
        number.Clear();
        for (int i = 0; i < number.Count; i++)
        {
            Debug.Log(number[i]);
        }
    }
}
