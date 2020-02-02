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

    public delegate void FoundPickup(bool found);
    public static event FoundPickup OnPickupFoundEvent;
    
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
        origin.y -= 1;
        origin -= transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, 1f, transform.forward, out hit, 2, _pickupLayer))
        {
            _availableToPickup = hit.transform;
            _availableToPickup.GetComponent<MaterialSwapper>().SwapMaterial(true);
            OnPickupFoundEvent?.Invoke(true);
            return;
        }
        
        if(_availableToPickup)
            _availableToPickup.GetComponent<MaterialSwapper>().SwapMaterial(false);
        _availableToPickup = null;
        OnPickupFoundEvent?.Invoke(false);
    }

    private void pickUp()
    {
        _availableToPickup.position = transform.position + transform.forward;
        _availableToPickup.SetParent(transform, true);
        _heldItem = _availableToPickup.gameObject;
        _isHolding = true;
        _availableToPickup.GetComponent<MaterialSwapper>().SwapMaterial(false);
        _availableToPickup = null;
    }

    private void dropHeld()
    {
        Transform heldTrans = _heldItem.transform;
        heldTrans.SetParent(null, true);
        Vector3 heldPos = heldTrans.position;
        RaycastHit hit;
        Physics.Raycast(heldTrans.position, new Vector3(0, -1, 0), out hit, 100);
        heldPos.y = hit.point.y;
        heldTrans.position = heldPos;
        _isHolding = false;
        _heldItem = null;
        OnPickupFoundEvent?.Invoke(false);
    }
}
