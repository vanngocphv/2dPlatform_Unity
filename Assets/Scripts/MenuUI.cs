using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button _StartButton;
    [SerializeField] private Button _QuitButton;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        _StartButton.onClick.AddListener(OnClickStartButton);
        _QuitButton.onClick.AddListener(OnClickQuitButton);
    }




    private void OnClickStartButton()
    {
        SceneManager.LoadScene(1);
    }

    private void OnClickQuitButton()
    {
        Application.Quit();
    }
}
