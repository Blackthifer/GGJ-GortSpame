﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    
    
    [SerializeField] private Transform[] puzzlePieces;
    [SerializeField] private Transform[] piecePlacements;
    [SerializeField] private BGMManager bgmManager;
    [SerializeField] private int trackActivateNr;
    private int _arraySize;
    private bool _finished;

    [SerializeField] private GameObject[] toBeReplaced;
    [SerializeField] private GameObject[] newObjects;

    [SerializeField] private KeyCode debugActivator;

    // Start is called before the first frame update
    void Start()
    {
        _arraySize = puzzlePieces.Length;
        _finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(debugActivator) && !_finished)
        {
            _finished = true;
            bgmManager.ActivateTrack(trackActivateNr);
            replaceObjects();
        }
        
        if (!_finished)
        {
            bool getOut = false;
            for (int i = 0; i < _arraySize; i++)
            {
                int positionMatched = checkInPlace(i);
                if (positionMatched < 0)
                {
                    getOut = true;
                    continue;
                }

                puzzlePieces[i].position = piecePlacements[positionMatched].position;
                puzzlePieces[i].gameObject.layer = 0;
            }

            if (getOut)
                return;
            _finished = true;
            bgmManager.ActivateTrack(trackActivateNr);
            replaceObjects();
        }
    }

    private int checkInPlace(int index)
    {
        for (int j = 0; j < _arraySize; j++)
        {
            if ((puzzlePieces[index].position - piecePlacements[j].position).sqrMagnitude < 0.3f * 0.3f)
            {
                Debug.Log("Matched!");
                return j;
            }
        }
        return -1;
    }

    private void replaceObjects()
    {
        for (int i = 0; i < toBeReplaced.Length; i++)
        {
            toBeReplaced[i].SetActive(false);
        }

        for (int i = 0; i < newObjects.Length; i++)
        {
            newObjects[i].SetActive(true);
        }
    }
}
