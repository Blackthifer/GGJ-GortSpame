using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private ShowPrompt hud;
    private float _triggerRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        _triggerRadius = transform.GetChild(1).GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        if ((transform.position - playerPos).magnitude < _triggerRadius)
        {
            hud.NeedToShow(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PauseMenu.GameIsPaused = true;
                Cursor.lockState = CursorLockMode.None;
                endScreen.SetActive(true);
            }
        }
        else
        {
            hud.NeedToShow(false);
        }
    }
}
