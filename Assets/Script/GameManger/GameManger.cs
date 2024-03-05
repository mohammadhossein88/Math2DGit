using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum Operators
{
    addition,
    substraction,
    multiply,
    division
}

public enum GameModes
{
    TrueAndFalse,//0
    equation,//1
    ChoiseRightAnswer,//2
    Hardcore,
}

public enum Pages
{
    PlayerMode,
    GameMode,
    GameOperstionPage,
    Setting,
    aboutUs,
    
}

public enum PlayingMod
{
    SingelPlayer,
    TwoPlayer
}
public class GameManger : MonoBehaviour
{
    [Header("Game Panels")]
    [FormerlySerializedAs("Additoon")] public GameObject Gameplay;
    public GameObject panel;
    public GameObject playerModePanel;
    public GameObject gameModesPanel;
    public GameObject questionPanel;
    public GameObject buttonTwoPlayer;
    public GameObject buttonPlayer;
    [Header("Game Mode Text")]
    public TMP_Text gameModeText;
    [Header("Audio")]
    public AudioSource clickSound;
    [HideInInspector]public Operators operstion;
    [HideInInspector] public GameModes gameModes;
    [HideInInspector] public PlayingMod playerMod;
    private Pages _pages;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(DateTime.Now);
        _pages = Pages.GameMode;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Prees Ecp");
            SwitchPage();
        }

    }

    private void SwitchPage()
    {
        if (_pages == Pages.PlayerMode)
        {
            ActiveDeActiveGameMode(false);
        }
        if (_pages == Pages.GameOperstionPage)
        {
            Debug.Log("Switch Page ");
            ActiveDeActiveOperstionPage(false);
            _pages = Pages.GameMode;
            gameModeText.text = "";
        }
    }
    public void onclick(int mode)
    {
        clickSound.Play();
        gameModes = (GameModes) mode;
        _pages = Pages.GameOperstionPage;
        TranslateGameMod();
        ActiveDeActiveOperstionPage(true);
        Debug.Log("Game mode is"+ gameModes);

    }

    private void ActiveDeActiveOperstionPage(bool isAcivte)
    {
        
        Debug.Log("Acitve and Deactive");
        panel.SetActive(isAcivte);
        gameModesPanel.SetActive(!isAcivte);
        
    }

    private void ActiveDeActiveGameMode(bool isActive)
    {
        playerModePanel.SetActive(isActive);
        gameModesPanel.SetActive(!isActive);
        
    }
    public void OnGameModeOperstion(int op)
    {
        clickSound.Play();
       operstion = (Operators)op;
       Debug.Log($"Game Operstion is {operstion}");
       Gameplay.gameObject.SetActive(true);
       panel.gameObject.SetActive(false);
    }

    private void TranslateGameMod()
    {
        switch (gameModes)
        {
            case GameModes.ChoiseRightAnswer:
                gameModeText.text = Fa.faConvert("چند گزینه ای");
                break;
        }
    }

   
    public void OnPlayerModeButton(int playerType)
    {
        playerMod = (PlayingMod) playerType;
        _pages = Pages.PlayerMode;
        SwitchPage();
        if (playerMod == (PlayingMod) 1)
        { Debug.Log("twoPlayer");
            buttonTwoPlayer.SetActive(true);
        }
        else
        {
            Debug.Log("single");
            buttonPlayer.SetActive(true);
            Debug.Log("panel is set");
        }
    }
    
}


