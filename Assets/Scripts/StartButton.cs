using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button startButton;
    private GameManager gameManagerScripti;

    void Start()
    {
        gameManagerScripti = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(SetStart);
    }

    void SetStart()
    {
        gameManagerScripti.StartGame();
    }
}
