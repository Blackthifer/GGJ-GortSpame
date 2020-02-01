using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _virtualRotation;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        _virtualRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused == true)
        {
            return;
        }
        else
        {
            handleRotation();
        }
    }
    
    private void handleRotation()
    {
        Transform myTrans = transform;
        Vector3 newMousePos = Input.mousePosition;
        float yRot = (newMousePos.x / (float) Screen.width) * 360f - 180f;
        myTrans.parent.Rotate(new Vector3(0, yRot - _virtualRotation.y, 0));
        _virtualRotation.y = yRot;
        _virtualRotation.x = (newMousePos.y / (float) Screen.height) * -180f + 90f;
        float xRot = Mathf.Clamp(_virtualRotation.x, -85, 85);
        myTrans.eulerAngles = new Vector3(xRot, _virtualRotation.y, _virtualRotation.z);
    }
}
