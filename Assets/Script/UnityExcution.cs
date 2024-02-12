using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityExcution : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("AWAKE CALLED");
    }

    private void OnEnable()
    {
        Debug.Log("on Enable Called");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(Destroy());
    }

    public void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log("Update "); 
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this);
    }
    private void OnDisable()
    {
      Debug.Log("On Disable");   
    }

    private void OnDestroy()
    {
        Debug.Log("On Destroy");
    }
}
