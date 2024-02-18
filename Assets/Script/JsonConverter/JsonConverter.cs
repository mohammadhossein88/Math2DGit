using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class JsonConverter : MonoBehaviour
{
    private const string AdditionJsonName="AdditoinJson";
    private const string MultiplyJsonName="multiply";
    private string SubstractionJsonNam;
    private string DivisionJsonName;
    
    private List<JObject> _additionObjects = new List<JObject>();
    private List<JObject> _multiplyObjects=new List<JObject>();
    private List<JObject> _substractionObjects;
    private List<JObject> _divisionObjects;
    
    public void Start()
    {
       
        

    }

    public List<JObject> GetAdditionJson()
    {
        string additionJson = Resources.Load(AdditionJsonName).ToString();
        _additionObjects = JArray.Parse(additionJson).ToObject<List<JObject>>();
        return _additionObjects;
    }

    public List<JObject> GetMultiplyJson()
    {
        string multiplyJson = Resources.Load(MultiplyJsonName).ToString();
        _multiplyObjects = JArray.Parse(multiplyJson).ToObject<List<JObject>>();
        return _multiplyObjects;
        
    }
}
