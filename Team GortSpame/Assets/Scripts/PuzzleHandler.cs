using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    [SerializeField] private Transform[] puzzlePieces;
    [SerializeField] private Transform[] piecePlacements;
    [SerializeField] private int trackActivateNr;
    private int _arraySize;

    // Start is called before the first frame update
    void Start()
    {
        _arraySize = puzzlePieces.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
