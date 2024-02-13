using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class JsonConverter : MonoBehaviour
{
    private const string AdditionJsonName="AdditoinJsoan";
    private const string MultiplyJsonName="multiply";
    private string SubstractionJsonNam;
    private string DivisionJsonName;
    
    private List<JObject> _additionObjects = new List<JObject>();
    private List<JObject> _multiplyObjects=new List<JObject>();
    private List<JObject> _substractionObjects;
    private List<JObject> _divisionObjects;
    public void Start()
    {
        string additionJson = Resources.Load(AdditionJsonName).ToString();
        string multiplyJson = Resources.Load(MultiplyJsonName).ToString();
      //  string substractionJson = Resources.Load(SubstractionJsonNam).ToString();
        //string divisionJson = Resources.Load(DivisionJsonName).ToString();
        _additionObjects = JArray.Parse(additionJson).ToObject<List<JObject>>();
        _multiplyObjects = JArray.Parse(multiplyJson).ToObject<List<JObject>>();

    }

    public List<JObject> GetAdditionJson()
    {
        return _additionObjects;
    }

    public List<JObject> GetMultiplyJson()
    {
        return _multiplyObjects;
        
    }
}
