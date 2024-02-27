using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettngPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mucMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//
    public void OnMusciChange(float value)
    {
        float r = value;
        mucMixer.audioMixer.SetFloat("Master", 0);
        Debug.Log(r);
    }
}
