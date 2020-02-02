using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.1f, 5)] public float RotationSpeed = 1;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        handleRotation();
    }
    
    private void handleRotation()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Transform myTrans = transform;
        myTrans.parent.Rotate(new Vector3(0, mouseInput.x * RotationSpeed, 0));
        myTrans.Rotate(new Vector3(-mouseInput.y * RotationSpeed, 0, 0));
    }
}
