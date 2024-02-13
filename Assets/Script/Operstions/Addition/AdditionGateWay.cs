using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AdditionGateWay:MonoBehaviour
{
    public List<AdditionEntity> ListOfAdditions=new List<AdditionEntity>();
    public JsonConverter JsonConverter;
    public void Start()
    {
        var additionJsonObject = JsonConverter.GetAdditionJson();
        for (int i = 0; i < additionJsonObject.Count; i++)
        {
            var addition = new AdditionEntity();
            addition.NumberOne = (int) additionJsonObject[i]["NumberOne"];
            addition.NumberTwo = (int) additionJsonObject[i]["NumberTwo"];
            addition.Result = (int) additionJsonObject[i]["Answers"];
            ListOfAdditions.Add(addition);
        }
    }

    public AdditionEntity GetAdditionEntity()
    {
        int random = Random.Range(0, ListOfAdditions.Count);
        AdditionEntity additionEntity = ListOfAdditions[random];
        return additionEntity;
    }
}
