using System.Collections;
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
        if (Input.GetKeyDown(debugActivator))
        {
            _finished = true;
            bgmManager.ActivateTrack(trackActivateNr);
        }
        
        if (!_finished)
        {
            for (int i = 0; i < _arraySize; i++)
            {
                if (!checkInPlace(i))
                    return;
                puzzlePieces[i].position = piecePlacements[i].position;
                puzzlePieces[i].gameObject.layer = 0;
            }
            _finished = true;
            bgmManager.ActivateTrack(trackActivateNr);
        }
    }

    private bool checkInPlace(int index)
    {
        return (puzzlePieces[index].position - piecePlacements[index].position).sqrMagnitude < 0.3f * 0.3f;
    }
}
