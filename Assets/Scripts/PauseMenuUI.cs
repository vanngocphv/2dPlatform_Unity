using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    public static PauseMenuUI instance { get; private set; }
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _quitButton;

    private bool isShow = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance= this;
    }
    private void Start()
    {
        _continueButton.onClick.AddListener(OnClickContinue);
        _menuButton.onClick.AddListener(OnClickMenu);
        _quitButton.onClick.AddListener(OnClickQuit);

        HideObjects();
    }
    private void Update()
    {
    }

    private void OnClickContinue()
    {
        isShow = !isShow;
        HideObjects();
    }
    private void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void OnClickQuit()
    {
        Application.Quit();
    }


    private void HideObjects()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    private void ShowObjects()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void ActiveObject()
    {
        isShow = !isShow;
        if (isShow) { ShowObjects(); }
        if (!isShow) { HideObjects(); }
    }
}
