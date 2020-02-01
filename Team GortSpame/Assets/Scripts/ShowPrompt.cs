using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrompt;

    // Start is called before the first frame update
    void Start()
    {
        PickUpMechanic.OnPickupFoundEvent += NeedToShow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PickUpMechanic.OnPickupFoundEvent -= NeedToShow;
    }

    public void NeedToShow(bool show)
    {
        buttonPrompt.SetActive(show);
    }
}
