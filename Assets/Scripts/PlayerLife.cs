using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 3;
    [SerializeField] private AudioSource _deadSource;

    private Rigidbody2D _rigidbody;

    private Animator animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            _deadSource.Play();
            animator.SetTrigger("triggerDead");
            _rigidbody.bodyType = RigidbodyType2D.Static;
            //this.gameObject.GetComponent<PlayerMovement>().IsDead(true);
        }
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
