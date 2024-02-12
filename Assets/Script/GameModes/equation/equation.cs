using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equation : MonoBehaviour
{
    [SerializeField]private Addition1 addition1; 
    [SerializeField]private Substraction subtraction; 
    [SerializeField] private UIManger uIManger;
    [SerializeField] private GameObject equationGameObject;
    [HideInInspector]public int numberOne = 0;
    [HideInInspector]public  int tureAnsewers = 0;
    [HideInInspector]public int AnsewerA = 0;
    [HideInInspector]public int AnsewerS = 0;
    [HideInInspector]public int numberTwo = 0;
    [HideInInspector] public int falseAnswers;
    [HideInInspector] public string opText;
    private int _equation;
    private bool _isTrue;
    private int _MaxNumber = 100;
    
    private int _minNumber = 0;

    void Start()
    {
        numberTwo = Random.Range(_minNumber, _MaxNumber);
        AnsewerS=Random.Range(_minNumber, _MaxNumber);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateQuestionEquation()
    {
        AnsewerS = numberTwo - numberOne;
        if (numberOne<numberTwo)
        {
            AnsewerS = numberOne - numberTwo;
        }

        AnsewerA = numberTwo + numberOne;

    } 
        
}

    

