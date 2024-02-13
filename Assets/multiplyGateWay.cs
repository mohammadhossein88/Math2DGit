using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplyGateWay : MonoBehaviour
{
    public JsonConverter JsonConverter;
    public List<multiplyEntity> Listmultiply =new List<multiplyEntity>();
    // Start is called before the first frame update
    public void Start()
    {
        var mJsonObject = JsonConverter.GetMultiplyJson();
        for (int i = 0; i < mJsonObject.Count; i++)
        {
            var multiply = new multiplyEntity();
            multiply .NumberOne = (int) mJsonObject[i]["number1"];
            multiply .NumberTwo = (int) mJsonObject[i]["number2"];
            multiply .Result = (int) mJsonObject[i]["number3"];
            Listmultiply.Add(multiply);
        }
    }
    public multiplyEntity GetMultiplyEntity()
    {
        int random = Random.Range(0, Listmultiply.Count);
        multiplyEntity multiplyEntity =Listmultiply[random];
        return multiplyEntity;
    }
}
