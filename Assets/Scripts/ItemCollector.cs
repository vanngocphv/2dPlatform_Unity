using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentPoint;
    [SerializeField] private AudioSource _pickupSource;
    private int currentCherries = 0;

    private void Start()
    {
        _currentPoint.text = 0.ToString();
    }

    //trigger check enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            _pickupSource.Play();
            //pickup item, check
            Destroy(collision.gameObject);

            //up cherry
            currentCherries++;
            _currentPoint.text = currentCherries.ToString();

            
        }
    }
}
