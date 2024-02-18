using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerUIAnimtion : MonoBehaviour
{
    public UIManger UIManger;

    public Animator UiAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTrueAnswer()
    {
        UiAnimator.SetBool("TrueAnseers",false);
        UiAnimator.SetBool("TruneNextQuestion",true);
        UIManger.Winning();
    }

    public void OnWrongAnswer()
    {
        UiAnimator.SetBool("WrongAnswer",false);
        UiAnimator.SetBool("WrongNextQuestion",true);
        UIManger.Losing();
    }

}
