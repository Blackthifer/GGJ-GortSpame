using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    [Serializable]
    public struct ObjectAction
    {
        public GameObject Object;
        public Vector3 Movement;
        public bool PlaySound;
    }
    
    [SerializeField] private Transform[] puzzlePieces;
    [SerializeField] private Transform[] piecePlacements;
    [SerializeField] private BGMManager bgmManager;
    [SerializeField] private int trackActivateNr;
    private int _arraySize;
    private bool _finished;
    public static int puzzlesCompleted = 0;

    public GameObject stage1Tree;
    public GameObject stage2Tree;
    public GameObject stage3Tree;
    public GameObject stage4Tree;
    public GameObject stage5Tree;

    [SerializeField] private ObjectAction[] toRemove;
    [SerializeField] private ObjectAction[] newObjects;

    [SerializeField] private KeyCode debugActivator;

    // Start is called before the first frame update
    void Start()
    {
        _arraySize = puzzlePieces.Length;
        _finished = false;
        Debug.Log("Puzzles completed: " + puzzlesCompleted);
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
        sakuraTree();

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
            puzzlesCompleted += 1;
            Debug.Log("Puzzles completed: " + puzzlesCompleted);
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
        for (int i = 0; i < toRemove.Length; i++)
        {
            ObjectAction current = toRemove[i];
            current.Object.SetActive(false);
        }

        for (int i = 0; i < newObjects.Length; i++)
        {
            ObjectAction current = newObjects[i];
            current.Object.SetActive(true);
        }
    }

    public void sakuraTree()
    {
        if (puzzlesCompleted == 1)
        {
            stage1Tree.SetActive(true);
        }
        else if (puzzlesCompleted == 2)
        {
            stage1Tree.SetActive(false);
            stage2Tree.SetActive(true);
        }
        else if (puzzlesCompleted == 3)
        {
            stage2Tree.SetActive(false);
            stage3Tree.SetActive(true);
        }
        else if (puzzlesCompleted == 4)
        {
            stage3Tree.SetActive(false);
            stage4Tree.SetActive(true);
        }
        else if (puzzlesCompleted == 5)
        {
            stage4Tree.SetActive(false);
            stage5Tree.SetActive(true);
        }
    }
}
