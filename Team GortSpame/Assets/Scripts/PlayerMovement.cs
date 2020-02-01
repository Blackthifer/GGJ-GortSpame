using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float _speed = 0.04f;
    private float _sprintMultiplier = 1.5f;
    private bool _sprinting = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right;
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _sprinting = true;
        }
        
        transform.Translate(_speed * (_sprinting ? _sprintMultiplier : 1) * moveVector);

        _sprinting = false;
    }
}
