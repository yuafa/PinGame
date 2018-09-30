using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    private Button startButton;
    private Button autoButton;
    private Button exitButton;

    private void Start()
    {
        startButton = transform.Find("StartButton").GetComponent<Button>();
        autoButton = transform.Find("AutoButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
        autoButton.onClick.AddListener(AutoGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        GameMode.instance.mode = Mode.Normal;
        SceneManager.LoadScene("02Game");
    }

    private void AutoGame()
    {
        GameMode.instance.mode = Mode.Auto;
        SceneManager.LoadScene("02Game");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("01Main");
        }
    }

}
