using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float _speed;
    private float _normalSpeed = 0.04f;
    private float _slowSpeed = 0.02f;
    private float _sprintMultiplier = 1.5f;
    private float _jumpHeight = 0.6f;
    private float _gravity = 0.1f;
    private float _playerHeight = 0.0f;

    private bool _doGravity = false;

    private Vector2 _oldMousePos;
    private float _differenceX;
    private float _differenceY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        checkMoveRight();
        checkMoveLeft();
        checkMoveForward();
        checkMoveBack();
        mouseMovement();
        checkJumping();
        checkGravity();
    }

    void checkJumping()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _playerHeight == 0)
        {
            transform.Translate(0, _jumpHeight, 0);
            _playerHeight = _jumpHeight;
            _doGravity = true;
        }
    }
    void checkGravity()
    {
        if(_doGravity)
        {
            transform.Translate(0, -(_gravity), 0);
            _playerHeight = _playerHeight - _gravity;
            if(_playerHeight <= 0)
            {
                transform.Translate(0, _gravity, 0);
                _playerHeight = 0;
                _doGravity = false;
            }
        }
    }
    void checkMoveRight()
    {
        if(Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _speed = _slowSpeed;
            } else {
                _speed = _normalSpeed;
            }
            if(Input.GetKey(KeyCode.LeftShift))
            {
                _speed = _speed * _sprintMultiplier;
            }
            transform.Translate(0, 0, -(_speed));
            _speed = 0.002f;
        }
    }
    void checkMoveLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _speed = _slowSpeed;
            }
            else
            {
                _speed = _normalSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed = _speed * _sprintMultiplier;
            }
            transform.Translate(0, 0, _speed);
        }
    }
    void checkMoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _speed = _slowSpeed;
            }
            else
            {
                _speed = _normalSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed = _speed * _sprintMultiplier;
            }
            transform.Translate(_speed, 0, 0);
        }
    }
    void checkMoveBack()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _speed = _slowSpeed;
            }
            else
            {
                _speed = _normalSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed = _speed * _sprintMultiplier;
            }
            transform.Translate(-(_speed), 0, 0);
        }
    }

    void mouseMovement()
    {
        /*if (Input.mousePosition.x < _oldMousePos.x)
        {
            _differenceX = _oldMousePos.x - Input.mousePosition.x;
            transform.Rotate(new Vector3(-(_differenceX), 0, 0));
            Debug.Log("DifferenceX = " + _differenceX);
        }*/
        if (Input.mousePosition.x < _oldMousePos.x)
        {
            _differenceY = Input.mousePosition.x -_oldMousePos.x;
            transform.Rotate(new Vector3(0, _differenceY, 0));
            Debug.Log("DifferenceY = " + _differenceY);
        }
        /*if (Input.mousePosition.x > _oldMousePos.x)
        {
            _differenceX = _oldMousePos.x - Input.mousePosition.x;
            transform.Rotate(new Vector3(_differenceX, 0, 0));
            Debug.Log("DifferenceX = " + _differenceX);
        }*/
        if (Input.mousePosition.x > _oldMousePos.x)
        {
            _differenceY = Input.mousePosition.x - _oldMousePos.x;
            transform.Rotate(new Vector3(0, _differenceY, 0));
            Debug.Log("DifferenceY = " + _differenceY);
        }
        _oldMousePos = Input.mousePosition;
    }
}
