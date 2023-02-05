using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePause : IUISystem
{
    private Button _continueButton;
    //private Button _returnToMenuButton;
    //private Text _currentLevel;
    public override void Init()
    {
        base.Init();
        
        GameObject canvas = GameObject.Find("Canvas");
        _rootUI = UnityToolkit.FindInChildren(canvas,"PauseUI");

        _continueButton = UIToolKits.FindChild<Button>(_rootUI, "ContinueButton");
        //_returnToMenuButton = UIToolKits.FindChild<Button>(_rootUI, "ReturnToMenuButton");
        //_currentLevel = UIToolKits.FindChild<Text>(_rootUI, "CurrentLevel");
        
        _continueButton.onClick.AddListener(HidePause);
        Hide();
    }

    public void ShowPause()
    {
        _rootUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void HidePause()
    {
        _rootUI.SetActive(false);
        Time.timeScale = 1;
    }
}
