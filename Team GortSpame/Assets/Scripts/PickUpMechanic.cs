using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMechanic : MonoBehaviour
{
    private bool _isHolding = false;
    private GameObject _heldItem;
    private Transform _availableToPickup;
    [SerializeField]
    private LayerMask _pickupLayer;
    // Start is called before the first frame update
    void Start()
    {
        _heldItem = null;
        _availableToPickup = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isHolding)
        {
            if (Input.GetKeyDown(KeyCode.E))
                dropHeld();
        }
        else
        {
            checkAvailableItem();
            if (Input.GetKeyDown(KeyCode.E) && _availableToPickup)
                pickUp();
        }
    }

    private void checkAvailableItem()
    {
        Vector3 origin = transform.position;
        origin.y = 0;
        RaycastHit hit;
        if (Physics.SphereCast(origin, 0.1f, transform.forward, out hit, 1, _pickupLayer))
        {
            _availableToPickup = hit.transform;
            return;
        }

        _availableToPickup = null;
    }

    private void pickUp()
    {
        _availableToPickup.position = transform.position + new Vector3(0, 0.2f, 0) + transform.forward;
        _availableToPickup.SetParent(transform, true);
        _heldItem = _availableToPickup.gameObject;
        _isHolding = true;
        _availableToPickup = null;
    }

    private void dropHeld()
    {
        Transform heldTrans = _heldItem.transform;
        heldTrans.SetParent(null, true);
        Vector3 heldPos = heldTrans.position;
        heldPos.y = 0;
        heldTrans.position = heldPos;
        _isHolding = false;
        _heldItem = null;
    }
}
