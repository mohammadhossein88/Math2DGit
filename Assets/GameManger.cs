using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1 +
//2 -
//3 *
//4 /
public class GameManger : MonoBehaviour
{

    public int operstion;

    public GameObject Additoon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameModeOperstion(int op)
    {
        operstion = op;
        Additoon.gameObject.SetActive(true);
    }
}
