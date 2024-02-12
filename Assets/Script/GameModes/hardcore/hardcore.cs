using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hardcore : MonoBehaviour
{
    // Start is called before the first frame update
    private int _a;
    public GameObject trueandfalse;
    public trueAndFalse Trueandfalse;
    public equation equation;
    public GameObject Equation;
    public UIManger UIManger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateQuestionHradcore()
    {
      _a = Random.Range(1, 100);
      if (_a % 2 == 0)
      {
          int random = Random.Range(0, 4);
          trueandfalse.gameObject.SetActive(true);
          Trueandfalse.OperstionHandling((Operators)random);
          UIManger.gameObject.SetActive(true);

      }
      
      else if (_a%2==1)
      {
          Equation.gameObject.SetActive(true);
          equation.GenerateQuestionEquation();
          UIManger.gameObject.SetActive(true);
          
      }

    }
}
