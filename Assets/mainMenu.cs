using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject startMenu; 
    public GameObject setting;
    public GameObject numberOfPlayer;
    public GameObject AboutUs;
    public AudioSource audioSource;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Onstart()
    {
        startMenu.gameObject.SetActive(false);
        audioSource.Play();
        numberOfPlayer.SetActive(true);
    }

    public void OnExit()
    {        

        Application.Quit();
    }

    public void Setting()
    {        audioSource.Play();

        startMenu.SetActive(false);
        setting.SetActive(true);
    }

    public void aboutUs()
    {
        startMenu.SetActive(false);
        audioSource.Play();
        AboutUs.SetActive(true);
    }

    public void OnSingle()
    {
        numberOfPlayer.SetActive(false);
        panel.SetActive(true);
    }
    




}
