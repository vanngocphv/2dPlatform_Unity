using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 2f;


    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, 180 * Time.deltaTime * _rotateSpeed);
    }
}
