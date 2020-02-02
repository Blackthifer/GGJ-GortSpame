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
        public float MovementDuration;
        public bool PlaySound;
    }
    
    [SerializeField] private Transform[] puzzlePieces;
    [SerializeField] private Transform[] piecePlacements;
    [SerializeField] private BGMManager bgmManager;
    [SerializeField] private int trackActivateNr;
    private int _arraySize;
    private bool _finished;

    [SerializeField] private ObjectAction[] toRemove;
    [SerializeField] private ObjectAction[] newObjects;

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
            TreeHandler.IncrementCounter(trackActivateNr - 1);
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
            TreeHandler.IncrementCounter(trackActivateNr-1);
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
            StartCoroutine(moveObject(current, true));
            AudioSource currentAudio = current.Object.GetComponent<AudioSource>();
            if(current.PlaySound && currentAudio)
                currentAudio.Play();
        }

        for (int i = 0; i < newObjects.Length; i++)
        {
            ObjectAction current = newObjects[i];
            current.Object.SetActive(true);
            StartCoroutine(moveObject(current));
            AudioSource currentAudio = current.Object.GetComponent<AudioSource>();
            if(current.PlaySound && currentAudio)
                currentAudio.Play();
        }
    }

    private IEnumerator moveObject(ObjectAction moveAction, bool remove = false)
    {
        GameObject toMove = moveAction.Object;
        Vector3 originalPos = toMove.transform.position;
        Vector3 finalPos = originalPos + moveAction.Movement;
        for (float j = 0; j < moveAction.MovementDuration; j += Time.deltaTime)
        {
            toMove.transform.position = Vector3.Lerp(originalPos, finalPos, j / moveAction.MovementDuration);
            yield return null;
        }
        moveAction.Object.SetActive(!remove);
    }
}
