using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private AudioSource finishAudio;
    private bool isFinish = false;

    private void Start()
    {
        finishAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFinish)
        {
            isFinish = true;
            finishAudio.Play();
            Invoke("OnCompleteGame", 2f);
        }
    }


    private void OnCompleteGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        nextSceneIndex = nextSceneIndex >= SceneManager.sceneCountInBuildSettings ? 1 : nextSceneIndex;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
