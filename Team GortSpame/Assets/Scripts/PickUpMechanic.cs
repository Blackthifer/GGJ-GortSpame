using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMechanic : MonoBehaviour
{
    private bool _isHolding = false;
    private GameObject _heldItem;
    private GameObject _pickUpable;
    [SerializeField]
    private LayerMask PickupLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkHolding();
    }

    void checkHolding()
    {
        if (_isHolding == false)
        {
            Vector3 _origin = transform.position;
            _origin.y = 0;
            RaycastHit hit;
            if (Input.GetKey(KeyCode.E))
            {
                if (Physics.SphereCast(_origin, 0.1f, transform.forward, out hit, 1, PickupLayer))
                {
                    pickUp(hit.transform);
                    Debug.Log("I am noticed, senpai!");
                }
            }
        }
    }

    void pickUp(Transform itemToPick)
    {
        itemToPick.Translate(0, 1, 0);
        Debug.Log("I have moved, senpai!");
    }
}
