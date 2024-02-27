using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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
    GameMode,
    GameOperstionPage,
    Setting,
    aboutUs,
    
}
public class GameManger : MonoBehaviour
{

    public Operators operstion;
    public GameModes gameModes;
    public TMP_Text gameModeText;
    [FormerlySerializedAs("Additoon")] public GameObject Gameplay;
    public GameObject panel;
    public GameObject buttons1;
    public AudioSource clickSound;
    private Pages _pages;
    // Start is called before the first frame update
    void Start()
    {
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
        buttons1.SetActive(!isAcivte);
        
    }
    public void OnGameModeOperstion(int op)
    {
        clickSound.Play();
       operstion = (Operators)op;
       Debug.Log($"Game Operstion is {operstion}");
       Gameplay.gameObject.SetActive(true);
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
}
