using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManger : MonoBehaviour
{
    public AudioClip[] GameAudioClip;
    public AudioSource gameSfx;
    public AudioSource gameSfxWin;
    public AudioSource gameSfxLose;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayeSFX(int sfxindex)
    {
        gameSfx.clip = GameAudioClip[sfxindex];
        gameSfx.Play();
        gameSfxWin.clip=GameAudioClip[sfxindex];
        gameSfxWin.Play();
    }

    public void PlaySfxWin(int sfxindex)
         {
             gameSfxWin.clip=GameAudioClip[sfxindex];
             gameSfxWin.Play();
         }
    public void PlaySfxLose(int sfxindex)
    {
        gameSfxLose.clip=GameAudioClip[sfxindex];
        gameSfxLose.Play();
    }
}
